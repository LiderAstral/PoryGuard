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
        CapturaDeTela capturaDeTela;
        public PoryGuard()
        {
            InitializeComponent();
            IniciaExecucao();
        }
        private void IniciaExecucao()
        {
            
        }

        private void cbxLigado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLigado.Checked)
            {
                capturaDeTela = new CapturaDeTela();
            }
            else
            {
                capturaDeTela.PararCaptura();
                capturaDeTela = null;
            }
        }
    }
}
