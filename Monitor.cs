using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace PoryGuard
{
    class Monitor
    {
        private string nome;
        private int frameRate;
        private int altura;
        private int largura;
        
        public Monitor() 
        { 
            Screen screen = Screen.AllScreens[0];
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_VideoController");

            foreach (ManagementObject obj in searcher.Get())
            {
                frameRate = int.Parse(obj["CurrentRefreshRate"].ToString());
                break;
            }
            nome = screen.DeviceName;
            altura = screen.Bounds.Height;
            largura = screen.Bounds.Width;
            Console.WriteLine($"Monitor: {nome}");
            Console.WriteLine($"Taxa de atualização: {frameRate} Hz");
            Console.WriteLine($"Resolução: {largura}x{altura}");
        }
        public string GetNome()
        {
            return nome;
        }
        public int GetFrameRate()
        {
            return frameRate;
        }
    }
}
