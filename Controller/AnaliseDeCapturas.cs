﻿using PoryGuard.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private Censura[] censura;

        public AnaliseDeCapturas(int frameRate, float proporcao)
        {
            censura = new Censura[2];
            censura[0] = new Censura();
            censura[1] = new Censura();
            this.frameRate = frameRate;
            bitmaps = new Bitmap[frameRate];
            this.proporcao = proporcao;
            luminanciaMedia = new double[frameRate];
            vermelhoCriticoMedio = new double[frameRate];
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
                censura[contador % 2].ClearRectangles();
                int contadorAux = contador;
                if (proporcao >= 1.0f)
                {
                    int subAltura = (int)Math.Ceiling((double)(bitmaps[contador].Height * subdivisoes) / bitmaps[contador].Width);
                    int pixelsPorAltura = (int)Math.Ceiling((double)(bitmaps[contador].Height / subAltura));
                    int pixelsPorLargura = (int)Math.Ceiling((double)(bitmaps[contador].Width / subdivisoes));
                    bool[,] quadrantes = new bool[subdivisoes, subAltura];
                    for (int i = 0; i < subdivisoes; i++)
                    {
                        for (int j = 0; j < subAltura; j++)
                        {
                            int flashes = 0;
                            for (int aux = 0; aux < frameRate; aux++)
                            {
                                if (--contadorAux == -1)
                                    contadorAux = frameRate - 1;
                                // Verifica se a diferença de luminância entre os frames é maior que o limiar
                                if (Math.Abs(luminanciaMedia[contador] - luminanciaMedia[contadorAux]) >= limiarLuminancia || Math.Abs(vermelhoCriticoMedio[contador] - vermelhoCriticoMedio[contadorAux]) >= limiarVermelho)
                                {
                                    //Calcula o vermelho crítico do pixel, e sua luminância relativa, e compara com o frame anterior
                                    R = bitmaps[contador].GetPixel((int)((i + 0.5) * pixelsPorLargura), (int)((j + 0.5) * pixelsPorAltura)).R;
                                    G = bitmaps[contador].GetPixel((int)((i + 0.5) * pixelsPorLargura), (int)((j + 0.5) * pixelsPorAltura)).G;
                                    B = bitmaps[contador].GetPixel((int)((i + 0.5) * pixelsPorLargura), (int)((j + 0.5) * pixelsPorAltura)).B;
                                    vermelhoCritico = (R - G - B) * 320 / 255f;
                                    if (vermelhoCritico < 0)
                                        vermelhoCritico = 0;
                                    luminanciaRelativa = 0.2126 * R + 0.7152 * G + 0.0722 * B;
                                    Raux = bitmaps[contadorAux].GetPixel((int)((i + 0.5) * pixelsPorLargura), (int)((j + 0.5) * pixelsPorAltura)).R;
                                    Gaux = bitmaps[contadorAux].GetPixel((int)((i + 0.5) * pixelsPorLargura), (int)((j + 0.5) * pixelsPorAltura)).G;
                                    Baux = bitmaps[contadorAux].GetPixel((int)((i + 0.5) * pixelsPorLargura), (int)((j + 0.5) * pixelsPorAltura)).B;
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
                    DetectarBlocosDeFlashes(quadrantes, pixelsPorLargura, pixelsPorAltura, contador);
                    censura[contador % 2].Redesenhar();
                }
                else
                {
                    int subLargura = (int)Math.Ceiling((double)(bitmaps[contador].Width * subdivisoes) / bitmaps[contador].Height);
                    int pixelsPorLargura = (int)Math.Ceiling((double)(bitmaps[contador].Width / subLargura));
                    int pixelsPorAltura = (int)Math.Ceiling((double)(bitmaps[contador].Width / subdivisoes));
                    for (int i = 0; i < subdivisoes; i++)
                    {
                        for (int j = 0; j < subLargura; j++)
                        {
                            for (int aux = 0; aux < frameRate; aux++)
                            {
                                if (--contadorAux == -1)
                                    contadorAux = frameRate - 1;

                                if (Math.Abs(bitmaps[contador].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).R - bitmaps[contadorAux].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).R) >= variacao)
                                    censura[contador % 2].AddRectangle(i * pixelsPorLargura, j * pixelsPorAltura, pixelsPorLargura, pixelsPorAltura, Color.FromArgb(255, 0, 0, 0));
                            }
                        }
                    }
                    censura[contador % 2].Redesenhar();
                }
            }
            catch(NullReferenceException ex)
            {  }

        }
        private void DetectarBlocosDeFlashes(bool[,] quadrantes, int pixelsPorLargura, int pixelsPorAltura, int contador)
        {
            int altura = quadrantes.GetLength(1);
            int largura = quadrantes.GetLength(0);

            for (int i = 0; i < largura - 1; i++)
            {
                for (int j = 0; j < altura - 1; j++)
                {
                    // Verifica se os 4 quadrantes vizinhos formam um bloco de 2x2 todos "true"
                    if (quadrantes[i, j] && quadrantes[i + 1, j] &&
                        quadrantes[i, j + 1] && quadrantes[i + 1, j + 1])
                    {
                        // Marca todos os 4 quadrantes com AddRectangle
                        censura[contador % 2].AddRectangle(i * pixelsPorLargura, j * pixelsPorAltura, 2 * pixelsPorLargura, 2 * pixelsPorAltura, Color.FromArgb(255, 0, 0, 0));
                        censura[contador % 2].AddRectangle((i + 1) * pixelsPorLargura, j * pixelsPorAltura, 2 * pixelsPorLargura, 2 * pixelsPorAltura, Color.FromArgb(255, 0, 0, 0));
                        censura[contador % 2].AddRectangle(i * pixelsPorLargura, (j + 1) * pixelsPorAltura, 2 * pixelsPorLargura, 2 * pixelsPorAltura, Color.FromArgb(255, 0, 0, 0));
                        censura[contador % 2].AddRectangle((i + 1) * pixelsPorLargura, (j + 1) * pixelsPorAltura, 2 * pixelsPorLargura, 2 * pixelsPorAltura, Color.FromArgb(255, 0, 0, 0));
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

                return reduzido.GetPixel(0, 0); // Contém a média
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
            for (int i = 0; i < censura.Length; i++)
            {
                try
                {
                    censura[i].EncerraCensura();
                    censura[i] = null;
                }
                catch (NullReferenceException ex)
                { }
            }
        }
    }
}
