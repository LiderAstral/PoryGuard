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
        // Overlay único compartilhado entre todas as instâncias
        private static OverlayCensura overlayCompartilhado = null;
        private static int contadorInstancias = 0;
        private static readonly object lockStatic = new object();

        // Lista de retângulos específica desta instância
        private List<(Rectangle rect, Color color)> retangulosLocais = new List<(Rectangle rect, Color color)>();

        public Censura()
        {
            lock (lockStatic)
            {
                contadorInstancias++;

                // Cria o overlay apenas na primeira instância
                if (overlayCompartilhado == null)
                {
                    overlayCompartilhado = new OverlayCensura();
                    overlayCompartilhado.Show();
                }
            }
        }

        public void AddRectangle(int x, int y, int width, int height, Color color)
        {
            lock (lockStatic)
            {
                retangulosLocais.Add((new Rectangle(x, y, width, height), color));
            }
        }

        public void ClearRectangles()
        {
            lock (lockStatic)
            {
                retangulosLocais.Clear();
            }
        }

        public void Redesenhar()
        {
            if (overlayCompartilhado != null && !overlayCompartilhado.IsDisposed)
            {
                lock (lockStatic)
                {
                    // Limpa o overlay compartilhado
                    overlayCompartilhado.ClearRectangles();

                    // Adiciona os retângulos desta instância ao overlay
                    foreach (var (rect, color) in retangulosLocais)
                    {
                        overlayCompartilhado.AddRectangle(rect.X, rect.Y, rect.Width, rect.Height, color);
                    }

                    // Redesenha o overlay
                    overlayCompartilhado.Redesenhar();
                }
            }
        }

        public void EncerraCensura()
        {
            lock (lockStatic)
            {
                contadorInstancias--;

                // Limpa os retângulos desta instância
                retangulosLocais.Clear();

                // Se esta é a última instância, fecha o overlay
                if (contadorInstancias <= 0 && overlayCompartilhado != null)
                {
                    overlayCompartilhado.EncerraCensura();
                    overlayCompartilhado = null;

                    contadorInstancias = 0;
                }
            }
        }
        public static void FecharOverlayGlobal()
        {
            lock (lockStatic)
            {
                if (overlayCompartilhado != null)
                {
                    overlayCompartilhado.EncerraCensura();
                    overlayCompartilhado = null;
                    contadorInstancias = 0;
                }
            }
        }
    }
}