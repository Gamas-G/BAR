using System;
using System.ComponentModel;
using System.Windows.Forms;

/*using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace BAR
{
    public partial class ChangeServidor : Form
    {
        string ipCache;
        string carpCache;
        string ip;
        string nombreServidor;
        public bool vent;
        public ChangeServidor()
        {
            InitializeComponent();
            ip = GetIp();
            nombreServidor = Environment.UserName;
        }

        private void ChangeServidor_Load(object sender, EventArgs e)
        {

            LabelServidor.Text = Properties.Settings.Default.Servidor;
            funcBotones();
            if((bool)Properties.Settings.Default["Predeterminado"] != false)
            {
                CheckBoxServPredeterminado.Checked = true;
            }
        }
        private void funcBotones()
        {
            if(!vent)
            {
                button1.Visible = false;
                button2.Visible = false;
                ButtonChangeServidor.Visible = true;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = true;
                ButtonChangeServidor.Visible = false;
            }
        }

        private void ButtonChangeServidor_Click(object sender, EventArgs e)
        {
            ChangeServ();

        }

        private void ChangeServ()
        {
            if (TextBoxIP.Text == "" || TextBoxCarp.Text == "" || TextBoxPassword.Text == "" || TextBoxConfPass.Text == "") return;


            Properties.Settings.Default["NameServidor"] = TextBoxNombServ.Text;
            Properties.Settings.Default["Servidor"] = TextBoxIP.Text;
            Properties.Settings.Default["PwdServidor"] = TextBoxConfPass.Text;
            Properties.Settings.Default["Configuracion"] = true;
            Properties.Settings.Default["CarpetaServ"] = TextBoxCarp.Text;

            this.Close();
        }

        private string GetIp()
        {
            string myHost = System.Net.Dns.GetHostName();
            string myIP = null;

            for (int i = 0; i <= System.Net.Dns.GetHostEntry(myHost).AddressList.Length - 1; i++)
            {
                if (System.Net.Dns.GetHostEntry(myHost).AddressList[i].IsIPv6LinkLocal == false)
                {
                    myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[i].ToString();
                }
            }
            return myIP;
        }

        private void TextBoxIP_Validating(object sender, CancelEventArgs e)
        {
            if (TextBoxIP.Text == "")
            {
                errorProvider1.SetError(TextBoxIP, "");
                return;
            }
            string expresion = @"\A[1-9]{3}(.)[0-9]{1,3}(.)[0-9]{1,3}(.)[0-9]{1,3}\Z"; //Estructuracion de la expresion regular, obteniendo una validacion para las IPs de la Red de uso laboral
            System.Text.RegularExpressions.Regex auto = new System.Text.RegularExpressions.Regex(expresion); //Se invoca la clase 'RegularExpressions' en el mismo metodo ya que solo se utiliza una vez no se coloca desde el inicio del codigo.

            if (!auto.IsMatch(this.TextBoxIP.Text)) //Validamos si la IP cumple con nuestra expresion regular, la libreria tira por default 'TRUE', asi que si es diferente que osea 'FALSE'
            {
                errorProvider1.SetError(TextBoxIP, "IP INCORRECTA");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(TextBoxIP, "");
        }

        private void TextBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CheckBoxServPredeterminado_CheckedChanged(object sender, EventArgs e)
        {
            Predeterminado();
        }
        private void Predeterminado()
        {
            if (CheckBoxServPredeterminado.Checked == true)
            {
                ipCache = TextBoxIP.Text;
                carpCache = TextBoxCarp.Text;

                TextBoxNombServ.Text = nombreServidor;
                TextBoxIP.Text = ip;
                TextBoxCarp.Text = "servLocal";

                LabelIpLocal.Text = "IP de la maquina local";
                TextBoxNombServ.ReadOnly = true;
                TextBoxIP.ReadOnly = true;
                TextBoxCarp.ReadOnly = true;

                Properties.Settings.Default["Predeterminado"] = true;
            }
            else
            {
                TextBoxNombServ.Text = "";
                TextBoxIP.Text = ipCache;
                TextBoxCarp.Text = carpCache;
                LabelIpLocal.Text = "Ingrese el nuevo servidor";
                TextBoxNombServ.ReadOnly = false;
                TextBoxIP.ReadOnly = false;
                TextBoxCarp.ReadOnly = false;

                Properties.Settings.Default["Predeterminado"] = false;
            }
        }

        private void TextBoxConfPass_Validating(object sender, CancelEventArgs e)
        {
            if (TextBoxConfPass.Text == "")
            {
                errorProvider1.SetError(TextBoxConfPass, "");
                return;
            }
            else if (TextBoxConfPass.Text != TextBoxPassword.Text)
            {
                errorProvider1.SetError(TextBoxConfPass, "La contraseña no coincide");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TextBoxConfPass, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeServ();
        }
    }
}
