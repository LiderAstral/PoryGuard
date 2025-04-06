using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PoryGuard
{
    

    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Necessário para garantir o funcionamento do método Screen para telas
            // com diferentes resoluções
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PoryGuard());
        }
    }
}
