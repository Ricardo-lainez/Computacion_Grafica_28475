namespace WindowsFormsApp1
{
    partial class Triangulo
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
            this.lblBaseTriangulo = new System.Windows.Forms.Label();
            this.lblAlturaTriangulo = new System.Windows.Forms.Label();
            this.txtBaseTriangulo = new System.Windows.Forms.TextBox();
            this.txtAlturaTriangulo = new System.Windows.Forms.TextBox();
            this.btnCalcularArea = new System.Windows.Forms.Button();
            this.btnCalcularPerimetro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaseTriangulo
            // 
            this.lblBaseTriangulo.AutoSize = true;
            this.lblBaseTriangulo.Location = new System.Drawing.Point(272, 80);
            this.lblBaseTriangulo.Name = "lblBaseTriangulo";
            this.lblBaseTriangulo.Size = new System.Drawing.Size(139, 13);
            this.lblBaseTriangulo.TabIndex = 0;
            this.lblBaseTriangulo.Text = "Ingrese la base del triangulo";
            // 
            // lblAlturaTriangulo
            // 
            this.lblAlturaTriangulo.AutoSize = true;
            this.lblAlturaTriangulo.Location = new System.Drawing.Point(272, 129);
            this.lblAlturaTriangulo.Name = "lblAlturaTriangulo";
            this.lblAlturaTriangulo.Size = new System.Drawing.Size(142, 13);
            this.lblAlturaTriangulo.TabIndex = 1;
            this.lblAlturaTriangulo.Text = "Ingrese la altura del triangulo";
            // 
            // txtBaseTriangulo
            // 
            this.txtBaseTriangulo.Location = new System.Drawing.Point(432, 77);
            this.txtBaseTriangulo.Name = "txtBaseTriangulo";
            this.txtBaseTriangulo.Size = new System.Drawing.Size(100, 20);
            this.txtBaseTriangulo.TabIndex = 2;
            // 
            // txtAlturaTriangulo
            // 
            this.txtAlturaTriangulo.Location = new System.Drawing.Point(432, 122);
            this.txtAlturaTriangulo.Name = "txtAlturaTriangulo";
            this.txtAlturaTriangulo.Size = new System.Drawing.Size(100, 20);
            this.txtAlturaTriangulo.TabIndex = 3;
            // 
            // btnCalcularArea
            // 
            this.btnCalcularArea.Location = new System.Drawing.Point(275, 190);
            this.btnCalcularArea.Name = "btnCalcularArea";
            this.btnCalcularArea.Size = new System.Drawing.Size(89, 23);
            this.btnCalcularArea.TabIndex = 4;
            this.btnCalcularArea.Text = "Calcular area";
            this.btnCalcularArea.UseVisualStyleBackColor = true;
            this.btnCalcularArea.Click += new System.EventHandler(this.btnCalcularArea_Click);
            // 
            // btnCalcularPerimetro
            // 
            this.btnCalcularPerimetro.Location = new System.Drawing.Point(432, 190);
            this.btnCalcularPerimetro.Name = "btnCalcularPerimetro";
            this.btnCalcularPerimetro.Size = new System.Drawing.Size(100, 23);
            this.btnCalcularPerimetro.TabIndex = 5;
            this.btnCalcularPerimetro.Text = "Calcular perimetro";
            this.btnCalcularPerimetro.UseVisualStyleBackColor = true;
            this.btnCalcularPerimetro.Click += new System.EventHandler(this.btnCalcularPerimetro_Click);
            // 
            // Triangulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalcularPerimetro);
            this.Controls.Add(this.btnCalcularArea);
            this.Controls.Add(this.txtAlturaTriangulo);
            this.Controls.Add(this.txtBaseTriangulo);
            this.Controls.Add(this.lblAlturaTriangulo);
            this.Controls.Add(this.lblBaseTriangulo);
            this.Name = "Triangulo";
            this.Text = "Triangulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaseTriangulo;
        private System.Windows.Forms.Label lblAlturaTriangulo;
        private System.Windows.Forms.TextBox txtBaseTriangulo;
        private System.Windows.Forms.TextBox txtAlturaTriangulo;
        private System.Windows.Forms.Button btnCalcularArea;
        private System.Windows.Forms.Button btnCalcularPerimetro;
    }
}