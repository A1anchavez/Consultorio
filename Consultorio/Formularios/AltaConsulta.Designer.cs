namespace Consultorio.Formularios
{
    partial class AltaConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaConsulta));
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dts_ListaDoctores = new System.Windows.Forms.DataGridView();
            this.dts_ListaClientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NomDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_fechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.txt_NomClnt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MotCon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dts_listaConsultas = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dts_ListaDoctores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_ListaClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_listaConsultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(30, 277);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 0;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(132, 277);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 1;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista Doctores:";
            // 
            // dts_ListaDoctores
            // 
            this.dts_ListaDoctores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dts_ListaDoctores.Location = new System.Drawing.Point(300, 24);
            this.dts_ListaDoctores.Name = "dts_ListaDoctores";
            this.dts_ListaDoctores.RowTemplate.Height = 25;
            this.dts_ListaDoctores.Size = new System.Drawing.Size(240, 99);
            this.dts_ListaDoctores.TabIndex = 3;
            // 
            // dts_ListaClientes
            // 
            this.dts_ListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dts_ListaClientes.Location = new System.Drawing.Point(300, 179);
            this.dts_ListaClientes.Name = "dts_ListaClientes";
            this.dts_ListaClientes.RowTemplate.Height = 25;
            this.dts_ListaClientes.Size = new System.Drawing.Size(240, 99);
            this.dts_ListaClientes.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista Clientes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre de Doctor:";
            // 
            // txt_NomDoc
            // 
            this.txt_NomDoc.Location = new System.Drawing.Point(12, 27);
            this.txt_NomDoc.Name = "txt_NomDoc";
            this.txt_NomDoc.Size = new System.Drawing.Size(282, 23);
            this.txt_NomDoc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de Consulta";
            // 
            // dtp_fechaConsulta
            // 
            this.dtp_fechaConsulta.Location = new System.Drawing.Point(12, 140);
            this.dtp_fechaConsulta.Name = "dtp_fechaConsulta";
            this.dtp_fechaConsulta.Size = new System.Drawing.Size(200, 23);
            this.dtp_fechaConsulta.TabIndex = 9;
            // 
            // txt_NomClnt
            // 
            this.txt_NomClnt.Location = new System.Drawing.Point(12, 80);
            this.txt_NomClnt.Name = "txt_NomClnt";
            this.txt_NomClnt.Size = new System.Drawing.Size(282, 23);
            this.txt_NomClnt.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre de Cliente:";
            // 
            // txt_MotCon
            // 
            this.txt_MotCon.Location = new System.Drawing.Point(12, 197);
            this.txt_MotCon.Name = "txt_MotCon";
            this.txt_MotCon.Size = new System.Drawing.Size(282, 23);
            this.txt_MotCon.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Motivo de Consulta (opcional):";
            // 
            // dts_listaConsultas
            // 
            this.dts_listaConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dts_listaConsultas.Location = new System.Drawing.Point(548, 95);
            this.dts_listaConsultas.Name = "dts_listaConsultas";
            this.dts_listaConsultas.RowTemplate.Height = 25;
            this.dts_listaConsultas.Size = new System.Drawing.Size(240, 99);
            this.dts_listaConsultas.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(548, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Lista de Consultas:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(576, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // AltaConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dts_listaConsultas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_MotCon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_NomClnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp_fechaConsulta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_NomDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dts_ListaClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dts_ListaDoctores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.btn_aceptar);
            this.Name = "AltaConsulta";
            this.Text = "AltaCosulta";
            this.Shown += new System.EventHandler(this.ListaConsultas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dts_ListaDoctores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_ListaClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_listaConsultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dts_ListaDoctores;
        private System.Windows.Forms.DataGridView dts_ListaClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NomDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_fechaConsulta;
        private System.Windows.Forms.TextBox txt_NomClnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MotCon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dts_listaConsultas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}