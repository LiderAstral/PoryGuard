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

namespace PoryGuard
{
    public partial class PoryGuard: Form
    {
        public PoryGuard()
        { 
            InitializeComponent();
            
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_VideoController");
            /*
            foreach (Screen screen in Screen.AllScreens)
            {
                Console.WriteLine($"Monitor: {screen.DeviceName}");
                Console.WriteLine($"Resolução: {screen.Bounds.Width}x{screen.Bounds.Height}");
                Console.WriteLine($"Principal: {screen.Primary}");
                Console.WriteLine($"Área de Trabalho: {screen.WorkingArea}");
                Console.WriteLine($"Escala: {screen.Bounds.Width / (double)screen.WorkingArea.Width * 100}%");
                Console.WriteLine(new string('-', 40));
                var bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
                Graphics.FromImage(bitmap).CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size);
                Color pixelColor = bitmap.GetPixel(100, 100);
                Console.WriteLine("Cor do pixel na coordenada (100, 100):");
                Console.WriteLine($"- Red: {pixelColor.R}");
                Console.WriteLine($"- Green: {pixelColor.G}");
                Console.WriteLine($"- Blue: {pixelColor.B}");
                Console.WriteLine($"- Alpha: {pixelColor.A}");
            }*/
            Monitor monitor = new Monitor();
        }
    }
}
