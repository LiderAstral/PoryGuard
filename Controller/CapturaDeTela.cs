using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace PoryGuard.Controller
{
    class CapturaDeTela
    {
        //variáveis do monitor
        private int altura;
        private int largura;
        private int frameRate;
        private int boundsX;
        private int boundsY;
        private Size size;
        //Duas threads para captura e salvamento distintas para evitar latência
        private Thread capturaThread;
        private Thread salvamentoThread;
        //Fila para salvar os bitmaps capturados, com lockobject para evitar conflitos
        private static readonly object lockObject = new object();
        private ConcurrentQueue<(Bitmap, int)> filaDeImagens = new ConcurrentQueue<(Bitmap, int)>();
        //Array para armazenar os bitmaps capturados localmente
        private Bitmap[] bitmaps;
        //Classe para enviar as imagens para análise
        private AnaliseDeCapturas analiseDeCapturas;

        // 🔽 Variáveis para redimensionamento
        private int telaRealLargura;
        private int telaRealAltura;

        public CapturaDeTela()
        {
            Monitor monitor = new Monitor();
            ConfigurarMonitor(monitor);
            analiseDeCapturas = new AnaliseDeCapturas(frameRate, telaRealLargura, telaRealAltura);
            // Thread que captura as imagens sem bloqueio
            capturaThread = new Thread(GerenciarCapturas);
            capturaThread.IsBackground = true;
            capturaThread.Start();

            // Thread que salva as imagens separadamente
            salvamentoThread = new Thread(SalvarImagens);
            salvamentoThread.IsBackground = true;
            salvamentoThread.Start();
        }

        private void ConfigurarMonitor(Monitor monitor)
        {
            altura = monitor.GetAltura();
            largura = monitor.GetLargura();
            frameRate = monitor.GetFrameRate();
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();
            size = new Size(largura, altura);
            bitmaps = new Bitmap[frameRate];

            // Guardar dimensões reais da tela
            telaRealLargura = largura;
            telaRealAltura = altura;
        }

        private void GerenciarCapturas()
        {
            int contador = 0;
            Stopwatch sw = new Stopwatch();
            int tempoAlvo = 1000 / frameRate;
            while (true)
            {
                sw.Restart();
                CapturaFrame(contador);
                contador = (contador + 1) % frameRate;

                while (sw.ElapsedMilliseconds < tempoAlvo)
                {
                    Thread.SpinWait(1);
                }
            }
        }

        private void CapturaFrame(int contador)
        {
            try
            {
                Bitmap bitmap;
                lock (lockObject)
                {
                    bitmap = new Bitmap(largura, altura);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(boundsX, boundsY, 0, 0, size, CopyPixelOperation.SourceCopy);
                    }
                }

                // Reduzir resolução para análise
                int maxWidth = 640;
                if (bitmap.Width > maxWidth)
                {
                    int newHeight = (int)((float)bitmap.Height / bitmap.Width * maxWidth);
                    Bitmap reduzido = new Bitmap(maxWidth, newHeight);
                    using (Graphics g = Graphics.FromImage(reduzido))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                        g.DrawImage(bitmap, 0, 0, maxWidth, newHeight);
                    }
                    bitmap.Dispose();
                    bitmap = reduzido;
                }

                while (filaDeImagens.Count >= 10)
                {
                    Thread.Sleep(1000);
                }

                filaDeImagens.Enqueue((bitmap, contador));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao capturar tela: {ex.Message}");
            }
        }

        private void SalvarImagens()
        {
            while (true)
            {
                if (filaDeImagens.TryDequeue(out var item))
                {
                    var (bitmap, contador) = item;
                    bitmaps[contador] = bitmap;
                    analiseDeCapturas.InserirFrame(bitmap, contador);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }
        public void PararCaptura()
        {
            analiseDeCapturas.PararAnalise();
            capturaThread.Abort();
            salvamentoThread.Abort();
            foreach (var bitmap in bitmaps)
            {
                bitmap?.Dispose();
            }
        }
    }
}