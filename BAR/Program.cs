using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAR
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (((bool)Properties.Settings.Default["Configuracion"] != false))
            {
                Application.Run(new Inicio());
            }
            else
            {
                if (new BAR.IniConfServidor().ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Inicio());
                }
            }
        }
    }
}
