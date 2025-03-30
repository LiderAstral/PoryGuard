using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace PoryGuard.Controller
{
    class CapturaDeTela
    {
        private int altura;
        private int largura;
        private int frameRate;
        private int boundsX;
        private int boundsY;
        private Size size;
        private bool rodando;
        private Thread capturaThread;
        private Thread salvamentoThread;
        private static readonly object lockObject = new object();
        private ConcurrentQueue<(Bitmap, int)> filaDeImagens = new ConcurrentQueue<(Bitmap, int)>(); // Fila para salvar os bitmaps

        public CapturaDeTela()
        {
            Monitor monitor = new Monitor();
            ConfigurarMonitor(monitor);
            rodando = true;

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
            frameRate = 20; // Definir para 30 FPS exatos
            //frameRate = monitor.GetFrameRate();
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();
            size = new Size(largura, altura);
        }

        private void GerenciarCapturas()
        {
            int contador = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long tempoInicio = sw.ElapsedMilliseconds;

            while (rodando)
            {
                long tempoAlvo = tempoInicio + (contador * (1000 / frameRate));

                CapturaFrame(contador);

                contador = (contador + 1) % frameRate;

                // Espera até o próximo tempo-alvo sem usar Thread.Sleep() direto
                while (sw.ElapsedMilliseconds < tempoAlvo)
                {
                    Thread.SpinWait(1); // Usa um pequeno loop de espera ativa para maior precisão
                }

                Console.WriteLine($"Frame {contador} capturado em {sw.ElapsedMilliseconds - tempoInicio} ms");
            }
        }

        private void CapturaFrame(int contador)
        {
            try
            {
                Bitmap bitmap;
                lock (lockObject) // Evita conflito no acesso ao buffer de tela
                {
                    bitmap = new Bitmap(largura, altura);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(boundsX, boundsY, 0, 0, size, CopyPixelOperation.SourceCopy);
                    }
                }

                // Adiciona o bitmap à fila para ser salvo posteriormente
                filaDeImagens.Enqueue((bitmap, contador));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao capturar tela: {ex.Message}");
            }
        }

        private void SalvarImagens()
        {
            while (rodando || !filaDeImagens.IsEmpty)
            {
                if (filaDeImagens.TryDequeue(out var item))
                {
                    var (bitmap, contador) = item;
                    try
                    {
                        bitmap.Save($"{contador}_screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
                        bitmap.Dispose(); // Libera memória após salvar
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Erro ao salvar imagem: {ex.Message}");
                    }
                }
                else
                {
                    Thread.Sleep(1); // Pequeno delay para evitar loop desnecessário
                }
            }
        }

        public void PararCaptura()
        {
            rodando = false;
            capturaThread.Join();
            salvamentoThread.Join();
        }
    }
}
