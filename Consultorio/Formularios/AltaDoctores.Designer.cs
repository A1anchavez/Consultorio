namespace Consultorio.Formularios
{
    partial class AltaDoctores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaDoctores));
            this.txt_cedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_apellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_numtel = new System.Windows.Forms.TextBox();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.dtg_ListaDoctores = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_put = new System.Windows.Forms.Button();
            this.btn_consultar_id = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txt_put = new System.Windows.Forms.TextBox();
            this.txt_consultar = new System.Windows.Forms.TextBox();
            this.txt_delete = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ListaDoctores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_cedula
            // 
            this.txt_cedula.Location = new System.Drawing.Point(12, 52);
            this.txt_cedula.Name = "txt_cedula";
            this.txt_cedula.Size = new System.Drawing.Size(249, 23);
            this.txt_cedula.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cedula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(12, 110);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(249, 23);
            this.txt_nombre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellidos";
            // 
            // txt_apellidos
            // 
            this.txt_apellidos.Location = new System.Drawing.Point(12, 166);
            this.txt_apellidos.Name = "txt_apellidos";
            this.txt_apellidos.Size = new System.Drawing.Size(249, 23);
            this.txt_apellidos.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Numero de telefono";
            // 
            // txt_numtel
            // 
            this.txt_numtel.Location = new System.Drawing.Point(12, 225);
            this.txt_numtel.Name = "txt_numtel";
            this.txt_numtel.Size = new System.Drawing.Size(249, 23);
            this.txt_numtel.TabIndex = 6;
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(12, 283);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 9;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // dtg_ListaDoctores
            // 
            this.dtg_ListaDoctores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_ListaDoctores.Location = new System.Drawing.Point(419, 52);
            this.dtg_ListaDoctores.Name = "dtg_ListaDoctores";
            this.dtg_ListaDoctores.RowTemplate.Height = 25;
            this.dtg_ListaDoctores.Size = new System.Drawing.Size(369, 170);
            this.dtg_ListaDoctores.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(577, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btn_consultar
            // 
            this.btn_consultar.Location = new System.Drawing.Point(12, 368);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_consultar.TabIndex = 12;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_put
            // 
            this.btn_put.Location = new System.Drawing.Point(186, 283);
            this.btn_put.Name = "btn_put";
            this.btn_put.Size = new System.Drawing.Size(75, 23);
            this.btn_put.TabIndex = 13;
            this.btn_put.Text = "Actualizar";
            this.btn_put.UseVisualStyleBackColor = true;
            this.btn_put.Click += new System.EventHandler(this.btn_put_Click);
            // 
            // btn_consultar_id
            // 
            this.btn_consultar_id.Location = new System.Drawing.Point(186, 368);
            this.btn_consultar_id.Name = "btn_consultar_id";
            this.btn_consultar_id.Size = new System.Drawing.Size(101, 23);
            this.btn_consultar_id.TabIndex = 14;
            this.btn_consultar_id.Text = "Consultar por id";
            this.btn_consultar_id.UseVisualStyleBackColor = true;
            this.btn_consultar_id.Click += new System.EventHandler(this.btn_consultar_id_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(371, 368);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 15;
            this.btn_delete.Text = "Eliminar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txt_put
            // 
            this.txt_put.Location = new System.Drawing.Point(289, 284);
            this.txt_put.Name = "txt_put";
            this.txt_put.Size = new System.Drawing.Size(139, 23);
            this.txt_put.TabIndex = 16;
            // 
            // txt_consultar
            // 
            this.txt_consultar.Location = new System.Drawing.Point(187, 415);
            this.txt_consultar.Name = "txt_consultar";
            this.txt_consultar.Size = new System.Drawing.Size(142, 23);
            this.txt_consultar.TabIndex = 17;
            // 
            // txt_delete
            // 
            this.txt_delete.Location = new System.Drawing.Point(371, 415);
            this.txt_delete.Name = "txt_delete";
            this.txt_delete.Size = new System.Drawing.Size(135, 23);
            this.txt_delete.TabIndex = 18;
            // 
            // AltaDoctores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_delete);
            this.Controls.Add(this.txt_consultar);
            this.Controls.Add(this.txt_put);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_consultar_id);
            this.Controls.Add(this.btn_put);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtg_ListaDoctores);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_numtel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_apellidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cedula);
            this.Name = "AltaDoctores";
            this.Text = "AltaDoctor";
            this.Shown += new System.EventHandler(this.ListaDoctores_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ListaDoctores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_apellidos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_numtel;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.DataGridView dtg_ListaDoctores;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Button btn_put;
        private System.Windows.Forms.Button btn_consultar_id;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_put;
        private System.Windows.Forms.TextBox txt_consultar;
        private System.Windows.Forms.TextBox txt_delete;
    }
}