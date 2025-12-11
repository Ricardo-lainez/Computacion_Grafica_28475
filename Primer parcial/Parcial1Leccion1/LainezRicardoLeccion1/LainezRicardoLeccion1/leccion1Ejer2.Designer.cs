namespace LainezRicardoLeccion1
{
    partial class frmEjercicio2
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
            this.btnGraficar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidadLinea = new System.Windows.Forms.TextBox();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.btnResetear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(164, 126);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // txtCantidadLinea
            // 
            this.txtCantidadLinea.Location = new System.Drawing.Point(197, 56);
            this.txtCantidadLinea.Name = "txtCantidadLinea";
            this.txtCantidadLinea.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadLinea.TabIndex = 2;
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(373, 46);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(391, 288);
            this.ptbGrafica.TabIndex = 3;
            this.ptbGrafica.TabStop = false;
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(164, 203);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 4;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // frmEjercicio2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.ptbGrafica);
            this.Controls.Add(this.txtCantidadLinea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGraficar);
            this.Name = "frmEjercicio2";
            this.Text = "Ejercicio 2";
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidadLinea;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.Button btnResetear;
    }
}