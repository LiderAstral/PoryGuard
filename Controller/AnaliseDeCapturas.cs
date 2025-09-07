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
        private float proporcao;
        private int limiarVermelho = 20; // Limiar de desvio de vermelho para considerar um quadrante como "flash"
        private int variacao = 30; // Valor de tolerância na variação de intensidade luminosa
        private int limiarLuminancia = 20; // Limiar de desvio de luminancia para considerar um quadrante como "flash"
        private Bitmap[] bitmaps;
        int subdivisoes = 30; // Número de subdivisões da maior dimensão para a análise
        private Censura censura;

        private const string configPath = "ConfiguraçãoPersistente.json";
        public int flashMinimo { get; set; }
        public int flashMaximo { get; set; }
        public int luminosidadeTela { get; set; }
        public int opacidadeCensura { get; set; }
        public AnaliseDeCapturas(int frameRate, float proporcao)
        {
            censura = new Censura();

            this.frameRate = frameRate;
            bitmaps = new Bitmap[frameRate];
            this.proporcao = proporcao;
            luminanciaMedia = new double[frameRate];
            vermelhoCriticoMedio = new double[frameRate];
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            if (!File.Exists(configPath))
                return;
            var json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<ConfiguracaoPersistente>(json);
            flashMinimo = config.FlashMinimo;
            flashMaximo = config.FlashMaximo;
            variacao = config.LuminosidadeTela;
            limiarLuminancia = config.LuminosidadeQuadrante;
            subdivisoes = config.Quadrantes;
            limiarVermelho = config.VermelhoCritico;
            opacidadeCensura = (int)(config.Opacidade*255f)/100;   
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
                bool[,] quadrantes = new bool[subdivisoes - 1, subAltura - 1];

                for (int i = 0; i < subdivisoes - 1; i++)
                {
                    for (int j = 0; j < subAltura - 1; j++)
                    {
                        int flashes = 0;
                        for (int aux = 0; aux < frameRate; aux++)
                        {
                            if (--contadorAux == -1)
                                contadorAux = frameRate - 1;
                            // Verifica se a diferença de luminância ou de vermelho crítico entre os frames é maior que o limiar
                            if (Math.Abs(luminanciaMedia[contador] - luminanciaMedia[contadorAux]) >= limiarLuminancia || Math.Abs(vermelhoCriticoMedio[contador] - vermelhoCriticoMedio[contadorAux]) >= limiarVermelho)
                            {
                                //Calcula o vermelho crítico do pixel, e sua luminância relativa, e compara com o frame anterior
                                R = bitmaps[contador].GetPixel((int)((i + 1) * pixelsPorLargura), (int)((j + 1) * pixelsPorAltura)).R;
                                G = bitmaps[contador].GetPixel((int)((i + 1) * pixelsPorLargura), (int)((j + 1) * pixelsPorAltura)).G;
                                B = bitmaps[contador].GetPixel((int)((i + 1) * pixelsPorLargura), (int)((j + 1) * pixelsPorAltura)).B;
                                vermelhoCritico = (R - G - B) * 320 / 255f;
                                if (vermelhoCritico < 0)
                                    vermelhoCritico = 0;
                                luminanciaRelativa = 0.2126 * R + 0.7152 * G + 0.0722 * B;
                                Raux = bitmaps[contadorAux].GetPixel((int)((i + 1) * pixelsPorLargura), (int)((j + 1) * pixelsPorAltura)).R;
                                Gaux = bitmaps[contadorAux].GetPixel((int)((i + 1) * pixelsPorLargura), (int)((j + 1) * pixelsPorAltura)).G;
                                Baux = bitmaps[contadorAux].GetPixel((int)((i + 1) * pixelsPorLargura), (int)((j + 1) * pixelsPorAltura)).B;
                                vermelhoCriticoAux = (Raux - Gaux - Baux) * 320 / 255f;
                                if (vermelhoCriticoAux < 0)
                                    vermelhoCriticoAux = 0;
                                luminanciaRelativaAux = 0.2126 * Raux + 0.7152 * Gaux + 0.0722 * Baux;
                                if (Math.Abs(luminanciaRelativa - luminanciaRelativaAux) >= variacao || Math.Abs(vermelhoCritico - vermelhoCriticoAux) >= limiarVermelho)
                                {
                                    flashes++;
                                }
                            }
                            if (--contador == -1)
                                contador = frameRate - 1;
                        }
                        if (flashes >= 6)
                            quadrantes[i, j] = true;
                        else
                            quadrantes[i, j] = false;
                    }
                }

                DetectarBlocosDeFlashes(quadrantes, pixelsPorLargura, pixelsPorAltura);
                censura.Redesenhar();
            }
            catch (NullReferenceException ex)
            { }
        }

        private void DetectarBlocosDeFlashes(bool[,] quadrantes, double pixelsPorLargura, double pixelsPorAltura)
        {
            int altura = quadrantes.GetLength(1);
            int largura = quadrantes.GetLength(0);

            for (int i = 0; i < largura; i++)
            {
                for (int j = 0; j < altura; j++)
                {
                    if (quadrantes[i, j])
                    {
                            censura.AddRectangle(
                            (int)(i * pixelsPorLargura),
                            (int)(j * pixelsPorAltura),
                            (int)(2 * pixelsPorLargura),
                            (int)(2 * pixelsPorAltura),
                            Color.FromArgb(opacidadeCensura, 0, 0, 0)
                        );
                    }
                }
            }
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
                    bitmaps[i].Dispose();
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