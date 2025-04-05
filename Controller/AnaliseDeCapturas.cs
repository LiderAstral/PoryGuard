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
        
        public AnaliseDeCapturas()
        {

        }
        public static void AnalisarCapturas(Bitmap bitmap, float proporcao)
        {
            int subdivisoes = 100; // Número de subdivisões da maior dimensão para a análise
            if(proporcao>= 1.0f)
            {
                int subAltura = (bitmap.Height * subdivisoes)/bitmap.Width;
                int pixelsPorAltura = bitmap.Height / subAltura;
                int pixelsPorLargura = bitmap.Width / subdivisoes;
                for (int i=0; i <= subdivisoes; i++) {
                    for(int j=0; j < subAltura; j++)
                    {
                        int a = bitmap.GetPixel(i*pixelsPorLargura, j*pixelsPorLargura).R;
                    }
                }
            }
            else
            {
                int pixelsLargura = (bitmap.Width * 20) / bitmap.Height;
                for (int i = 0; i <= 20; i++)
                {
                    for (int j = 0; j < pixelsLargura; j++)
                    {
                        bitmap.GetPixel(i * 20, j * pixelsLargura);
                    }
                }
            }
        }
    }
}
