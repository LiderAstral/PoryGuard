using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        [DllImport("user32.dll")]
        static extern bool SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        [DllImport("user32.dll")]
        static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, uint crKey, ref BLENDFUNCTION pblend, uint dwFlags);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        static extern bool DeleteDC(IntPtr hdc);

        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        const int GWL_EXSTYLE = -20;
        const uint WS_EX_LAYERED = 0x80000;
        const uint WS_EX_TRANSPARENT = 0x20;
        const uint WS_EX_TOOLWINDOW = 0x00000080;
        const uint WDA_EXCLUDEFROMCAPTURE = 0x11;
        const uint ULW_ALPHA = 0x02;
        const byte AC_SRC_OVER = 0x00;
        const byte AC_SRC_ALPHA = 0x01;

        private static readonly object lockObject = new object();

        // Lista de retângulos coloridos
        private List<(Rectangle rect, Color color)> rectangles = new List<(Rectangle rect, Color color)>();

        // Garante que a janela não apareça no Alt+Tab
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= (int)(WS_EX_TOOLWINDOW | WS_EX_LAYERED);
                return cp;
            }
        }

        // Ignora qualquer tentativa de fechar a janela
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        // Ignora Alt+F4
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_CLOSE)
                return;
            base.WndProc(ref m);
        }

        public OverlayCensura()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            WindowState = FormWindowState.Maximized;
            Bounds = Screen.PrimaryScreen.Bounds;

            // Remove o background padrão
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.Opaque, true);

            Load += OverlayCensura_Load;
        }

        private void OverlayCensura_Load(object sender, EventArgs e)
        {
            // Configura como janela em camadas para suporte a alpha real
            uint exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);

            // Oculta da captura de tela
            SetWindowDisplayAffinity(this.Handle, WDA_EXCLUDEFROMCAPTURE);

            // Atualiza a janela pela primeira vez
            UpdateLayeredWindowContent();
        }

        private void UpdateLayeredWindowContent()
        {
            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = CreateCompatibleBitmap(screenDc, this.Width, this.Height);
            IntPtr hOldBitmap = SelectObject(memDc, hBitmap);

            using (Graphics g = Graphics.FromHdc(memDc))
            {
                // Limpa com transparente total
                g.Clear(Color.Transparent);

                // Configura para qualidade alta
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingMode = CompositingMode.SourceOver;

                lock (lockObject)
                {
                    // Desenha todos os retângulos com suas respectivas transparências
                    foreach (var (rect, color) in rectangles)
                    {
                        using (SolidBrush brush = new SolidBrush(color))
                        {
                            g.FillRectangle(brush, rect);
                        }
                    }
                }
            }

            // Configuração do blend para transparência alpha
            BLENDFUNCTION blend = new BLENDFUNCTION
            {
                BlendOp = AC_SRC_OVER,
                BlendFlags = 0,
                SourceConstantAlpha = 255, // Usa alpha dos pixels individuais
                AlphaFormat = AC_SRC_ALPHA
            };

            Point ptZero = new Point(0, 0);
            Point ptPos = new Point(this.Left, this.Top);
            Size szSize = new Size(this.Width, this.Height);

            // Atualiza a janela com o conteúdo alpha
            UpdateLayeredWindow(this.Handle, screenDc, ref ptPos, ref szSize, memDc, ref ptZero, 0, ref blend, ULW_ALPHA);

            // Limpa recursos
            SelectObject(memDc, hOldBitmap);
            DeleteObject(hBitmap);
            DeleteDC(memDc);
            ReleaseDC(IntPtr.Zero, screenDc);
        }

        // Sobrescreve o OnPaint para não fazer nada
        protected override void OnPaint(PaintEventArgs e)
        {

        }

        
        public void AddRectangle(int x, int y, int width, int height, Color color)
        {
            lock (lockObject)
            {
                rectangles.Add((new Rectangle(x, y, width, height), color));
            }
        }

        /// Limpa todos os retângulos desenhados
        public void ClearRectangles()
        {
            lock (lockObject)
            {
                rectangles.Clear();
            }
        }

        public void Redesenhar()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)Redesenhar);
                return;
            }
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                UpdateLayeredWindowContent();
            }
        }

        public void EncerraCensura()
        {
            ClearRectangles();
            lock (lockObject)
            {
                if (!this.IsDisposed)
                {
                    this.Hide();
                    this.Close();
                }
            }
        }
    }
}