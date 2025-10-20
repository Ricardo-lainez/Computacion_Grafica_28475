namespace WindowsFormsApp1
{
    partial class Circulo
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
            this.lblRadioCirculo = new System.Windows.Forms.Label();
            this.btnCalcularArea = new System.Windows.Forms.Button();
            this.btnCalcularPerimetro = new System.Windows.Forms.Button();
            this.txtRadioCirculo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRadioCirculo
            // 
            this.lblRadioCirculo.AutoSize = true;
            this.lblRadioCirculo.Location = new System.Drawing.Point(263, 121);
            this.lblRadioCirculo.Name = "lblRadioCirculo";
            this.lblRadioCirculo.Size = new System.Drawing.Size(130, 13);
            this.lblRadioCirculo.TabIndex = 0;
            this.lblRadioCirculo.Text = "Ingrese el radio del circulo";
            // 
            // btnCalcularArea
            // 
            this.btnCalcularArea.Location = new System.Drawing.Point(242, 190);
            this.btnCalcularArea.Name = "btnCalcularArea";
            this.btnCalcularArea.Size = new System.Drawing.Size(88, 23);
            this.btnCalcularArea.TabIndex = 2;
            this.btnCalcularArea.Text = "Calcular area";
            this.btnCalcularArea.UseVisualStyleBackColor = true;
            this.btnCalcularArea.Click += new System.EventHandler(this.btnCalcularArea_Click);
            // 
            // btnCalcularPerimetro
            // 
            this.btnCalcularPerimetro.Location = new System.Drawing.Point(458, 190);
            this.btnCalcularPerimetro.Name = "btnCalcularPerimetro";
            this.btnCalcularPerimetro.Size = new System.Drawing.Size(104, 23);
            this.btnCalcularPerimetro.TabIndex = 3;
            this.btnCalcularPerimetro.Text = "Calcular perimetro";
            this.btnCalcularPerimetro.UseVisualStyleBackColor = true;
            this.btnCalcularPerimetro.Click += new System.EventHandler(this.btnCalcularPerimetro_Click);
            // 
            // txtRadioCirculo
            // 
            this.txtRadioCirculo.Location = new System.Drawing.Point(438, 118);
            this.txtRadioCirculo.Name = "txtRadioCirculo";
            this.txtRadioCirculo.Size = new System.Drawing.Size(100, 20);
            this.txtRadioCirculo.TabIndex = 4;
            // 
            // Circulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRadioCirculo);
            this.Controls.Add(this.btnCalcularPerimetro);
            this.Controls.Add(this.btnCalcularArea);
            this.Controls.Add(this.lblRadioCirculo);
            this.Name = "Circulo";
            this.Text = "Circulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRadioCirculo;
        private System.Windows.Forms.Button btnCalcularArea;
        private System.Windows.Forms.Button btnCalcularPerimetro;
        private System.Windows.Forms.TextBox txtRadioCirculo;
    }
}