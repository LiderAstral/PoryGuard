using PoryGuard.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryGuard.Controller
{
    internal class Censura
    {
        private OverlayCensura overlayCensura = new OverlayCensura();
        public Censura()
        {
            overlayCensura.Show();
        }
        public void AddRectangle(int x, int y, int width, int height, Color color)
        {
            overlayCensura.AddRectangle(x, y, width, height, color);
        }
        /// Limpa todos os retângulos desenhados.
        public void ClearRectangles()
        {
            overlayCensura.ClearRectangles();
        }
        public void Redesenhar()
        {
            overlayCensura.Redesenhar();
        }
        public void EncerraCensura()
        {
            overlayCensura.Close();
        }   
    }
}
