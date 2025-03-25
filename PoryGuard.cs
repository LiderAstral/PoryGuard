using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using System.Threading;

namespace PoryGuard
{
    public partial class PoryGuard: Form
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
        Size size;
        short[,,,] pixels;
        public PoryGuard()
        {
            InitializeComponent();
            Monitor monitor = new Monitor();
            ColetaBitmap(monitor);
        }
        private void ColetaBitmap(Monitor monitor)
        {
            altura = monitor.GetAltura();
            largura = monitor.GetLargura();
            frameRate = monitor.GetFrameRate();
            boundsX = monitor.GetBoundsX();
            boundsY = monitor.GetBoundsY();
            List<Thread> coletor = new List<Thread>();
            size = new Size(largura, altura);
            pixels = new short[largura, altura, frameRate, 4];
            for (int i = 0; i < frameRate; i++)
            {
                int aux = i;
                Thread t = new Thread(() => ColetaFrame(aux));
                coletor.Add(t);
                t.IsBackground = true;
                t.Start();
            }
            Console.WriteLine("Acabou");
        }
        public void ColetaFrame()
        {

        }
        public void ColetaFrame(int i)
        {
            BitmapData bitmapData;
            using (Bitmap bitmap = new Bitmap(largura, altura))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(boundsX, boundsY, 0, 0, size);
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
        }

    }
}
