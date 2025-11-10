using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime;
using System.Runtime.InteropServices;

namespace PoryGuard.Controller
{
    class CapturaDeTela : IDisposable
    {
        private int altura;
        private int largura;
        private int frameRate;
        private int boundsX;
        private int boundsY;

        private Thread capturaThread;
        private Thread salvamentoThread;

        private ConcurrentQueue<FrameData> filaDeImagens = new ConcurrentQueue<FrameData>();
        private AnaliseDeCapturas analiseDeCapturas;

        private int telaRealLargura;
        private int telaRealAltura;
        private volatile bool executando = true;
        private bool disposed = false;

        // Bitmap reutilizável
        private Bitmap bitmapCaptura;
        private Bitmap bitmapReduzido;
        private BitmapData bmpDataCaptura;
        private BitmapData bmpDataReduzido;
        private IntPtr ptrCaptura;
        private IntPtr ptrReduzido;

        // Dimensões
        private int targetWidth;
        private int targetHeight;
        private int strideCaptura;
        private int strideReduzido;
        private int bytesCaptura;
        private int bytesReduzido;

        // Buffer reutilizável para redimensionamento
        private byte[] bufferReduzido;

        public CapturaDeTela()
        {
            // Configuração menos agressiva do GC
            GCSettings.LatencyMode = GCLatencyMode.Interactive;

            Monitor monitor = new Monitor();
            ConfigurarMonitor(monitor);
            InicializarBitmaps();

            analiseDeCapturas = new AnaliseDeCapturas(frameRate, telaRealLargura, telaRealAltura);

            capturaThread = new Thread(GerenciarCapturas)
            {
                IsBackground = true,
                Priority = ThreadPriority.Normal, // Reduzido de AboveNormal
                Name = "CapturaThread"
            };
            capturaThread.Start();

            salvamentoThread = new Thread(ProcessarImagens)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal, // Reduzido para diminuir impacto
                Name = "ProcessamentoThread"
            };
            salvamentoThread.Start();
        }

        private void ConfigurarMonitor(Monitor monitor)
        {
            altura = monitor.GetAltura();
            largura = monitor.GetLargura();
            frameRate = monitor.GetFrameRate();
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();

            telaRealLargura = largura;
            telaRealAltura = altura;

            // Calcula dimensões reduzidas
            int maxWidth = 640;
            targetWidth = Math.Min(largura, maxWidth);
            targetHeight = (int)((float)altura / largura * targetWidth);
        }

        private void InicializarBitmaps()
        {
            // Cria bitmaps uma única vez
            bitmapCaptura = new Bitmap(largura, altura, PixelFormat.Format24bppRgb);
            bitmapReduzido = new Bitmap(targetWidth, targetHeight, PixelFormat.Format24bppRgb);

            // Pré-aloca buffer para redimensionamento
            bytesCaptura = ((largura * 24 + 31) / 32) * 4 * altura;
            bytesReduzido = ((targetWidth * 24 + 31) / 32) * 4 * targetHeight;
            bufferReduzido = new byte[bytesReduzido];

            // Lock permanente dos bitmaps
            bmpDataCaptura = bitmapCaptura.LockBits(
                new Rectangle(0, 0, largura, altura),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb
            );

            bmpDataReduzido = bitmapReduzido.LockBits(
                new Rectangle(0, 0, targetWidth, targetHeight),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb
            );

            ptrCaptura = bmpDataCaptura.Scan0;
            ptrReduzido = bmpDataReduzido.Scan0;
            strideCaptura = bmpDataCaptura.Stride;
            strideReduzido = bmpDataReduzido.Stride;
        }

        private void GerenciarCapturas()
        {
            int contador = 0;
            Stopwatch sw = new Stopwatch();
            int tempoAlvo = 1000 / frameRate;

            // Timer de alta resolução apenas quando necessário
            TimeBeginPeriod(1);

            try
            {
                while (executando)
                {
                    sw.Restart();

                    CapturaFrame(contador);
                    contador = (contador + 1) % frameRate;

                    int tempoDecorrido = (int)sw.ElapsedMilliseconds;
                    int tempoRestante = tempoAlvo - tempoDecorrido;

                    if (tempoRestante > 0)
                    {
                        Thread.Sleep(tempoRestante);
                    }

                    // Pequena pausa adicional para reduzir calor
                    if (contador % 10 == 0)
                    {
                        Thread.Sleep(0); // Yield para o scheduler
                    }
                }
            }
            finally
            {
                TimeEndPeriod(1);
            }
        }

        private void CapturaFrame(int contador)
        {
            try
            {
                if (filaDeImagens.Count >= 5) 
                {
                    Thread.Sleep(5); 
                    return;
                }

                // Captura direta na memória do bitmap
                CopyFromScreenDirect(boundsX, boundsY, ptrCaptura, largura, altura, strideCaptura);

                // Redimensionamento otimizado
                RedimensionarRapido(ptrCaptura, largura, altura, strideCaptura,
                                   ptrReduzido, targetWidth, targetHeight, strideReduzido);

                // Copia para buffer
                Marshal.Copy(ptrReduzido, bufferReduzido, 0, bytesReduzido);

                filaDeImagens.Enqueue(new FrameData
                {
                    Data = (byte[])bufferReduzido.Clone(),
                    Contador = contador
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO] CapturaFrame: {ex.Message}");
            }
        }

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
                                         IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi,
                                                      uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        private struct BITMAPINFO
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }

