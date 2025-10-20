namespace WindowsFormsApp1
{
    partial class Formcuadrado
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
            this.lblcuadrado = new System.Windows.Forms.Label();
            this.txtlado = new System.Windows.Forms.TextBox();
            this.btncalcular = new System.Windows.Forms.Button();
            this.btnperimetro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblcuadrado
            // 
            this.lblcuadrado.AutoSize = true;
            this.lblcuadrado.Location = new System.Drawing.Point(258, 60);
            this.lblcuadrado.Name = "lblcuadrado";
            this.lblcuadrado.Size = new System.Drawing.Size(141, 13);
            this.lblcuadrado.TabIndex = 0;
            this.lblcuadrado.Text = "Ingrese el lado del cuadrado";
            // 
            // txtlado
            // 
            this.txtlado.Location = new System.Drawing.Point(454, 60);
            this.txtlado.Name = "txtlado";
            this.txtlado.Size = new System.Drawing.Size(100, 20);
            this.txtlado.TabIndex = 1;
            // 
            // btncalcular
            // 
            this.btncalcular.Location = new System.Drawing.Point(227, 117);
            this.btncalcular.Name = "btncalcular";
            this.btncalcular.Size = new System.Drawing.Size(91, 23);
            this.btncalcular.TabIndex = 2;
            this.btncalcular.Text = "Calcular area";
            this.btncalcular.UseVisualStyleBackColor = true;
            this.btncalcular.Click += new System.EventHandler(this.btncalcular_Click);
            // 
            // btnperimetro
            // 
            this.btnperimetro.Location = new System.Drawing.Point(426, 117);
            this.btnperimetro.Name = "btnperimetro";
            this.btnperimetro.Size = new System.Drawing.Size(106, 23);
            this.btnperimetro.TabIndex = 3;
            this.btnperimetro.Text = "Calcular perimetro";
            this.btnperimetro.UseVisualStyleBackColor = true;
            this.btnperimetro.Click += new System.EventHandler(this.btnperimetro_Click);
            // 
            // Formcuadrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnperimetro);
            this.Controls.Add(this.btncalcular);
            this.Controls.Add(this.txtlado);
            this.Controls.Add(this.lblcuadrado);
            this.Name = "Formcuadrado";
            this.Text = "cuadrado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcuadrado;
        private System.Windows.Forms.TextBox txtlado;
        private System.Windows.Forms.Button btncalcular;
        private System.Windows.Forms.Button btnperimetro;
    }
}