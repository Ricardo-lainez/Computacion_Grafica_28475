namespace WindowsFormsApp1
{
    partial class Rectangulo
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
            this.lblBaseRectangulo = new System.Windows.Forms.Label();
            this.lblAlturaRectangulo = new System.Windows.Forms.Label();
            this.txtBaseRectangulo = new System.Windows.Forms.TextBox();
            this.txtalturaRectangulo = new System.Windows.Forms.TextBox();
            this.btnCalcularArea = new System.Windows.Forms.Button();
            this.btnCalcularPerimetro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaseRectangulo
            // 
            this.lblBaseRectangulo.AutoSize = true;
            this.lblBaseRectangulo.Location = new System.Drawing.Point(272, 105);
            this.lblBaseRectangulo.Name = "lblBaseRectangulo";
            this.lblBaseRectangulo.Size = new System.Drawing.Size(149, 13);
            this.lblBaseRectangulo.TabIndex = 0;
            this.lblBaseRectangulo.Text = "Ingrese la base del rectangulo";
            // 
            // lblAlturaRectangulo
            // 
            this.lblAlturaRectangulo.AutoSize = true;
            this.lblAlturaRectangulo.Location = new System.Drawing.Point(272, 152);
            this.lblAlturaRectangulo.Name = "lblAlturaRectangulo";
            this.lblAlturaRectangulo.Size = new System.Drawing.Size(152, 13);
            this.lblAlturaRectangulo.TabIndex = 1;
            this.lblAlturaRectangulo.Text = "Ingrese la altura del rectangulo";
            // 
            // txtBaseRectangulo
            // 
            this.txtBaseRectangulo.Location = new System.Drawing.Point(465, 97);
            this.txtBaseRectangulo.Name = "txtBaseRectangulo";
            this.txtBaseRectangulo.Size = new System.Drawing.Size(100, 20);
            this.txtBaseRectangulo.TabIndex = 2;
            // 
            // txtalturaRectangulo
            // 
            this.txtalturaRectangulo.Location = new System.Drawing.Point(465, 144);
            this.txtalturaRectangulo.Name = "txtalturaRectangulo";
            this.txtalturaRectangulo.Size = new System.Drawing.Size(100, 20);
            this.txtalturaRectangulo.TabIndex = 3;
            // 
            // btnCalcularArea
            // 
            this.btnCalcularArea.Location = new System.Drawing.Point(275, 207);
            this.btnCalcularArea.Name = "btnCalcularArea";
            this.btnCalcularArea.Size = new System.Drawing.Size(81, 23);
            this.btnCalcularArea.TabIndex = 4;
            this.btnCalcularArea.Text = "Calcular area";
            this.btnCalcularArea.UseVisualStyleBackColor = true;
            this.btnCalcularArea.Click += new System.EventHandler(this.btnCalcularArea_Click);
            // 
            // btnCalcularPerimetro
            // 
            this.btnCalcularPerimetro.Location = new System.Drawing.Point(444, 207);
            this.btnCalcularPerimetro.Name = "btnCalcularPerimetro";
            this.btnCalcularPerimetro.Size = new System.Drawing.Size(106, 23);
            this.btnCalcularPerimetro.TabIndex = 5;
            this.btnCalcularPerimetro.Text = "Calcular Perimetro";
            this.btnCalcularPerimetro.UseVisualStyleBackColor = true;
            this.btnCalcularPerimetro.Click += new System.EventHandler(this.btnCalcularPerimetro_Click);
            // 
            // Rectangulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalcularPerimetro);
            this.Controls.Add(this.btnCalcularArea);
            this.Controls.Add(this.txtalturaRectangulo);
            this.Controls.Add(this.txtBaseRectangulo);
            this.Controls.Add(this.lblAlturaRectangulo);
            this.Controls.Add(this.lblBaseRectangulo);
            this.Name = "Rectangulo";
            this.Text = "Rectangulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaseRectangulo;
        private System.Windows.Forms.Label lblAlturaRectangulo;
        private System.Windows.Forms.TextBox txtBaseRectangulo;
        private System.Windows.Forms.TextBox txtalturaRectangulo;
        private System.Windows.Forms.Button btnCalcularArea;
        private System.Windows.Forms.Button btnCalcularPerimetro;
    }
}