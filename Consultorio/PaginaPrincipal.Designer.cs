namespace Consultorio
{
    partial class PaginaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_altaDoctor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona la operacion que deseas hacer";
            // 
            // btn_altaDoctor
            // 
            this.btn_altaDoctor.Location = new System.Drawing.Point(12, 201);
            this.btn_altaDoctor.Name = "btn_altaDoctor";
            this.btn_altaDoctor.Size = new System.Drawing.Size(114, 50);
            this.btn_altaDoctor.TabIndex = 1;
            this.btn_altaDoctor.Text = "Dar de alta nuevo Doctor";
            this.btn_altaDoctor.UseVisualStyleBackColor = true;
            this.btn_altaDoctor.Click += new System.EventHandler(this.btn_altaDoctor_Click);
            // 
            // PaginaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_altaDoctor);
            this.Controls.Add(this.label1);
            this.Name = "PaginaPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_altaDoctor;
    }
}
