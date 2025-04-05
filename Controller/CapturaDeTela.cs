using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace PoryGuard.Controller
{
    class CapturaDeTela
    {
        //variáveis do monitor
        private int altura;
        private int largura;
        private float proporcao;
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

        public CapturaDeTela()
        {
            Monitor monitor = new Monitor();
            ConfigurarMonitor(monitor);

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
            proporcao = monitor.GetProporcao();
            frameRate = monitor.GetFrameRate();
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();
            size = new Size(largura, altura);
            bitmaps = new Bitmap[frameRate];    
        }

        private void GerenciarCapturas()
        {
            int contador = 0;
            Stopwatch sw = new Stopwatch();
            long tempoAlvo = 1000 / frameRate;
            while (true)
            {
                sw.Restart();   
                CapturaFrame(contador);
                contador = (contador + 1) % frameRate;

                //Espera até o próximo tempo-alvo sem usar Thread.Sleep() direto
                while (sw.ElapsedMilliseconds < tempoAlvo)
                {
                    Thread.SpinWait(1); //Melhor que Thread.Sleep()
                }

                //Console.WriteLine($"Frame {contador} capturado em {sw.ElapsedMilliseconds} ms");
            }
        }

        private void CapturaFrame(int contador)
        {
            try
            {
                Bitmap bitmap;
                lock (lockObject) //Evita conflito no acesso ao buffer de tela
                {
                    bitmap = new Bitmap(largura, altura);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(boundsX, boundsY, 0, 0, size, CopyPixelOperation.SourceCopy);
                    }
                }
                while (filaDeImagens.Count >= 10)
                {
                    Console.WriteLine("Fila cheia, aguardando...");
                    Thread.Sleep(1000); //Aguarda 1 segundo para liberar espaço em caso de sobrecarga.
                }
                //Adiciona o bitmap à fila para ser salvo posteriormente
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
                    AnaliseDeCapturas.AnalisarCapturas(bitmap, proporcao);
                    bitmap.Dispose(); // Libera memória após salvar
                }
                else
                {
                    Thread.Sleep(1); // Pequeno delay para evitar consumo de recursos desnecessário
                }
            }
        }
    }
}
