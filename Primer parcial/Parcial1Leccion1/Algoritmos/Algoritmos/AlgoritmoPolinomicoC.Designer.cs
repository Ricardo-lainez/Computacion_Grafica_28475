namespace Algoritmos
{
    partial class AlgoritmoPolinomicoC
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el radio";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(112, 79);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 20);
            this.txtRadio.TabIndex = 1;
            this.txtRadio.TextChanged += new System.EventHandler(this.txtRadio_TextChanged);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(47, 117);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(218, 12);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(570, 426);
            this.ptbGrafica.TabIndex = 3;
            this.ptbGrafica.TabStop = false;
            this.ptbGrafica.Click += new System.EventHandler(this.ptbGrafica_Click);
            // 
            // AlgoritmoPolinomicoC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ptbGrafica);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.label1);
            this.Name = "AlgoritmoPolinomicoC";
            this.Text = "AlgoritmoPolinomicoC";
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.PictureBox ptbGrafica;
    }
}