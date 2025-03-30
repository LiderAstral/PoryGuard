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
        int aux_timer = 0;
        Size size;
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
            frameRate = monitor.GetFrameRate(); 
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();
            size = new Size(largura, altura);
            timer = new Timer(CriaThread, null, 0, (Int32)(1000 / frameRate)); //timer para que a criação das threads
        }                                                                      //tenha a cadência da frameHate
        public void ColetaFrame(int i)
        {
            Stopwatch sw = new Stopwatch();
            while (true)
            {
                sw.Restart();
                using (Bitmap bitmap = new Bitmap(largura, altura))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(boundsX, boundsY, 0, 0, size, CopyPixelOperation.SourceCopy);
                        
                    }
                    bitmap.Save(i.ToString()+"screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
                }
                sw.Stop();
                if (sw.ElapsedMilliseconds < 1000)
                    Thread.Sleep(1000 - (Int32)sw.ElapsedMilliseconds);
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }
        public void CriaThread(object obj) //Função invocada pelo Timer
        {
            Thread.Sleep(5000); //pausa para sincronização das threads
            int i = aux_timer;
            if (i >= frameRate)
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
