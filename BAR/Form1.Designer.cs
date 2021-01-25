namespace BAR
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TextBoxPalabra = new System.Windows.Forms.TextBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.progressBarArchivos = new System.Windows.Forms.ProgressBar();
            this.labelEspere = new System.Windows.Forms.Label();
            this.labelTrabajandoSobre = new System.Windows.Forms.Label();
            this.buttonOcultarAdvertencias = new System.Windows.Forms.Button();
            this.buttonAdvertencias = new System.Windows.Forms.Button();
            this.panelAdvertencias = new System.Windows.Forms.Panel();
            this.listBoxAdvertencias = new System.Windows.Forms.ListBox();
            this.labelContAdvertencias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelContArchivosRelacionados = new System.Windows.Forms.Label();
            this.labelArchivosRelacionados = new System.Windows.Forms.Label();
            this.buttonClean = new System.Windows.Forms.Button();
            this.dataGridViewArchivos = new System.Windows.Forms.DataGridView();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastModif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAdvertencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxPalabra
            // 
            this.TextBoxPalabra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPalabra.Location = new System.Drawing.Point(22, 75);
            this.TextBoxPalabra.Name = "TextBoxPalabra";
            this.TextBoxPalabra.Size = new System.Drawing.Size(178, 26);
            this.TextBoxPalabra.TabIndex = 0;
            // 
            // Buscar
            // 
            this.Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.Location = new System.Drawing.Point(220, 75);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 26);
            this.Buscar.TabIndex = 1;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // progressBarArchivos
            // 
            this.progressBarArchivos.BackColor = System.Drawing.Color.Black;
            this.progressBarArchivos.Location = new System.Drawing.Point(22, 220);
            this.progressBarArchivos.Name = "progressBarArchivos";
            this.progressBarArchivos.Size = new System.Drawing.Size(461, 61);
            this.progressBarArchivos.TabIndex = 46;
            this.progressBarArchivos.Visible = false;
            // 
            // labelEspere
            // 
            this.labelEspere.AutoSize = true;
            this.labelEspere.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEspere.Location = new System.Drawing.Point(18, 179);
            this.labelEspere.Name = "labelEspere";
            this.labelEspere.Size = new System.Drawing.Size(101, 24);
            this.labelEspere.TabIndex = 45;
            this.labelEspere.Text = "ESPERE...";
            this.labelEspere.Visible = false;
            // 
            // labelTrabajandoSobre
            // 
            this.labelTrabajandoSobre.AutoSize = true;
            this.labelTrabajandoSobre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrabajandoSobre.Location = new System.Drawing.Point(18, 140);
            this.labelTrabajandoSobre.Name = "labelTrabajandoSobre";
            this.labelTrabajandoSobre.Size = new System.Drawing.Size(137, 24);
            this.labelTrabajandoSobre.TabIndex = 43;
            this.labelTrabajandoSobre.Text = "TRABAJANDO";
            this.labelTrabajandoSobre.Visible = false;
            // 
            // buttonOcultarAdvertencias
            // 
            this.buttonOcultarAdvertencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOcultarAdvertencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOcultarAdvertencias.Location = new System.Drawing.Point(540, 106);
            this.buttonOcultarAdvertencias.Name = "buttonOcultarAdvertencias";
            this.buttonOcultarAdvertencias.Size = new System.Drawing.Size(97, 42);
            this.buttonOcultarAdvertencias.TabIndex = 56;
            this.buttonOcultarAdvertencias.Text = "Ocultar";
            this.buttonOcultarAdvertencias.UseVisualStyleBackColor = true;
            this.buttonOcultarAdvertencias.Click += new System.EventHandler(this.buttonOcultarAdvertencias_Click);
            // 
            // buttonAdvertencias
            // 
            this.buttonAdvertencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdvertencias.Location = new System.Drawing.Point(540, 106);
            this.buttonAdvertencias.Name = "buttonAdvertencias";
            this.buttonAdvertencias.Size = new System.Drawing.Size(97, 42);
            this.buttonAdvertencias.TabIndex = 55;
            this.buttonAdvertencias.Text = "Ver";
            this.buttonAdvertencias.UseVisualStyleBackColor = true;
            this.buttonAdvertencias.Visible = false;
            this.buttonAdvertencias.Click += new System.EventHandler(this.buttonAdvertencias_Click);
            // 
            // panelAdvertencias
            // 
            this.panelAdvertencias.Controls.Add(this.listBoxAdvertencias);
            this.panelAdvertencias.Location = new System.Drawing.Point(540, 154);
            this.panelAdvertencias.Name = "panelAdvertencias";
            this.panelAdvertencias.Size = new System.Drawing.Size(703, 201);
            this.panelAdvertencias.TabIndex = 54;
            // 
            // listBoxAdvertencias
            // 
            this.listBoxAdvertencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxAdvertencias.ForeColor = System.Drawing.Color.White;
            this.listBoxAdvertencias.FormattingEnabled = true;
            this.listBoxAdvertencias.HorizontalScrollbar = true;
            this.listBoxAdvertencias.Location = new System.Drawing.Point(3, 3);
            this.listBoxAdvertencias.Name = "listBoxAdvertencias";
            this.listBoxAdvertencias.Size = new System.Drawing.Size(697, 199);
            this.listBoxAdvertencias.TabIndex = 2;
            this.listBoxAdvertencias.TabStop = false;
            // 
            // labelContAdvertencias
            // 
            this.labelContAdvertencias.AutoSize = true;
            this.labelContAdvertencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContAdvertencias.Location = new System.Drawing.Point(666, 75);
            this.labelContAdvertencias.Name = "labelContAdvertencias";
            this.labelContAdvertencias.Size = new System.Drawing.Size(25, 24);
            this.labelContAdvertencias.TabIndex = 53;
            this.labelContAdvertencias.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(536, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 52;
            this.label1.Text = "Advertencias:";
            // 
            // labelContArchivosRelacionados
            // 
            this.labelContArchivosRelacionados.AutoSize = true;
            this.labelContArchivosRelacionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContArchivosRelacionados.Location = new System.Drawing.Point(148, 465);
            this.labelContArchivosRelacionados.Name = "labelContArchivosRelacionados";
            this.labelContArchivosRelacionados.Size = new System.Drawing.Size(17, 16);
            this.labelContArchivosRelacionados.TabIndex = 60;
            this.labelContArchivosRelacionados.Text = "...";
            // 
            // labelArchivosRelacionados
            // 
            this.labelArchivosRelacionados.AutoSize = true;
            this.labelArchivosRelacionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArchivosRelacionados.Location = new System.Drawing.Point(12, 465);
            this.labelArchivosRelacionados.Name = "labelArchivosRelacionados";
            this.labelArchivosRelacionados.Size = new System.Drawing.Size(96, 16);
            this.labelArchivosRelacionados.TabIndex = 59;
            this.labelArchivosRelacionados.Text = "Coincidencias:";
            // 
            // buttonClean
            // 
            this.buttonClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClean.Location = new System.Drawing.Point(1075, 450);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(180, 46);
            this.buttonClean.TabIndex = 58;
            this.buttonClean.Text = "Limpiar";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // dataGridViewArchivos
            // 
            this.dataGridViewArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewArchivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewArchivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPath,
            this.ColumnInf,
            this.ColumnCreacion,
            this.ColumnLastModif,
            this.ColumnType});
            this.dataGridViewArchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewArchivos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewArchivos.Location = new System.Drawing.Point(0, 502);
            this.dataGridViewArchivos.Name = "dataGridViewArchivos";
            this.dataGridViewArchivos.ReadOnly = true;
            this.dataGridViewArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchivos.Size = new System.Drawing.Size(1267, 283);
            this.dataGridViewArchivos.TabIndex = 57;
            this.dataGridViewArchivos.TabStop = false;
            this.dataGridViewArchivos.DoubleClick += new System.EventHandler(this.dataGridViewArchivos_DoubleClick);
            // 
            // ColumnPath
            // 
            this.ColumnPath.HeaderText = "Ruta del Archivo";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            this.ColumnPath.Width = 102;
            // 
            // ColumnInf
            // 
            this.ColumnInf.HeaderText = "Contenido";
            this.ColumnInf.Name = "ColumnInf";
            this.ColumnInf.ReadOnly = true;
            this.ColumnInf.Width = 80;
            // 
            // ColumnCreacion
            // 
            this.ColumnCreacion.HeaderText = "Creacion";
            this.ColumnCreacion.Name = "ColumnCreacion";
            this.ColumnCreacion.ReadOnly = true;
            this.ColumnCreacion.Width = 74;
            // 
            // ColumnLastModif
            // 
            this.ColumnLastModif.HeaderText = "Ult.Modificación";
            this.ColumnLastModif.Name = "ColumnLastModif";
            this.ColumnLastModif.ReadOnly = true;
            this.ColumnLastModif.Width = 108;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Tipo";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 53;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1073, 13);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(882, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 62;
            this.label4.Text = "MODO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(962, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 61;
            this.label2.Text = "REMOTO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 785);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelContArchivosRelacionados);
            this.Controls.Add(this.labelArchivosRelacionados);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.dataGridViewArchivos);
            this.Controls.Add(this.buttonOcultarAdvertencias);
            this.Controls.Add(this.buttonAdvertencias);
            this.Controls.Add(this.panelAdvertencias);
            this.Controls.Add(this.labelContAdvertencias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarArchivos);
            this.Controls.Add(this.labelEspere);
            this.Controls.Add(this.labelTrabajandoSobre);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.TextBoxPalabra);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelAdvertencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxPalabra;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.ProgressBar progressBarArchivos;
        private System.Windows.Forms.Label labelEspere;
        private System.Windows.Forms.Label labelTrabajandoSobre;
        private System.Windows.Forms.Button buttonOcultarAdvertencias;
        private System.Windows.Forms.Button buttonAdvertencias;
        private System.Windows.Forms.Panel panelAdvertencias;
        private System.Windows.Forms.ListBox listBoxAdvertencias;
        private System.Windows.Forms.Label labelContAdvertencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelContArchivosRelacionados;
        private System.Windows.Forms.Label labelArchivosRelacionados;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.DataGridView dataGridViewArchivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastModif;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}

