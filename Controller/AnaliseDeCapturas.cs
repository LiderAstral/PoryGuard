using PoryGuard.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryGuard.Controller
{
    class AnaliseDeCapturas
    {
        private bool liberado = false;
        private int frameRate;
        private float proporcao;
        private int variacao = 200; // Valor de tolerância na variação de intensidade de vermelho
        private Bitmap[] bitmaps;
        int subdivisoes = 30; // Número de subdivisões da maior dimensão para a análise
        private OverlayCensura overlayCensura = new OverlayCensura();

        public AnaliseDeCapturas(int frameRate, float proporcao)
        {
            overlayCensura.Show();
            this.frameRate = frameRate;
            bitmaps = new Bitmap[frameRate];
            this.proporcao = proporcao;
        }
        public void InserirFrame(Bitmap bitmap, int contador)
        {
            if (contador == frameRate - 1)
                liberado = true;
            bitmaps[contador] = new Bitmap(bitmap);
            AnalisarFrames(contador);
        }
        public void AnalisarFrames(int contador)
        {
            if (!liberado)
                return;
            int contadorAux = contador;
            if (proporcao >= 1.0f)
            {
                int subAltura = (bitmaps[contador].Height * subdivisoes) / bitmaps[contador].Width;
                int pixelsPorAltura = bitmaps[contador].Height / subAltura;
                int pixelsPorLargura = bitmaps[contador].Width / subdivisoes;
                for (int i = 0; i < subdivisoes; i++)
                {
                    for (int j = 0; j < subAltura; j++)
                    {
                        for (int aux = 0; aux < 30; aux++)
                        {
                            if (--contadorAux == -1)
                                contadorAux = frameRate - 1;
                        
                            if (Math.Abs(bitmaps[contador].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).R - bitmaps[contadorAux].GetPixel(i * pixelsPorLargura, j * pixelsPorAltura).R) >= variacao  && i == 0 && j == 0)
                                Console.WriteLine("Diferença de cor detectada entre os frames " + contador + " e " + contadorAux);
                        }
                        //int a = bitmap.GetPixel(i*pixelsPorLargura, j*pixelsPorLargura).R;
                    }
                }
            }
            else
            {
                int subLargura = (bitmaps[contador].Width * subdivisoes) / bitmaps[contador].Height;
                int pixelsPorLargura = bitmaps[contador].Width / subLargura;
                int pixelsPorAltura = bitmaps[contador].Height / subdivisoes;
                for (int i = 0; i <= subdivisoes; i++)
                {
                    for (int j = 0; j < subLargura; j++)
                    {
                        //int a = bitmap.GetPixel(i*pixelsPorLargura, j*pixelsPorLargura).R;
                    }
                }
            }
        }
    }
}
