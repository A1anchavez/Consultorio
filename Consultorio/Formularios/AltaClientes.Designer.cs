namespace Consultorio.Formularios
{
    partial class AltaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaCliente));
            this.dtg_ListaClientes = new System.Windows.Forms.DataGridView();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_apellidos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.dtp_fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_delete = new System.Windows.Forms.TextBox();
            this.txt_consultar = new System.Windows.Forms.TextBox();
            this.txt_put = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_consultar_id = new System.Windows.Forms.Button();
            this.btn_put = new System.Windows.Forms.Button();
            this.btn_consultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ListaClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_ListaClientes
            // 
            this.dtg_ListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_ListaClientes.Location = new System.Drawing.Point(419, 69);
            this.dtg_ListaClientes.Name = "dtg_ListaClientes";
            this.dtg_ListaClientes.RowTemplate.Height = 25;
            this.dtg_ListaClientes.Size = new System.Drawing.Size(369, 170);
            this.dtg_ListaClientes.TabIndex = 21;
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(12, 289);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 20;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Direccion";
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(12, 242);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(249, 23);
            this.txt_direccion.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha de Nacimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Apellidos";
            // 
            // txt_apellidos
            // 
            this.txt_apellidos.Location = new System.Drawing.Point(12, 127);
            this.txt_apellidos.Name = "txt_apellidos";
            this.txt_apellidos.Size = new System.Drawing.Size(249, 23);
            this.txt_apellidos.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(12, 69);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(249, 23);
            this.txt_nombre.TabIndex = 11;
            // 
            // dtp_fechaNacimiento
            // 
            this.dtp_fechaNacimiento.Location = new System.Drawing.Point(12, 183);
            this.dtp_fechaNacimiento.Name = "dtp_fechaNacimiento";
            this.dtp_fechaNacimiento.Size = new System.Drawing.Size(200, 23);
            this.dtp_fechaNacimiento.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(583, 261);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // txt_delete
            // 
            this.txt_delete.Location = new System.Drawing.Point(410, 415);
            this.txt_delete.Name = "txt_delete";
            this.txt_delete.Size = new System.Drawing.Size(135, 23);
            this.txt_delete.TabIndex = 29;
            // 
            // txt_consultar
            // 
            this.txt_consultar.Location = new System.Drawing.Point(226, 415);
            this.txt_consultar.Name = "txt_consultar";
            this.txt_consultar.Size = new System.Drawing.Size(142, 23);
            this.txt_consultar.TabIndex = 28;
            // 
            // txt_put
            // 
            this.txt_put.Location = new System.Drawing.Point(328, 284);
            this.txt_put.Name = "txt_put";
            this.txt_put.Size = new System.Drawing.Size(139, 23);
            this.txt_put.TabIndex = 27;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(410, 368);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 26;
            this.btn_delete.Text = "Eliminar";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_consultar_id
            // 
            this.btn_consultar_id.Location = new System.Drawing.Point(225, 368);
            this.btn_consultar_id.Name = "btn_consultar_id";
            this.btn_consultar_id.Size = new System.Drawing.Size(101, 23);
            this.btn_consultar_id.TabIndex = 25;
            this.btn_consultar_id.Text = "Consultar por id";
            this.btn_consultar_id.UseVisualStyleBackColor = true;
            this.btn_consultar_id.Click += new System.EventHandler(this.btn_consultar_id_Click);
            // 
            // btn_put
            // 
            this.btn_put.Location = new System.Drawing.Point(225, 283);
            this.btn_put.Name = "btn_put";
            this.btn_put.Size = new System.Drawing.Size(75, 23);
            this.btn_put.TabIndex = 24;
            this.btn_put.Text = "Actualizar";
            this.btn_put.UseVisualStyleBackColor = true;
            this.btn_put.Click += new System.EventHandler(this.btn_put_Click);
            // 
            // btn_consultar
            // 
            this.btn_consultar.Location = new System.Drawing.Point(12, 385);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_consultar.TabIndex = 30;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.txt_delete);
            this.Controls.Add(this.txt_consultar);
            this.Controls.Add(this.txt_put);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_consultar_id);
            this.Controls.Add(this.btn_put);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtp_fechaNacimiento);
            this.Controls.Add(this.dtg_ListaClientes);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_apellidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nombre);
            this.Name = "AltaCliente";
            this.Text = "AltaCliente";
            this.Shown += new System.EventHandler(this.ListaClientes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ListaClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_ListaClientes;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_apellidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.DateTimePicker dtp_fechaNacimiento;
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