﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace PoryGuard.Model
{
    public partial class OverlayCensura : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern bool SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        const int GWL_EXSTYLE = -20;
        const uint WS_EX_LAYERED = 0x80000;
        const uint WS_EX_TRANSPARENT = 0x20;
        const uint WS_EX_TOOLWINDOW = 0x00000080;

        const uint WDA_EXCLUDEFROMCAPTURE = 0x11;
        private static readonly object lockObject = new object();

        // Lista de retângulos coloridos
        private List<(Rectangle rect, Color color)> rectangles = new List<(Rectangle rect, Color color)>();

        // Garante que a janela não apareça no Alt+Tab
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= (int)(WS_EX_TOOLWINDOW);
                return cp;
            }
        }

        // Ignora qualquer tentativa de fechar a janela
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true; // Impede que o usuário feche
        }

        // Também ignora mensagens de encerramento (Alt+F4)
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_CLOSE)
                return; // Ignora o Alt+F4
            base.WndProc(ref m);
        }

        public OverlayCensura()
        {
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = Color.Magenta;
            TransparencyKey = Color.Magenta;
            WindowState = FormWindowState.Maximized;
            Bounds = Screen.PrimaryScreen.Bounds;

            Load += (s, e) =>
            {
                uint exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
                SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);

                // Oculta da captura de tela
                SetWindowDisplayAffinity(this.Handle, WDA_EXCLUDEFROMCAPTURE);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (lockObject)
            {
                foreach (var (rect, color) in rectangles)
                {
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            }

            base.OnPaint(e);
        }
        /// Adiciona um novo retângulo para ser desenhado.
        public void AddRectangle(int x, int y, int width, int height, Color color)
        {
            lock (lockObject)
            {
                rectangles.Add((new Rectangle(x, y, width, height), color));
            }
        }
        // Limpa todos os retângulos desenhados.
        public void ClearRectangles()
        {
            lock (lockObject)
            {
                rectangles.Clear();
            }
        }
        public void Redesenhar()
        {
            lock (lockObject)
            {
                Invalidate();
            }
        }
        public void EncerraCensura()
        {
            ClearRectangles();
            Redesenhar();
            lock (lockObject)
            {
                this.Close();
            }
        }

        private void OverlayCensura_Load(object sender, EventArgs e)
        {

        }
    }
}
