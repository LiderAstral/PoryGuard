using PoryGuard.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoryGuard.Controller
{
    class AnaliseDeCapturas
    {
        private int R = 0, G = 0, B = 0, Raux = 0, Gaux = 0, Baux = 0;
        private double luminanciaRelativa, luminanciaRelativaAux;
        private bool liberado = false;
        private int frameRate;
        private float proporcao;
        private int variacao = 1; // Valor de tolerância na variação de intensidade de vermelho
        private Bitmap[] bitmaps;
        int subdivisoes = 50; // Número de subdivisões da maior dimensão para a análise
        private Censura[] censura;
        public AnaliseDeCapturas(int frameRate, float proporcao)
        {
            censura = new Censura[2];
            censura[0] = new Censura();
            censura[1] = new Censura();
            this.frameRate = frameRate;
            bitmaps = new Bitmap[frameRate];
            this.proporcao = proporcao;
        }
        public void InserirFrame(Bitmap bitmap, int contador)
        {
            if (contador == frameRate - 1)
                liberado = true;
            bitmaps[contador] = new Bitmap(bitmap);
            if(contador % 15 == 0)
                AnalisarFrames(contador);
        }
        public void AnalisarFrames(int contador)
        {
            if (!liberado)
                return;
            censura[contador%2].ClearRectangles();
            int contadorAux = contador;
            if (proporcao >= 1.0f)
            {
                int subAltura = (int)Math.Ceiling((double)(bitmaps[contador].Height * subdivisoes) / bitmaps[contador].Width);
                int pixelsPorAltura = (int)Math.Ceiling((double)(bitmaps[contador].Height / subAltura));
                int pixelsPorLargura = (int)Math.Ceiling((double)(bitmaps[contador].Width / subdivisoes));
                for (int i = 0; i < subdivisoes; i++)
                {
                    for (int j = 0; j < subAltura; j++)
                    {
                        for (int aux = 0; aux < frameRate; aux++)
                        {
                            if (--contadorAux == -1)
                                contadorAux = frameRate - 1;
                            R = bitmaps[contador].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).R;
                            G = bitmaps[contador].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).G;
                            B = bitmaps[contador].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).B;
                            luminanciaRelativa = 0.2126 * R + 0.7152 * G + 0.0722 * B;
                            Raux = bitmaps[contadorAux].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).R;
                            Gaux = bitmaps[contadorAux].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).G;
                            Baux = bitmaps[contadorAux].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).B;
                            luminanciaRelativaAux = 0.2126 * Raux + 0.7152 * Gaux + 0.0722 * Baux;
                            if (luminanciaRelativa - luminanciaRelativaAux >= variacao)  
                                censura[contador % 2].AddRectangle(i * pixelsPorLargura, j * pixelsPorAltura, pixelsPorLargura, pixelsPorAltura, Color.FromArgb(255, 0, 0, 0));
                        }
                    }
                }
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
    }
}
