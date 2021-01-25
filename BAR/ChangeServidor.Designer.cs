namespace BAR
{
    partial class ChangeServidor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LabelServidor = new System.Windows.Forms.Label();
            this.TextBoxIP = new System.Windows.Forms.TextBox();
            this.ButtonChangeServidor = new System.Windows.Forms.Button();
            this.CheckBoxServPredeterminado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.LabelIpLocal = new System.Windows.Forms.Label();
            this.TextBoxCarp = new System.Windows.Forms.TextBox();
            this.labelPw = new System.Windows.Forms.Label();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxConfPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxNombServ = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelServidor
            // 
            this.LabelServidor.AutoSize = true;
            this.LabelServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelServidor.Location = new System.Drawing.Point(149, 80);
            this.LabelServidor.Name = "LabelServidor";
            this.LabelServidor.Size = new System.Drawing.Size(45, 16);
            this.LabelServidor.TabIndex = 0;
            this.LabelServidor.Text = "label1";
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxIP.Location = new System.Drawing.Point(105, 174);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(151, 22);
            this.TextBoxIP.TabIndex = 2;
            this.TextBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIP_KeyPress);
            this.TextBoxIP.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxIP_Validating);
            // 
            // ButtonChangeServidor
            // 
            this.ButtonChangeServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonChangeServidor.Location = new System.Drawing.Point(124, 394);
            this.ButtonChangeServidor.Name = "ButtonChangeServidor";
            this.ButtonChangeServidor.Size = new System.Drawing.Size(107, 49);
            this.ButtonChangeServidor.TabIndex = 12;
            this.ButtonChangeServidor.Text = "Aceptar";
            this.ButtonChangeServidor.UseVisualStyleBackColor = true;
            this.ButtonChangeServidor.Click += new System.EventHandler(this.ButtonChangeServidor_Click);
            // 
            // CheckBoxServPredeterminado
            // 
            this.CheckBoxServPredeterminado.AutoSize = true;
            this.CheckBoxServPredeterminado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxServPredeterminado.Location = new System.Drawing.Point(103, 365);
            this.CheckBoxServPredeterminado.Name = "CheckBoxServPredeterminado";
            this.CheckBoxServPredeterminado.Size = new System.Drawing.Size(157, 20);
            this.CheckBoxServPredeterminado.TabIndex = 10;
            this.CheckBoxServPredeterminado.Text = "Conf. Predeterminada";
            this.CheckBoxServPredeterminado.UseVisualStyleBackColor = true;
            this.CheckBoxServPredeterminado.CheckedChanged += new System.EventHandler(this.CheckBoxServPredeterminado_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP del Servidor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LabelIpLocal
            // 
            this.LabelIpLocal.AutoSize = true;
            this.LabelIpLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIpLocal.Location = new System.Drawing.Point(109, 150);
            this.LabelIpLocal.Name = "LabelIpLocal";
            this.LabelIpLocal.Size = new System.Drawing.Size(134, 16);
            this.LabelIpLocal.TabIndex = 5;
            this.LabelIpLocal.Text = "Ingrese la IP servidor";
            this.LabelIpLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxCarp
            // 
            this.TextBoxCarp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCarp.Location = new System.Drawing.Point(103, 320);
            this.TextBoxCarp.Name = "TextBoxCarp";
            this.TextBoxCarp.Size = new System.Drawing.Size(151, 22);
            this.TextBoxCarp.TabIndex = 8;
            this.TextBoxCarp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPw.Location = new System.Drawing.Point(106, 203);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(144, 16);
            this.labelPw.TabIndex = 9;
            this.labelPw.Text = "Password del Servidor";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPassword.Location = new System.Drawing.Point(105, 224);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(151, 22);
            this.TextBoxPassword.TabIndex = 3;
            this.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre de la Carpeta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Confirmar Password";
            // 
            // TextBoxConfPass
            // 
            this.TextBoxConfPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxConfPass.Location = new System.Drawing.Point(105, 268);
            this.TextBoxConfPass.Name = "TextBoxConfPass";
            this.TextBoxConfPass.PasswordChar = '*';
            this.TextBoxConfPass.Size = new System.Drawing.Size(151, 22);
            this.TextBoxConfPass.TabIndex = 6;
            this.TextBoxConfPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxConfPass.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxConfPass_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(110, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nombre del Servidor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxNombServ
            // 
            this.TextBoxNombServ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNombServ.Location = new System.Drawing.Point(106, 124);
            this.TextBoxNombServ.Name = "TextBoxNombServ";
            this.TextBoxNombServ.Size = new System.Drawing.Size(151, 22);
            this.TextBoxNombServ.TabIndex = 1;
            this.TextBoxNombServ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(49, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 49);
            this.button1.TabIndex = 14;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(181, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 49);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChangeServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 483);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxNombServ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxConfPass);
            this.Controls.Add(this.labelPw);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxCarp);
            this.Controls.Add(this.LabelIpLocal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckBoxServPredeterminado);
            this.Controls.Add(this.ButtonChangeServidor);
            this.Controls.Add(this.TextBoxIP);
            this.Controls.Add(this.LabelServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChangeServidor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Establecer Servidor";
            this.Load += new System.EventHandler(this.ChangeServidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelServidor;
        private System.Windows.Forms.TextBox TextBoxIP;
        private System.Windows.Forms.Button ButtonChangeServidor;
        private System.Windows.Forms.CheckBox CheckBoxServPredeterminado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label LabelIpLocal;
        private System.Windows.Forms.TextBox TextBoxCarp;
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxConfPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxNombServ;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}