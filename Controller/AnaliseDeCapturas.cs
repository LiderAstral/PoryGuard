using PoryGuard.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace PoryGuard.Controller
{
    class AnaliseDeCapturas
    {
        private int R = 0, G = 0, B = 0, Raux = 0, Gaux = 0, Baux = 0;
        private double luminanciaRelativa, luminanciaRelativaAux, vermelhoCritico, vermelhoCriticoAux;
        private double[] luminanciaMedia, vermelhoCriticoMedio;
        private bool liberado = false;
        private int frameRate;
        private int limiarVermelho = 20;
        private int variacao = 30;
        private int limiarLuminancia = 20;
        private Bitmap[] bitmaps;
        int subdivisoes = 30;
        private Censura censura;

        private const string configPath = "ConfiguraçãoPersistente.json";
        public int flashMinimo { get; set; }
        public int flashMaximo { get; set; }
        public int luminosidadeTela { get; set; }
        public int opacidadeCensura { get; set; }
        private int telaRealLargura;
        private int telaRealAltura;

        // Controle de duração mínima da censura
        private DateTime ultimaDeteccao = DateTime.MinValue;
        private const int DuracaoMinima = 2000;

        public AnaliseDeCapturas(int frameRate, int telaRealLargura, int telaRealAltura)
        {
            censura = new Censura();

            this.frameRate = frameRate;
            bitmaps = new Bitmap[frameRate];
            this.telaRealLargura = telaRealLargura;
            this.telaRealAltura = telaRealAltura;
            luminanciaMedia = new double[frameRate];
            vermelhoCriticoMedio = new double[frameRate];
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            try
            {
                if (!File.Exists(configPath))
                    return;
                var json = File.ReadAllText(configPath);
                var config = JsonSerializer.Deserialize<ConfiguracaoPersistente>(json);
                flashMinimo = 2 * config.FlashMinimo;
                flashMaximo = 2 * config.FlashMaximo;
                variacao = (int)(config.LuminosidadeTela * 255f) / 100;
                limiarLuminancia = (int)(config.LuminosidadeQuadrante * 255f) / 100;
                subdivisoes = config.Quadrantes;
                limiarVermelho = (int)(config.VermelhoCritico * 320f) / 100;
                opacidadeCensura = (int)(config.Opacidade * 255f) / 100;
            }
            catch (Exception ex)
            {
                flashMinimo = 3;
                flashMaximo = 30;
                variacao = 20;
                limiarLuminancia = 20;
                subdivisoes = 30;
                limiarVermelho = 20;
                opacidadeCensura = 200;
            }
        }
        public void InserirFrame(Bitmap bitmap, int contador)
        {
            if (contador == frameRate - 1)
                liberado = true;
            bitmaps[contador] = new Bitmap(bitmap);
            Color cores = CalcularMediaRGB(bitmaps[contador]);
            luminanciaMedia[contador] = 0.2126 * cores.R + 0.7152 * cores.G + 0.0722 * cores.B;
            vermelhoCriticoMedio[contador] = (cores.R - cores.G - cores.B) * 320 / 255f;
            if (contador % 15 == 0)
                AnalisarFrames(contador);
        }

        public void AnalisarFrames(int contador)
        {
            if (!liberado)
                return;
            try
            {
                censura.ClearRectangles();

                int contadorAux = contador;
                int subAltura = (int)Math.Ceiling((double)(bitmaps[contador].Height * subdivisoes) / bitmaps[contador].Width);
                double pixelsPorAltura = (double)bitmaps[contador].Height / subAltura;
                double pixelsPorLargura = (double)bitmaps[contador].Width / subdivisoes;
                bool[,] quadrantes = new bool[subdivisoes, subAltura];

                bool flashDetectado = false;

                for (int i = 0; i < subdivisoes; i++)
                {
                    for (int j = 0; j < subAltura; j++)
                    {
                        int flashes = 0;
                        for (int aux = 0; aux < frameRate; aux++)
                        {
                            if (--contadorAux == -1)
                                contadorAux = frameRate - 1;

                            if (Math.Abs(luminanciaMedia[contador] - luminanciaMedia[contadorAux]) >= limiarLuminancia ||
                                Math.Abs(vermelhoCriticoMedio[contador] - vermelhoCriticoMedio[contadorAux]) >= limiarVermelho)
                            {
                                int pixelX = Math.Min((int)((i + 0.5) * pixelsPorLargura), bitmaps[contador].Width - 1);
                                int pixelY = Math.Min((int)((j + 0.5) * pixelsPorAltura), bitmaps[contador].Height - 1);

                                R = bitmaps[contador].GetPixel(pixelX, pixelY).R;
                                G = bitmaps[contador].GetPixel(pixelX, pixelY).G;
                                B = bitmaps[contador].GetPixel(pixelX, pixelY).B;
                                vermelhoCritico = (R - G - B) * 320 / 255f;
                                if (vermelhoCritico < 0)
                                    vermelhoCritico = 0;
                                luminanciaRelativa = 0.2126 * R + 0.7152 * G + 0.0722 * B;

                                Raux = bitmaps[contadorAux].GetPixel(pixelX, pixelY).R;
                                Gaux = bitmaps[contadorAux].GetPixel(pixelX, pixelY).G;
                                Baux = bitmaps[contadorAux].GetPixel(pixelX, pixelY).B;
                                vermelhoCriticoAux = (Raux - Gaux - Baux) * 320 / 255f;
                                if (vermelhoCriticoAux < 0)
                                    vermelhoCriticoAux = 0;
                                luminanciaRelativaAux = 0.2126 * Raux + 0.7152 * Gaux + 0.0722 * Baux;

                                if (Math.Abs(luminanciaRelativa - luminanciaRelativaAux) >= variacao ||
                                    Math.Abs(vermelhoCritico - vermelhoCriticoAux) >= limiarVermelho)
                                {
                                    flashes++;
                                }
                            }
                            if (--contador == -1)
                                contador = frameRate - 1;
                        }

                        if (flashes >= flashMinimo && flashes <= flashMaximo)
                            flashDetectado = true;
                    }
                }

                // Se detectou qualquer flash perigoso, censura a tela inteira
                if (flashDetectado)
                {
                    ultimaDeteccao = DateTime.Now;
                    censura.AddRectangle(0,0, telaRealLargura, telaRealAltura, Color.FromArgb(opacidadeCensura, 0, 0, 0));
                }else
                {
                    TimeSpan tempoDecorrido = DateTime.Now - ultimaDeteccao;
                    if (tempoDecorrido.TotalMilliseconds < DuracaoMinima)
                    {
                        // Mantém a censura ativa
                        censura.AddRectangle(0, 0, telaRealLargura, telaRealAltura, Color.FromArgb(opacidadeCensura, 0, 0, 0));
                    }
                }

                censura.Redesenhar();
            }
            catch (NullReferenceException ex)
            { }
        }

        private Color CalcularMediaRGB(Bitmap imagem)
        {
            using (var reduzido = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(reduzido))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.SmoothingMode = SmoothingMode.None;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                var colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

                var imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);

                g.DrawImage(imagem, new Rectangle(0, 0, 1, 1), 0, 0, imagem.Width, imagem.Height, GraphicsUnit.Pixel, imageAttributes);

                return reduzido.GetPixel(0, 0);
            }
        }

        public void PararAnalise()
        {
            for (int i = 0; i < bitmaps.Length; i++)
            {
                try
                {
                    bitmaps[i]?.Dispose();
                    bitmaps[i] = null;
                }
                catch (NullReferenceException ex)
                { }
            }
            try
            {
                censura?.EncerraCensura();
                censura = null;
            }
            catch (NullReferenceException ex)
            { }
        }
    }
}