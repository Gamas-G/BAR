using Code7248.word_reader;
using ExcelDataReader;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAR
{
    public partial class Form1 : Form
    {
        public string IPservidor;//Variable para el cambio de servidor de Almacenamiento

        //Zona de variables
        string[] a;//Arreglo para el alamacenamiento de 
        public string usuarioServidor;//Variable publica donde se almacena el  nombre del usuario donde se esta trabajando ingresado un label
        public string carpServidor;
        private string findWord = string.Empty;//Variable donde se alamacenara la palabra sin tildes y sin ñ y todo en minusculas
        private int contArchivoRelac; //Contador de Archivos relacionados
        private int contadorAdventerncias; //Contador para mostrar el numero de advertencias
        private string pathGeneric = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA\\";
        delegate void delegateControl(Control control, string inf);
        private delegateControl control;

        //Zona de Instancias
        //private FileInfo pdf;
        //private Process proceso = new Process();
        private ArrayList coleccion = new ArrayList();//ArrayList Donde se almacenan todas las rutas obtenidas en los Txt Paths que se almacenan en la Carpeta 'GUAPA' en la ruta C:\Users\Usuario, las cuales seran eliminadas previamente

        public Form1()
        {
            InitializeComponent();
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            {
                if (TextBoxPalabra.Text == "") return;

                Buscar.Enabled = false;
                labelEspere.Visible = true;
                labelTrabajandoSobre.Visible = true;
                buttonClean.Enabled = true;

                await Start();

                Buscar.Enabled = true;
                labelEspere.Visible = false;
                labelTrabajandoSobre.Visible = false;
                buttonClean.Enabled = false;
            }
        }
        private async Task Start()
        {
            try
            {
                findWord = CleanCharacteres(TextBoxPalabra.Text).ToLower();//Limpiamos la palabra ingresada
                a = File.ReadAllLines(@"\\" + IPservidor + @"\" + carpServidor + @"\Paths\pathFiles.txt");//Leemos los TXT que estan almacenadas en el servidor
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA")) { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA"); }
                await CleanPaths();//Ingresamos al metodo CleanPaths
                await FindFolder();//Meotod FindFolder Metodo donde se ejecuta todo el proceso
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task FindFolder()
        {
            //Metodo FindFolder Aqui se efectua el trabajo de la lectura dentro del archivo y las coincidencias con la palabra ingresada
            progressBarArchivos.Visible = true;
            FileInfo rutaArchivo = null;
            dataGridViewArchivos.Rows.Add("RESULTADO(S) de \"" + TextBoxPalabra.Text + "\"", "RESULTADO(S)", "RESULTADO(S)", "RESULTADO(S)", "RESULTADO(S)");//Ingresamos una linea para separar las busquedas
            progressBarArchivos.Maximum = coleccion.Count;//Insertamos el tamaño del progressBar con el numero de datyos que tiene el arrayList
            foreach (var item in coleccion) //Iniciamos un clico del foreache para escanear cada archvio
            {
                rutaArchivo = new FileInfo(item.ToString());
                await Working(rutaArchivo);//El metodo Working es quien lleva la tarea pesada
                progressBarArchivos.PerformStep();
            }
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA\\csvFile.csv");
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA\\PdfFile.txt");
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA\\WordFile.txt");
            Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\GUAPA");
            progressBarArchivos.Visible = false;
            labelContArchivosRelacionados.Text = contArchivoRelac.ToString();
            labelContAdvertencias.Text = this.contadorAdventerncias.ToString();
        }

        private async Task Working(FileInfo infFile)
        {
            string archivo = CleanCharacteres(infFile.Name).ToLower();//Limpiamos todos los caracteres que contengas tildes o tenga ñ. Este sirve para hacer la comparacion en la ruta, si coincide con el nombre del archivo
            FileInfo fileInfo = null;
            switch (infFile.Extension)
            {
                case ".txt":
                    string arcPiv = Pivote(infFile.FullName);//Aqui cambiamos la ruta
                    fileInfo = new FileInfo(arcPiv);//Ingresamos toda la informacion

                    var (confirmationTxt, contentTxt) = await ValidateInTxt(fileInfo.FullName);//iNGRESAMOS AL METODO que valida y al mismo tiempo retorna la coincidencia tanto del nombre del archivo y del contenido
                    if (archivo.Contains(this.findWord) || confirmationTxt)
                    {
                        if (fileInfo.Exists)
                        {
                            contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentTxt, infFile.CreationTime, infFile.LastAccessTime, "TXT");
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "Verifique el archivo, Archivo inexistente...Posible eliminación", "Sin resultados...", "Sin resultados....", "TXT");
                        }
                    }
                    break;
                case ".pdf":
                    //La misma logica
                    string arcPivPdf = Pivote(infFile.FullName);
                    fileInfo = new FileInfo(arcPivPdf);

                    var (confirmationPdf, contentPdf) = await ValidateInPdf(fileInfo.FullName);
                    if (archivo.Contains(this.findWord) || confirmationPdf)
                    {
                        if (fileInfo.Exists)
                        {
                            this.contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentPdf, infFile.CreationTime, infFile.LastAccessTime, "PDF");
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "verifique el archivo, archivo inexistente...posible eliminación", "Sin resultados...", "sin resultados...", "PDF");
                        }
                    }
                    break;
                case ".docx":
                    //La misma Logica
                    string arcPivDocx = Pivote(infFile.FullName);
                    fileInfo = new FileInfo(arcPivDocx);

                    var (confirmationWord, contentWord) = await ValidateInWord(fileInfo.FullName);
                    if (archivo.Contains(this.findWord) || confirmationWord)
                    {
                        if (fileInfo.Exists)
                        {
                            this.contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentWord, infFile.CreationTime, infFile.LastAccessTime, "WORD");
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "verifique el archivo, archivo inexistente...posible eliminación", "Sin resultados...", "sin resultados...", "WORD");
                        }
                    }
                    break;
                case ".xlsx":
                    //La misma Logica
                    string arcPivXlsx = Pivote(infFile.FullName);
                    fileInfo = new FileInfo(arcPivXlsx);

                    var (confirmationExcel, contentExcel) = await ValidateInExcel(fileInfo.FullName);
                    if (archivo.Contains(this.findWord) || confirmationExcel)
                    {
                        if (fileInfo.Exists)
                        {
                            this.contArchivoRelac++;
                            dataGridViewArchivos.Rows.Add(infFile.FullName, contentExcel, infFile.CreationTime, infFile.LastAccessTime, "EXCEL"); ;
                        }
                        else
                        {
                            dataGridViewArchivos.Rows.Add(infFile.FullName, "verifique el archivo, archivo inexistente...posible eliminación", "Sin resultados", "sin resultados...", "EXCEL");
                        }
                    }
                    break;
            }
        }

        //Sección de Archivos Txt*******************************************************************************************************************************
        private async Task<(bool confirmationTxt, string contentTxt)> ValidateInTxt(string pathFileTxt)
        {
            //METODO DONDE SE VALIDA Y SE EXTRAE LA INFORMACION DE LOS ARCHIVOS TXT
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            string[] contentFileTxt;

            contentFileTxt = await GetInfoInsideFile(pathFileTxt);

            if (contentFileTxt == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFileTxt);

            return tupleValores;
        }
        private async Task<(bool confirmationPdf, string contentPdf)> ReadFile(string[] info)
        {
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            await Task.Run(() =>
            {
                foreach (var item in info)
                {
                    info = item.Split(new char[] { ',', '.', '_', '/', '-', ';', ':', '\\', '\n' });
                    foreach (var item2 in info)
                    {
                        string PIV = CleanCharacteres(item2).ToLower();

                        if (PIV.Contains(this.findWord))
                        {
                            tupleValores.confirmationTxt = true;
                            tupleValores.contentTxt = item2;
                            break;
                        }
                    }
                }
            });
            return tupleValores;
        }
        //Final de Sección de Archivos Txt***********************************************************************************************************************

        //Sección de Archivos Pdf********************************************************************************************************************************
        private async Task<(bool confirmationPdf, string contentPdf)> ValidateInPdf(string pathFilePdf)
        {
            //METODO DONDE VALIDFA Y EXTRAE LA INFORMACION DE LOS ARCHIVOS PDF
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            string[] contentFilePdf;

            if (!await ConvertPdfToFile(pathFilePdf)) { return tupleValores; }

            contentFilePdf = await GetInfoInsideFile(pathGeneric + "PdfFile.txt");

            if (contentFilePdf == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFilePdf);

            return tupleValores;
        }
        private async Task<bool> ConvertPdfToFile(string pathFilePdf)
        {
            bool resp = false;
            string s;
            string strText = string.Empty; ;
            await Task.Run(() =>
            {
                try
                {

                    PdfReader reader = new PdfReader(pathFilePdf);
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));

                        strText = strText + s;
                    }
                    reader.Close();
                    File.WriteAllText(pathGeneric + "PdfFile.txt", strText, Encoding.UTF8);
                    resp = true;
                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, pathFilePdf);
                }
            });
            return resp;
        }
        //Final de Sección de Archivos Pdf***********************************************************************************************************************

        //Sección de Archivos Word*******************************************************************************************************************************
        private async Task<(bool confirmationWord, string contentWord)> ValidateInWord(string pathFileWord)
        {
            //Metodo donde valida y extrae la informacion de los Archivos DOCX
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            string[] contentFileWord;

            if (!await ConvertWordtoFile(pathFileWord)) { return tupleValores; };

            contentFileWord = await GetInfoInsideFile(pathGeneric + "WordFile.txt");

            if (contentFileWord == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFileWord);

            return tupleValores;
        }
        private async Task<bool> ConvertWordtoFile(string pathFileWord)
        {
            string guapo;
            bool resp = false;
            await Task.Run(() =>
            {
                try
                {
                    TextExtractor ext = new TextExtractor(pathFileWord);
                    guapo = ext.ExtractText();

                    File.WriteAllText(pathGeneric + "WordFile.txt", guapo, Encoding.UTF8);
                    resp = true;
                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, pathFileWord);
                }
            });
            return resp;
        }
        //Final de Sección de Archivos Word**********************************************************************************************************************

        //Sección de Archivos Excel******************************************************************************************************************************
        private async Task<(bool confirmationExcel, string contentExcel)> ValidateInExcel(string pathFileExcel)
        {
            //Metodo del Excel, aqui primero manda a conversion una vez si la conversion es exitosa, pasa a la extraccion de las palabras para validar
            var tupleValores = (confirmationTxt: false, contentTxt: "Sin resultados");
            string[] contentFileXlsx;

            if (!await ConvertExcel(pathFileExcel)) { return tupleValores; }

            contentFileXlsx = await GetInfoInsideFile(pathGeneric + "csvFile.csv");

            if (contentFileXlsx == null) { return tupleValores; }

            tupleValores = await ReadFile(contentFileXlsx);

            return tupleValores;
        }

        private async Task<bool> ConvertExcel(string path)
        {
            //Conversion de los archivos Excel a Txt, donde se lee linea por linea implementando multiples metodos para la extraccion de la palabra
            bool resp = false;
            string csvData = "";
            await Task.Run(() => {

                try
                {
                    FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;
                    if (System.IO.Path.GetExtension(path).ToUpper() == ".XLS")
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    DataSet result = excelReader.AsDataSet();
                    excelReader.Close();
                    int n = result.Tables.Count;
                    for (int i = 0; i < n; i++)
                    {
                        result.Tables[i].TableName.ToString();
                        int row_no = 0;
                        while (row_no < result.Tables[i].Rows.Count)
                        {
                            for (int j = 0; j < result.Tables[i].Columns.Count; j++)
                            {
                                csvData += result.Tables[i].Rows[row_no][j].ToString() + ",";
                            }
                            row_no++;
                            csvData += "\n";
                        }
                    }

                    StreamWriter csv = new StreamWriter(pathGeneric + "CsvFile.csv");

                    csv.Write(csvData);
                    csv.Close();
                    resp = true;
                }
                catch (Exception)
                {
                    listBoxAdvertencias.BeginInvoke(control, listBoxAdvertencias, path);
                }

            });
            return resp;
        }
        //Final de Sección de Archivos Excel*********************************************************************************************************************

        private async Task<string[]> GetInfoInsideFile(string full)
        {
            //Metodo que extrae la informacion y contien un catch para evitar el cierre de la aplicacion debido por un error en el archvio
            string[] lee = null;
            await Task.Run(() =>
            {
                try
                {
                    lee = File.ReadAllLines(full, Encoding.UTF8);
                }
                catch (Exception)
                {
                    this.contadorAdventerncias++;
                    listBoxAdvertencias.Items.Add("Error en el archivo " + full);
                }
            });
            return lee;
        }

        public void OpenFile(string path)
        {
            //Metodo para abrir el archivo que se encuentra en el servidor
            string nuevoPath = Pivote(path);
            string[] separador;
            separador = nuevoPath.Split('\\');
            string nuevoPathComillas = string.Empty;
            for (int i = 0; i < separador.Length; i++)//Se hace un cambio de ruta cambiando la ruta del equipo remoto a la ruta del SERVIDOR
            {
                if (separador[i] != IPservidor && separador[i] != carpServidor && separador[i] != "Espejo" && separador[i] != "")
                {
                    nuevoPathComillas = nuevoPathComillas + @"\\" + "\"" + separador[i] + "\"";
                }
            }
            nuevoPathComillas = @"\\" + IPservidor + @"\" + carpServidor + @"\Espejo" + nuevoPathComillas;

            FileInfo file = new FileInfo(nuevoPath);
            if (file.Exists)
            {
                StreamWriter cP = new StreamWriter("AbrirDocumento.bat");

                cP.Write("CHCP 65001" + Environment.NewLine + nuevoPathComillas + Environment.NewLine + "CHCP 850" + Environment.NewLine + "EXIT");
                cP.Close();

                Process p = new Process();
                p.StartInfo.FileName = "AbrirDocumento.bat";
                p.Start();

                p.WaitForExit();

            }
            else
            {
                this.contadorAdventerncias++;
                listBoxAdvertencias.Items.Add("El archivo ha Abrir " + path + " no existe");
                labelContAdvertencias.Text = contadorAdventerncias.ToString();
            }
        }

        string Pivote(string nomb)
        {
            //Pivote sirve para hacer un cambio en la ruta, para poder acceder al servidor
            string arc = string.Empty;
            arc = nomb.Replace(@"C:\Users\" + usuarioServidor + @"\", @"\\" + IPservidor + @"\" + carpServidor + @"\Espejo\");//Usando el metodo Replace para el cambio
            if (arc.Contains(@"Downloads\"))
            {
                arc = arc.Replace(@"Downloads\", "");
            }
            if (arc.Contains(@"Documents\"))
            {
                arc = arc.Replace(@"Documents\", "");
            }
            if (arc.Contains(@"Desktop\"))
            {
                arc = arc.Replace(@"Desktop\", "");
            }
            return arc;
        }

        private async Task CleanPaths()
        {
            await Task.Run(() =>
            {
                //INSERCCIÓN DE RUTAS
                for (int T = 1; T < a.Length; T++)
                {
                    string filtroTxt = a[T].Replace("\"", "").TrimStart(); //Limpiamos la ruta, quitando las comillas del inicio y el final con ayuda del TrimStart
                    if (!coleccion.Contains(filtroTxt) && filtroTxt != "")
                    {
                        coleccion.Add(filtroTxt);//Agregandolo en el ArrayList
                    }
                }
            });
        }

        string CleanCharacteres(string nombreArchivo)
        {
            //Este metodo quita todas las tildes y caracteres especiales para que el programa trsabaje bien ya que son complicados los caracteres especiales
            string venga = string.Empty;
            string[] sep = nombreArchivo.Split(' ');
            foreach (var item in sep)
            {
                try
                {
                    string textoNormalizado = item.Normalize(NormalizationForm.FormD);
                    string textoSinAcento = Regex.Replace(textoNormalizado, @"[^0-9A-Za-z]", "");
                    venga = venga + textoSinAcento;
                }
                catch (Exception ex)
                {
                    this.contadorAdventerncias++;
                    listBoxAdvertencias.Items.Add(ex.Message);
                    return venga;
                }
            }
            return venga;
        }

        private void dataGridViewArchivos_DoubleClick(object sender, EventArgs e)
        {
            //Evento de doble click para abrir el archivo
            string data = dataGridViewArchivos.SelectedCells[0].EditedFormattedValue.ToString();//Estraccion de solo la ruta del archivo, almacenada en una variable para una validacion
            if (!(data.Trim() == "" || data.Contains("RESULTADO")))//Si el resultado no es en blanco o no contenga RESULTADO no abrira el archivo
            {
                OpenFile(data);//Si todo esta correcto se dirigira al Metodo OpenFile
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            //Evento para limpiar la informacion del DataGridView, ListBox y resetear los contadores de las advertencias y las coincidencias
            this.contArchivoRelac = 0; //Ingresando el valor 0 para el reseteo
            this.contadorAdventerncias = 0;//Ingresando el valor 0 para el reseteo
            if (!(dataGridViewArchivos == null))//Validacion si el dataGridView contiene informacion si es cierto, se eliminara toda la informacion.
            {
                dataGridViewArchivos.Rows.Clear();
            }
            if (!(labelContAdvertencias == null))//Validacion de las etiquetas, validando si contiene informacion si es cierto, reseteara el contador
            {
                labelContArchivosRelacionados.Text = this.contArchivoRelac.ToString();//Reseteo de la etiqueta
            }
            if (!(listBoxAdvertencias == null))//Validcacion de la etiqueta de las Advertencias
            {
                listBoxAdvertencias.Items.Clear(); //Limpiesa del ListBox
                labelContAdvertencias.Text = this.contadorAdventerncias.ToString();//Insertardo el nuevo valor 0 en la etiqueta
            }
        }

        private void buttonOcultarAdvertencias_Click(object sender, EventArgs e)
        {
            //Evento del Boton Ocultar
            buttonAdvertencias.Visible = true;//Visibilidad del boton Ver
            panelAdvertencias.Visible = false;//Ocultacion del panel
            buttonOcultarAdvertencias.Visible = false;//Ocultar el boton 'Ocultar'
        }

        private void buttonAdvertencias_Click(object sender, EventArgs e)
        {
            //Evento del Boton Advertencias donde ejecutara
            buttonAdvertencias.Visible = false;//La deshabilitacion de la visibilidad del boton que contiene 'Ver'
            panelAdvertencias.Visible = true;//La visibilidad del panel y su componente ListBox donde tendra visibilidad
            buttonOcultarAdvertencias.Visible = true;//Se oculta el boton Ocultar
        }
    }
}
