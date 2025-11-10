using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Syncfusion.Licensing;

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
        static void Main(string[] args)
        {
           
            //Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/Vkd+XU9FcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3tSd0VnWHdecHZVRGRVUE91Xg==");
            
            // Necessário para garantir o funcionamento do método Screen para telas
            // com diferentes resoluções
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new PoryGuard();
            if (args.Length > 0 && args[0] == "--minimizado")
            {
                form.WindowState = FormWindowState.Minimized;
                form.Shown += (s, e) => form.Hide();
            }
            Application.Run(form);
        }
    }
}
