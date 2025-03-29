using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoryGuard.Controller
{
    class CapturaDeTela
    {
        int altura;
        int largura;
        int frameRate;
        int boundsX;
        int boundsY;
        int bytesPerPixel = 4;
        int stride;
        int totalBytes;
        int offset;
        int aux_timer = 0;
        Size size;
        short[,,,] pixels;
        Timer timer;
        List<Thread> coletor = new List<Thread>(); //Instancia uma lista de threads que coletarão bitmaps da tela

        public CapturaDeTela() 
        {
            Monitor monitor = new Monitor();
            ColetaBitmap(monitor);
        }
        private void ColetaBitmap(Monitor monitor)
        {
            //Armazena os valores relevantes do monitor instanciado em variáveis locais

            altura = monitor.GetAltura();
            largura = monitor.GetLargura();
            frameRate = 28; //Fixo em 20 para fins de otimização durante produção
            //frameRate = monitor.GetFrameRate(); 
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();
            size = new Size(largura, altura);
            pixels = new short[largura, altura, frameRate, 4];
            timer = new Timer(CriaThread, null, 0, (Int32)(1000 / frameRate)); //timer para que a criação das threads
        }                                                                      //tenha a cadência da frameHate
        public void ColetaFrame(int i)
        {
            Thread.Sleep(1000); //Pausa para a execução das threads não interferir na latência da criação das mesmas
            Stopwatch sw = new Stopwatch();
            //while (true)
            //{
                sw.Restart();
                sw.Start();
                BitmapData bitmapData;
                using (Bitmap bitmap = new Bitmap(largura, altura))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(boundsX, boundsY, 0, 0, size, CopyPixelOperation.SourceCopy);
                    }
                    bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    stride = bitmapData.Stride;
                    totalBytes = stride * altura;
                    byte[] pixelBuffer = new byte[totalBytes];
                    Marshal.Copy(bitmapData.Scan0, pixelBuffer, 0, totalBytes);
                    for (int j = 0; j < altura; j++)
                    {
                        for (int k = 0; k < largura; k++)
                        {
                            offset = (j * stride) + (k * bytesPerPixel);
                            pixels[k, j, i, 0] = pixelBuffer[offset + 2];
                            pixels[k, j, i, 1] = pixelBuffer[offset + 1];
                            pixels[k, j, i, 2] = pixelBuffer[offset];
                            pixels[k, j, i, 3] = pixelBuffer[offset + 3];
                            //Console.WriteLine($"RGB: ({k} {j} {i} - {pixels[k, j, i, 0]}, {pixels[k, j, i, 1]}, {pixels[k, j, i, 2]}, {pixels[k, j, i, 3]})");
                        }
                    }
                    bitmap.UnlockBits(bitmapData);
                }
                sw.Stop();
                if (sw.ElapsedMilliseconds < 1000)
                    Thread.Sleep(1000 - (Int32)sw.ElapsedMilliseconds);
                Console.WriteLine(sw.ElapsedMilliseconds);
            //}
        }
        public void CriaThread(object obj) //Função invocada pelo Timer
        {
            int i = aux_timer;
            if (aux_timer >= frameRate)
            {
                timer.Dispose();
                return;
            }
            Thread t = new Thread(() => ColetaFrame(i));
            coletor.Add(t);
            t.IsBackground = true;
            t.Start();
            aux_timer++;
        }
    }
}
