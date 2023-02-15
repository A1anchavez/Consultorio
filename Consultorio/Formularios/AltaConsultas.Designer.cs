namespace Consultorio.Formularios
{
    partial class AltaConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaConsultas));
            this.btn_registrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dts_ListaDoctores = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NomDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_fechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.txt_MotCon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dts_listaConsultas = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_delete = new System.Windows.Forms.TextBox();
            this.txt_consultar = new System.Windows.Forms.TextBox();
            this.txt_put = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_consultar_id = new System.Windows.Forms.Button();
            this.btn_put = new System.Windows.Forms.Button();
            this.btn_consultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dts_ListaDoctores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_listaConsultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(12, 238);
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
            this.label1.Location = new System.Drawing.Point(425, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista Doctores:";
            // 
            // dts_ListaDoctores
            // 
            this.dts_ListaDoctores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dts_ListaDoctores.Location = new System.Drawing.Point(425, 181);
            this.dts_ListaDoctores.Name = "dts_ListaDoctores";
            this.dts_ListaDoctores.RowTemplate.Height = 25;
            this.dts_ListaDoctores.Size = new System.Drawing.Size(386, 99);
            this.dts_ListaDoctores.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID del doctor";
            // 
            // txt_NomDoc
            // 
            this.txt_NomDoc.Location = new System.Drawing.Point(12, 38);
            this.txt_NomDoc.Name = "txt_NomDoc";
            this.txt_NomDoc.Size = new System.Drawing.Size(282, 23);
            this.txt_NomDoc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de Consulta";
            // 
            // dtp_fechaConsulta
            // 
            this.dtp_fechaConsulta.Location = new System.Drawing.Point(12, 92);
            this.dtp_fechaConsulta.Name = "dtp_fechaConsulta";
            this.dtp_fechaConsulta.Size = new System.Drawing.Size(224, 23);
            this.dtp_fechaConsulta.TabIndex = 9;
            // 
            // txt_MotCon
            // 
            this.txt_MotCon.Location = new System.Drawing.Point(12, 149);
            this.txt_MotCon.Name = "txt_MotCon";
            this.txt_MotCon.Size = new System.Drawing.Size(282, 23);
            this.txt_MotCon.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Motivo de Consulta (opcional):";
            // 
            // dts_listaConsultas
            // 
            this.dts_listaConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dts_listaConsultas.Location = new System.Drawing.Point(425, 38);
            this.dts_listaConsultas.Name = "dts_listaConsultas";
            this.dts_listaConsultas.RowTemplate.Height = 25;
            this.dts_listaConsultas.Size = new System.Drawing.Size(402, 99);
            this.dts_listaConsultas.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(423, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Lista de Consultas:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(616, 284);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // txt_delete
            // 
            this.txt_delete.Location = new System.Drawing.Point(311, 372);
            this.txt_delete.Name = "txt_delete";
            this.txt_delete.Size = new System.Drawing.Size(135, 23);
            this.txt_delete.TabIndex = 25;
            // 
            // txt_consultar
            // 
            this.txt_consultar.Location = new System.Drawing.Point(127, 372);
            this.txt_consultar.Name = "txt_consultar";
            this.txt_consultar.Size = new System.Drawing.Size(142, 23);
            this.txt_consultar.TabIndex = 24;
            // 
            // txt_put
            // 
            this.txt_put.Location = new System.Drawing.Point(238, 238);
            this.txt_put.Name = "txt_put";
            this.txt_put.Size = new System.Drawing.Size(139, 23);
            this.txt_put.TabIndex = 23;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(311, 325);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 22;
            this.btn_delete.Text = "Eliminar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_consultar_id
            // 
            this.btn_consultar_id.Location = new System.Drawing.Point(126, 325);
            this.btn_consultar_id.Name = "btn_consultar_id";
            this.btn_consultar_id.Size = new System.Drawing.Size(101, 23);
            this.btn_consultar_id.TabIndex = 21;
            this.btn_consultar_id.Text = "Consultar por id";
            this.btn_consultar_id.UseVisualStyleBackColor = true;
            this.btn_consultar_id.Click += new System.EventHandler(this.btn_consultar_id_Click);
            // 
            // btn_put
            // 
            this.btn_put.Location = new System.Drawing.Point(135, 237);
            this.btn_put.Name = "btn_put";
            this.btn_put.Size = new System.Drawing.Size(75, 23);
            this.btn_put.TabIndex = 20;
            this.btn_put.Text = "Actualizar";
            this.btn_put.UseVisualStyleBackColor = true;
            this.btn_put.Click += new System.EventHandler(this.btn_put_Click);
            // 
            // btn_consultar
            // 
            this.btn_consultar.Location = new System.Drawing.Point(16, 325);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_consultar.TabIndex = 19;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // AltaConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 443);
            this.Controls.Add(this.txt_delete);
            this.Controls.Add(this.txt_consultar);
            this.Controls.Add(this.txt_put);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_consultar_id);
            this.Controls.Add(this.btn_put);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dts_listaConsultas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_MotCon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp_fechaConsulta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_NomDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dts_ListaDoctores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_registrar);
            this.Name = "AltaConsultas";
            this.Text = "AltaCosulta";
            this.Shown += new System.EventHandler(this.ListaConsultas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dts_ListaDoctores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_listaConsultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dts_ListaDoctores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NomDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_fechaConsulta;
        private System.Windows.Forms.TextBox txt_MotCon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dts_listaConsultas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_delete;
        private System.Windows.Forms.TextBox txt_consultar;
        private System.Windows.Forms.TextBox txt_put;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_consultar_id;
        private System.Windows.Forms.Button btn_put;
        private System.Windows.Forms.Button btn_consultar;
    }
}