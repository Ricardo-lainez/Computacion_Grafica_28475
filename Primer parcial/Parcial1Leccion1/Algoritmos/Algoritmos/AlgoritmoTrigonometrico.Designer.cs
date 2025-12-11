namespace Algoritmos
{
    partial class AlgoritmoTrigonometrico
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(49, 149);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 7;
            this.btnGraficar.Text = "Graficar ";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptbGrafica);
            this.groupBox1.Location = new System.Drawing.Point(211, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 425);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(7, 20);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(558, 390);
            this.ptbGrafica.TabIndex = 0;
            this.ptbGrafica.TabStop = false;
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(111, 92);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(39, 20);
            this.txtRadio.TabIndex = 5;
            this.txtRadio.TextChanged += new System.EventHandler(this.txtRadio_TextChanged);
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(18, 95);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(87, 13);
            this.lblRadio.TabIndex = 4;
            this.lblRadio.Text = "Ingrese el Radio:";
            this.lblRadio.Click += new System.EventHandler(this.lblRadio_Click);
            // 
            // AlgoritmoTrigonometrico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.lblRadio);
            this.Name = "AlgoritmoTrigonometrico";
            this.Text = "AlgoritmoTrigonometrico";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
    }
}