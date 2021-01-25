using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BAR
{
    public partial class Inicio : Form
    {
        string IPservidor; //Variable donde se alamcena la IP de la PC Servidor
        string carpServidor;
        string pwdServidor;
        string usuarioServidor;
        string usuario = string.Empty;

        public Inicio()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            ComboBoxTipoEscaneo.Text = "Ligero";

            usuarioServidor = (string)Properties.Settings.Default["NameServidor"];
            IPservidor      = (string) Properties.Settings.Default["Servidor"];
            pwdServidor     = (string) Properties.Settings.Default["PwdServidor"];
            carpServidor    = (string) Properties.Settings.Default["CarpetaServ"];


            LabelServidor.Text = IPservidor;
            LabelCarpetaServidor.Text = carpServidor;
        }


        private void ButtonIniciarConxSSH_Click(object sender, EventArgs e)
        {
            if (TextBoxUserName.Text == "" || TextBoxIP.Text == "" || TextBoxPassword.Text == "" || TextBoxConfPassword.Text == "") return;

            usuario = TextBoxUserName.Text;
            ButtonIniciarConxSSH.Enabled = false;
            LabelEspere.Visible = true;
            if (ComboBoxTipoEscaneo.Text == "Profundo")
            {
                LabelProfundo1.Visible = true;
                LabelProfundo2.Visible = true;
            }

            try
            {
                AbrirConexion();

                var (commandPeticion, commandRobocopy) = Rutas(); //El metodo ruta retorna dos tipos de variables que son los comandos estructurados para su ejecucion
                StreamWriter cP = new StreamWriter(@"\\" + IPservidor + @"\" + carpServidor + @"\Commands\Peticion.bat"); //Escritura de un archivo BATCH almacenadoo en el servidor

                cP.Write(commandPeticion);
                cP.Close();

                StreamWriter cG = new StreamWriter(@"\\" + IPservidor + @"\" + carpServidor + @"\Commands\guapo.bat"); //Escritura de archivo BATCH almacenado en el servidor

                cG.Write(commandRobocopy);
                cG.Close();


                string comando =
                    "@echo Gamas" + Environment.NewLine +
                    "plink -ssh -P 22 " + "\"" + usuario + "\"" + "@" + TextBoxIP.Text + " -pw " + TextBoxConfPassword.Text + @" \\" + IPservidor + @"\" + carpServidor + @"\Commands\Peticion.bat"; // Comando que sirve para la conexion a la PC Servidor

                string cerrar =
                    @"DEL \\" + IPservidor + @"\" + carpServidor + @"\Commands /Q" + Environment.NewLine +
                    @"DEL \\" + IPservidor + @"\" + carpServidor + @"\Espejo /Q" + Environment.NewLine +
                    @"DEL \\" + IPservidor + @"\" + carpServidor + @"\Paths /Q" + Environment.NewLine +
                    @"DEL \\" + IPservidor + @"\" + carpServidor + @"\validacion.txt /Q" + Environment.NewLine +
                    @"RD \\"  + IPservidor + @"\" + carpServidor + @"\Espejo /S /Q" + Environment.NewLine +
                    @"net use \\" + IPservidor + @"\" + carpServidor + " /delete";                          //Comando para la eliminacion de archivos, comandos y el cierre de la carpeta servidor

                File.WriteAllText("Cerrar.bat", cerrar); //Guardado en la carpeta del proyecto en la "bin" para ser mas especificos

                File.WriteAllText("venga.bat", comando);//Guardado en la carpeta del proyecto en la "bin" para ser mas especificos
                FileInfo file = new FileInfo("venga.bat"); //Obtencion del archivo, para la ejecucion de una validacion, esto debido a si ocurrio un fallo y no se pudo crear el archivo no accedera a la conexion evitando un posible fallo
                if (file.Exists) // Validacion del archivo
                {
                    inicio();//Ejecucion del metodo de nombre 'Inicio'
                }

            }
            catch (Exception) //Catch para saber el punto de error y habilitando todos los controles del programa
            {
                MessageBox.Show("Fallo en la conexion a la carpeta Servidor. Verifique su RED");
                ButtonIniciarConxSSH.Enabled = true;
                LabelEspere.Visible = false;
                LabelProfundo1.Visible = false;
                LabelProfundo2.Visible = false;
            }


            ButtonIniciarConxSSH.Enabled = true;
            LabelEspere.Visible = false;
            MessageBox.Show("Listo");
        }

        void AbrirConexion()//Metodo 'AbrirConexion' Metodo desuma importancia
        {
            try
            {
                string co = //Comando para el acceso a la carpeta que se encuentra en el servidor. NOTA: es importante este comando ya que sin este no optiene acceso y los comandos que son de suma importancia para el programa no se ejecutaran
                    @"@echo Gamas" + Environment.NewLine +
                    @"net use \\" + IPservidor + @"\" + carpServidor + " /user:\"" + usuarioServidor + "\" " + pwdServidor + Environment.NewLine + "PAUSE";

                StreamWriter cP = new StreamWriter("AbrirConexion.bat"); //Lo guardamos en un archivo BATCH en la carpeta del programa para que se ejecute sin tener que hace un cambio en la ruta de la ventana, evitando ciertas dificultades en la ruta

                cP.Write(co);
                cP.Close();

                Process D = new Process();
                D.StartInfo.FileName = "AbrirConexion.bat"; //Ejecutamos el comando para tener la conexion de la carpeta abierta y evitar problemas (Se mostrara un cuadro donde la conexion fue exitosa o no)
                D.Start();

                D.WaitForExit();//El programa espera a que la conexion se ejecute dando el tiempo suficiente para leer los procesos que ocurrieron
            }
            catch (Exception)
            {
                MessageBox.Show("Error al abrir conexión", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);//Un catch para evitar posibles fallos en el programa
            }
        }

        (string commandPeticion, string commandRobocopy) Rutas() //Metodo 'Rutas' estructura los comandos a ejecutar dependiendo del tipo de escaneo
        {
            string comPeticion = string.Empty; //Variable de almacenamiento para el comando Peticion, tiene la utilidd de ejecutar un 'FORFILES' para la obtencion de las rutas de la pc cliente. Los archivos estan filtrados
            string comRobo = string.Empty; //Variable de almacenamiento para el comando 'guapo', tiene la utilidad de ejecuta los 'ROBOCOPYs' para la extraccion de los archivos filtrados
            switch (ComboBoxTipoEscaneo.Text)
            {
                case "Ligero":
                    CommLigeros(out comPeticion, out comRobo);
                    break;
                case "Profundo":
                    CommProfundos(out comPeticion, out comRobo);
                    break;
                default:
                    MessageBox.Show("Problemas en el Switch");
                    break;
            }
            return (comPeticion, comRobo); //Aquí se retornan las dos variables al mismo tiempo, logrando una agilizacion del metodo y no acudir a la concurrencia
        }
        private void CommLigeros(out string comPeticon, out string comRobo)
        {
            comPeticon = //Estructuracion de los comandos FORFILE, todo esto en la opcion de Escaneo Ligero
                   @"@echo Gamas" + Environment.NewLine +
                   "CHCP 65001" + Environment.NewLine + //Cambio de pagina de lenguaje para la obtencion correctas de las rutas, permitiendo caracteres con tildes y ñ
                   @"net use \\" + IPservidor + @"\" + carpServidor + " /user:\"" + usuarioServidor + "\" " + pwdServidor + Environment.NewLine + //Comando para la que la computadora PC cliente abra la conexion al servidor
                   @"@echo TRUE > \\" + IPservidor + @"\" + carpServidor + @"\validacion.txt" + Environment.NewLine + //Archivo que funciona para la validacion de que la conexion fue exitosa en la pc Cliente y se concluyeron todos los comandos anteriores
                   @"MD ..\Espejo" + Environment.NewLine + //Creacion de la carpeta Espejo dentro del Servidor, donde se almacenaran los archivos filtrados en el Servidor

                   //Carpeta Downloads
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Downloads /S /M *.txt /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null > \\"   + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Downloads /S /M *.pdf /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\"  + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Downloads /S /M *.docx /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Downloads /S /M *.xlsx /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   Environment.NewLine +
                   //Carpeta Documents
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Documents /S /M *.txt /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\"  + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Documents /S /M *.pdf /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\"  + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Documents /S /M *.docx /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Documents /S /M *.xlsx /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   Environment.NewLine +
                   //Carpeta Desktop
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Desktop /S /M *.txt /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\"  + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Desktop /S /M *.pdf /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\"  + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Desktop /S /M *.docx /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + @"\Desktop /S /M *.xlsx /C " + "\"" + "cmd /c echo @PATH" + "\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   Environment.NewLine +
                   @"\\" + IPservidor + @"\" + carpServidor + @"\Commands\guapo.bat" + Environment.NewLine + //Lllamada a un segundo metodo BATCH para su ejecucion
                   "CHCP 850"; //Regresando a su pagina de lenguajue base de la PC

                    //Creacion de .bat de Robocopy Ligero
            comRobo = //Comando del ROBOCOPY con filtrado de archivos especificos todo esto en la opcion de escaner Ligero
                "@echo Gamas" + Environment.NewLine +
                @"ROBOCOPY /S \\" + TextBoxIP.Text + @"\Users\\" + "\"" + usuario + "\"" + @"\Downloads \\" + IPservidor + @"\" + carpServidor + @"\Espejo\ *.txt *.pdf *.docx *.xlsx" + Environment.NewLine +
                @"ROBOCOPY /S \\" + TextBoxIP.Text + @"\Users\\" + "\"" + usuario + "\"" + @"\Documents \\" + IPservidor + @"\" + carpServidor + @"\Espejo\ *.txt *.pdf *.docx *.xlsx" + Environment.NewLine +
                @"ROBOCOPY /S \\" + TextBoxIP.Text + @"\Users\\" + "\"" + usuario + "\"" + @"\Desktop \\"   + IPservidor + @"\" + carpServidor + @"\Espejo\ *.txt *.pdf *.docx *.xlsx";
        }
        private void CommProfundos(out string comPeticon, out string comRobo)
        {
            comPeticon = //Estructuracion de los comandos FORFILE, todo esto en la opcion de Escaneo Ligero
                   @"@echo Gamas" + Environment.NewLine +
                   "CHCP 65001" + Environment.NewLine + //Cambio de pagina de lenguaje para la obtencion correctas de las rutas, permitiendoi caracteres con tildes y ñ
                   @"net use \\" + IPservidor + @"\" + carpServidor + " /user:\"" + usuarioServidor + "\" " + pwdServidor + Environment.NewLine + //Comando para la apertura a la carpeta Servidor
                   @"@echo TRUE > \\" + IPservidor + @"\" + carpServidor + @"\validacion.txt" + Environment.NewLine + //Archivo que funciona para la validacion de que la conexion fue exitosa en la pc Cliente y se concluyeron todos los comandos anteriores
                   @"MD ..\Espejo" + Environment.NewLine + //Creacion de la carpeta Espejo dentro del Servidor, donde se almacenaran los archivos filtrados en el Servidor

                   //Carpeta Downloads
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + " /S /M *.txt /C " + "\"cmd /c echo @PATH\"" + @" 2>null > \\"   + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + " /S /M *.pdf /C " + "\"cmd /c echo @PATH\"" + @" 2>null >> \\"  + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + " /S /M *.docx /C " + "\"cmd /c echo @PATH\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +
                   @"FORFILES /P C:\Users\\" + "\"" + usuario + "\"" + " /S /M *.xlsx /C " + "\"cmd /c echo @PATH\"" + @" 2>null >> \\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt" + Environment.NewLine +

                   @"\\" + IPservidor + @"\" + carpServidor + @"\Commands\guapo.bat" + Environment.NewLine + // Ejecucion de un segundo BATCH para la obtencion de los archivos, Conexion de un BATCH a otro BATCH
                   "CHCP 850"; //Cambio de pagina a su pagina de lenguaje predefinida
            comRobo =  //Comando ROBOCOPY parra la estraccion de los archivos exclusivamente '.txt, .pdf, .docx, .xlsx' con la unica diferencia que el escane es profundo y optiene una cantidad de archivo mucho mas grande
                "@echo Gamas" + Environment.NewLine +
                @"ROBOCOPY /S \\" + TextBoxIP.Text + @"\Users\\" + "\"" + usuario + "\"" + @" \\" + IPservidor + @"\" + carpServidor + @"\Espejo\ *.txt *.pdf *docx *xlsx"; //Se ve claramente los archivos a pedir. Esos son los filtrados
        }

        void inicio() //Metodo Inicio, este metodo es la columna vertebral del programa es donde inicia la ejecucion de comandos antes creados
        {
            try//Se captura en un TRY por si ocurre algun error en la ejecucion, en la red del la PC o en el Servidor
            {
                Process p = new Process(); //Se invoca a la clase Process, esta nos ayuda a ejecutar archivos, ejecutables y en nuestro casos archivos BATCH
                p.StartInfo.FileName = "venga.bat"; //Llamamos a nuestro archivo donde contiene la conexion a la PC que deceamos escanear junto con los aprametros necesarios que usted ingreso directamente, junto de este coontiene una peticion al comando PETICION que es el que inicia con la extracciond e archivos
                p.Start();//Aqui ejecutamos el archivo
                p.WaitForExit();//Aqui espera a que se ejecuten todos los comandos que son necesarios, finalizacion en la obtencion de los archivos
                FileInfo ARC = new FileInfo(@"\\" + IPservidor + @"\" + carpServidor + @"\validacion.txt");//Obtenemos informacion del archivo que nos ayudara saber si creacion de los comandos fue exitosa
                if (ARC.Exists)//Si existe dicho archivos todo esta en orden
                {
                    Form1 form1 = new Form1(); //Instanciando el Form ventanaEscaneo y automaticamente se abrira mostrando una interfaz
                    form1.IPservidor = IPservidor;
                    form1.carpServidor = carpServidor;
                    form1.usuarioServidor = usuarioServidor;
                    this.Hide();//Escondemos en la que trabajamos
                    form1.Show();//Mostramos la nueva ventana
                }
                else
                {
                    MessageBox.Show("Problemas al hacer conexión verifique que haya comunicación, ya que no se encontro el archivo validacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);//Mensaje para hacer saber que hubo un fallo en la comunicacion y el archivo no se creo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ButtonIniciarConxSSH.Enabled = true;
                LabelEspere.Visible = false;
                LabelProfundo1.Visible = false;
                LabelProfundo2.Visible = false;
            }

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
                errorProvider1.SetError(TextBoxIP,"IP INCORRECTA");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(TextBoxIP, "");
        }

        private void TextBoxConfPassword_Validating(object sender, CancelEventArgs e)
        {
            if(TextBoxConfPassword.Text == "")
            {
                errorProvider1.SetError(TextBoxConfPassword, "");
                return;
            }
            else if (TextBoxConfPassword.Text != TextBoxPassword.Text)
            {
                errorProvider1.SetError(TextBoxConfPassword, "La contraseña no coincide");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TextBoxConfPassword, "");
            }
        }

        private void ConfServidor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeServidor chang = new ChangeServidor();
            chang.vent = true;
            chang.ShowDialog();

            //Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
