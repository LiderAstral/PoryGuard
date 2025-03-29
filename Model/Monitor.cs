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
        private int id;
        private string nome;
        private int frameRate;
        private int altura;
        private int largura;
        private int boundsX;
        private int boundsY;
        
        public Monitor() 
        { 
            Screen screen = Screen.AllScreens[0];
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_VideoController");
            id = 0;
            foreach (ManagementObject obj in searcher.Get())
            {
                frameRate = int.Parse(obj["CurrentRefreshRate"].ToString());
                break;
                id++;
            }
            nome = screen.DeviceName;
            altura = screen.Bounds.Height;
            largura = screen.Bounds.Width;
            boundsX = screen.Bounds.X;
            boundsY = screen.Bounds.Y;
        }
        public int GetId()
        { 
            return id; 
        }
        public string GetNome()
        {
            return nome;
        }
        public int GetFrameRate()
        {
            return frameRate;
        }
        public int GetAltura()
        {
            return altura;
        }
        public int GetLargura()
        {
            return largura;
        }
        public int GetBoundsX()
        {
            return boundsX;
        }
        public int GetBoundsY()
        {
            return boundsY;
        }
    }
}
