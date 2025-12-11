namespace WinAppAlgoritmos
{
    partial class Circunferencia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnScanLineFill = new System.Windows.Forms.Button();
            this.btnBoundaryFill = new System.Windows.Forms.Button();
            this.btnFloodFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el radio:";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(94, 39);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(77, 20);
            this.txtRadio.TabIndex = 1;
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(57, 35);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(15, 19);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(540, 381);
            this.ptbGrafica.TabIndex = 3;
            this.ptbGrafica.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRadio);
            this.groupBox1.Location = new System.Drawing.Point(21, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 84);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGraficar);
            this.groupBox2.Location = new System.Drawing.Point(21, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 95);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ptbGrafica);
            this.groupBox3.Location = new System.Drawing.Point(218, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 415);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grafica";
            // 
            // btnScanLineFill
            // 
            this.btnScanLineFill.Location = new System.Drawing.Point(44, 354);
            this.btnScanLineFill.Name = "btnScanLineFill";
            this.btnScanLineFill.Size = new System.Drawing.Size(131, 23);
            this.btnScanLineFill.TabIndex = 20;
            this.btnScanLineFill.Text = "Algoritmo Scan Line Fill";
            this.btnScanLineFill.UseVisualStyleBackColor = true;
            this.btnScanLineFill.Click += new System.EventHandler(this.btnScanLineFill_Click);
            // 
            // btnBoundaryFill
            // 
            this.btnBoundaryFill.Location = new System.Drawing.Point(44, 324);
            this.btnBoundaryFill.Name = "btnBoundaryFill";
            this.btnBoundaryFill.Size = new System.Drawing.Size(131, 23);
            this.btnBoundaryFill.TabIndex = 19;
            this.btnBoundaryFill.Text = "Algoritmo Boundary Fill";
            this.btnBoundaryFill.UseVisualStyleBackColor = true;
            this.btnBoundaryFill.Click += new System.EventHandler(this.btnBoundaryFill_Click);
            // 
            // btnFloodFill
            // 
            this.btnFloodFill.Location = new System.Drawing.Point(44, 294);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(131, 23);
            this.btnFloodFill.TabIndex = 18;
            this.btnFloodFill.Text = "Algoritmo flood fill";
            this.btnFloodFill.UseVisualStyleBackColor = true;
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFill_Click);
            // 
            // Circunferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnScanLineFill);
            this.Controls.Add(this.btnBoundaryFill);
            this.Controls.Add(this.btnFloodFill);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Circunferencia";
            this.Text = "Circunferencia";
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnScanLineFill;
        private System.Windows.Forms.Button btnBoundaryFill;
        private System.Windows.Forms.Button btnFloodFill;
    }
}