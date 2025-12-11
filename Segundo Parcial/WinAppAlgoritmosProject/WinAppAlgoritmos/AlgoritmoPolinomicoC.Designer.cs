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
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanLineFill = new System.Windows.Forms.Button();
            this.btnBoundaryFill = new System.Windows.Forms.Button();
            this.btnFloodFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(218, 12);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(570, 426);
            this.ptbGrafica.TabIndex = 7;
            this.ptbGrafica.TabStop = false;
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(47, 117);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 6;
            this.btnGraficar.Text = "graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(112, 79);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 20);
            this.txtRadio.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingrese el radio";
            // 
            // btnScanLineFill
            // 
            this.btnScanLineFill.Location = new System.Drawing.Point(28, 240);
            this.btnScanLineFill.Name = "btnScanLineFill";
            this.btnScanLineFill.Size = new System.Drawing.Size(131, 23);
            this.btnScanLineFill.TabIndex = 17;
            this.btnScanLineFill.Text = "Algoritmo Scan Line Fill";
            this.btnScanLineFill.UseVisualStyleBackColor = true;
            this.btnScanLineFill.Click += new System.EventHandler(this.btnScanLineFill_Click);
            // 
            // btnBoundaryFill
            // 
            this.btnBoundaryFill.Location = new System.Drawing.Point(28, 210);
            this.btnBoundaryFill.Name = "btnBoundaryFill";
            this.btnBoundaryFill.Size = new System.Drawing.Size(131, 23);
            this.btnBoundaryFill.TabIndex = 16;
            this.btnBoundaryFill.Text = "Algoritmo Boundary Fill";
            this.btnBoundaryFill.UseVisualStyleBackColor = true;
            this.btnBoundaryFill.Click += new System.EventHandler(this.btnBoundaryFill_Click);
            // 
            // btnFloodFill
            // 
            this.btnFloodFill.Location = new System.Drawing.Point(28, 180);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(131, 23);
            this.btnFloodFill.TabIndex = 15;
            this.btnFloodFill.Text = "Algoritmo flood fill";
            this.btnFloodFill.UseVisualStyleBackColor = true;
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFill_Click);
            // 
            // AlgoritmoPolinomicoC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnScanLineFill);
            this.Controls.Add(this.btnBoundaryFill);
            this.Controls.Add(this.btnFloodFill);
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

        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScanLineFill;
        private System.Windows.Forms.Button btnBoundaryFill;
        private System.Windows.Forms.Button btnFloodFill;
    }
}