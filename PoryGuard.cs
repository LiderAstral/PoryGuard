using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using PoryGuard.Controller;

namespace PoryGuard
{
    public partial class PoryGuard: Form
    {
        public PoryGuard()
        {
            InitializeComponent();
            IniciaExecucao();
        }
        private void IniciaExecucao()
        {
            CapturaDeTela capturaDeTela = new CapturaDeTela();
        }

    }
}
