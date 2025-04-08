using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoryGuard.Model
{
    public partial class OverlayCensura : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        const int GWL_EXSTYLE = -20;
        const uint WS_EX_LAYERED = 0x80000;
        const uint WS_EX_TRANSPARENT = 0x20;
        public OverlayCensura()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = Color.Magenta;
            TransparencyKey = Color.Magenta;

            // Cobre a tela inteira
            Bounds = Screen.PrimaryScreen.Bounds;

            Load += (s, e) =>
            {
                // Torna a janela clicável
                uint exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
                SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);
            };
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Desenha um pixel (como um quadrado pequeno) em (50,50) com cor preta
            e.Graphics.FillRectangle(Brushes.Black, 50, 50, 50, 50);
            base.OnPaint(e);
        }
    }
}