        private void CopyFromScreenDirect(int x, int y, IntPtr dest, int width, int height, int stride)
        {
            IntPtr screenDC = GetDC(IntPtr.Zero);
            IntPtr memDC = CreateCompatibleDC(screenDC);

            BITMAPINFO bmi = new BITMAPINFO
            {
                biSize = Marshal.SizeOf(typeof(BITMAPINFO)),
                biWidth = width,
                biHeight = -height, // Top-down
                biPlanes = 1,
                biBitCount = 24,
                biCompression = 0
            };

            IntPtr hBitmap = CreateDIBSection(memDC, ref bmi, 0, out IntPtr bits, IntPtr.Zero, 0);
            IntPtr oldBitmap = SelectObject(memDC, hBitmap);

            // BitBlt é mais rápido que CopyFromScreen
            BitBlt(memDC, 0, 0, width, height, screenDC, x, y, 0x00CC0020); // SRCCOPY

            // Copia bits direto para o destino
            unsafe
            {
                byte* src = (byte*)bits.ToPointer();
                byte* dst = (byte*)dest.ToPointer();

                for (int i = 0; i < height; i++)
                {
                    Buffer.MemoryCopy(src + i * ((width * 3 + 3) & ~3),
                                    dst + i * stride,
                                    stride,
                                    width * 3);
                }
            }

            SelectObject(memDC, oldBitmap);
            DeleteObject(hBitmap);
            DeleteDC(memDC);
            ReleaseDC(IntPtr.Zero, screenDC);
        }

        private void RedimensionarRapido(IntPtr src, int srcW, int srcH, int srcStride,
                                        IntPtr dst, int dstW, int dstH, int dstStride)
        {
            unsafe
            {
                byte* srcPtr = (byte*)src.ToPointer();
                byte* dstPtr = (byte*)dst.ToPointer();

                float xRatio = (float)srcW / dstW;
                float yRatio = (float)srcH / dstH;

                for (int y = 0; y < dstH; y++)
                {
                    int srcY = (int)(y * yRatio);
                    byte* srcRow = srcPtr + srcY * srcStride;
                    byte* dstRow = dstPtr + y * dstStride;

                    for (int x = 0; x < dstW; x++)
                    {
                        int srcX = (int)(x * xRatio);
                        int srcIndex = srcX * 3;
                        int dstIndex = x * 3;

                        dstRow[dstIndex] = srcRow[srcIndex];         // B
                        dstRow[dstIndex + 1] = srcRow[srcIndex + 1]; // G
                        dstRow[dstIndex + 2] = srcRow[srcIndex + 2]; // R
                    }
                }
            }
        }

        private void ProcessarImagens()
        {
            int frameCount = 0;

            while (executando || filaDeImagens.Count > 0)
            {
                if (filaDeImagens.TryDequeue(out FrameData frameData))
                {
                    try
                    {
                        using (Bitmap bitmap = ByteArrayToBitmap(frameData.Data))
                        {
                            analiseDeCapturas.InserirFrame(bitmap, frameData.Contador);
                        }

                        frameCount++;

                        // GC menos frequente
                        if (frameCount % 60 == 0) // A cada 2 segundos
                        {
                            GC.Collect(1, GCCollectionMode.Optimized, false); // Gen1 apenas
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ERRO] ProcessarImagens: {ex.Message}");
                    }
                }
                else
                {
                    Thread.Sleep(2); // Sleep maior quando ocioso
                }
            }
        }

        private Bitmap ByteArrayToBitmap(byte[] data)
        {
            Bitmap bitmap = new Bitmap(targetWidth, targetHeight, PixelFormat.Format24bppRgb);

            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, targetWidth, targetHeight),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
            );

            try
            {
                Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
                return bitmap;
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
        }

        public void PararCaptura()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;

            executando = false;

            // Aguarda threads
            capturaThread?.Join(3000);
            salvamentoThread?.Join(3000);

            // Para análise
            analiseDeCapturas?.PararAnalise();
            if (analiseDeCapturas is IDisposable disposable)
            {
                disposable.Dispose();
            }

            // Limpa fila
            while (filaDeImagens.TryDequeue(out _)) { }

            if (bmpDataCaptura != null)
            {
                bitmapCaptura?.UnlockBits(bmpDataCaptura);
                bmpDataCaptura = null;
            }

            if (bmpDataReduzido != null)
            {
                bitmapReduzido?.UnlockBits(bmpDataReduzido);
                bmpDataReduzido = null;
            }

            bitmapReduzido?.Dispose();
            bitmapCaptura?.Dispose();

            GCSettings.LatencyMode = GCLatencyMode.Interactive;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        [DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int period);

        [DllImport("winmm.dll")]
        private static extern int timeEndPeriod(int period);

        private static void TimeBeginPeriod(int period) => timeBeginPeriod(period);
        private static void TimeEndPeriod(int period) => timeEndPeriod(period);

        private class FrameData
        {
            public byte[] Data { get; set; }
            public int Contador { get; set; }
        }
    }
}