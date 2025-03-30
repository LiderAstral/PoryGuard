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
        private int boundsX;
        private int boundsY;
        
        public Monitor() 
        { 
            foreach(Screen screen in Screen.AllScreens)
            {
                if (screen.Primary)
                {
                    nome = screen.DeviceName;
                    frameRate = 30; // Definir para 30 FPS para fins de latência e precisão científica
                    altura = screen.Bounds.Height;
                    largura = screen.Bounds.Width;
                    boundsX = screen.Bounds.X;
                    boundsY = screen.Bounds.Y;
                }
            }
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
