using System;
using System.Windows.Forms;

/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace BAR.BAR
{
    public partial class IniConfServidor : Form
    {
        string mensaje = "Bienvenido a BAR\nPara continuar debera establecer un servidor\nPuede ingresar uno de su preferencia o usar la opcion predeterminada\n¿Desea usar la opcion predeterminada?\n'Si' para continuar 'No' para establecer un servidor.";
        public IniConfServidor()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
            label1.Text = mensaje;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Predeterminado"] = true;
            ChangeServidor chang = new ChangeServidor();
            chang.vent = false;
            chang.ShowDialog();
            Properties.Settings.Default.Save();
        }

        private void ButtonNoConfServ_Click(object sender, EventArgs e)
        {
            ChangeServidor chang = new ChangeServidor();
            chang.vent = false;
            chang.ShowDialog();
            Properties.Settings.Default.Save();
        }

        private void Cerrar(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
