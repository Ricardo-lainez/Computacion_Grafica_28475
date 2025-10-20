namespace WindowsFormsApp1
{
    partial class Trapecio
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
            this.lblBaseMenor = new System.Windows.Forms.Label();
            this.lblBaseMayor = new System.Windows.Forms.Label();
            this.txtBaseMenorTrapecio = new System.Windows.Forms.TextBox();
            this.txtBaseMayorTrapecio = new System.Windows.Forms.TextBox();
            this.btnCalcularArea = new System.Windows.Forms.Button();
            this.btnCalcularPerimetro = new System.Windows.Forms.Button();
            this.lblAlturaTrapecio = new System.Windows.Forms.Label();
            this.txtAlturaTrapecio = new System.Windows.Forms.TextBox();
            this.lblEnunTrapIsos = new System.Windows.Forms.Label();
            this.lblEnunTrapRecEsca = new System.Windows.Forms.Label();
            this.lblBaseMenorTrapecioRE = new System.Windows.Forms.Label();
            this.lblBaseMayorTrapecioRE = new System.Windows.Forms.Label();
            this.lblAlturaTrapecioRE = new System.Windows.Forms.Label();
            this.txtBaseMenorTrapecioRE = new System.Windows.Forms.TextBox();
            this.txtBaseMayorTrapecioRE = new System.Windows.Forms.TextBox();
            this.txtAlturaTrapecioRE = new System.Windows.Forms.TextBox();
            this.lblLadoIzqRE = new System.Windows.Forms.Label();
            this.lblLadoDerRE = new System.Windows.Forms.Label();
            this.txtLadoIzqTrapecioRE = new System.Windows.Forms.TextBox();
            this.txtLadoDerTrapecioRE = new System.Windows.Forms.TextBox();
            this.btnCalcularAreaRE = new System.Windows.Forms.Button();
            this.btnCalcularPerimetroRE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaseMenor
            // 
            this.lblBaseMenor.AutoSize = true;
            this.lblBaseMenor.Location = new System.Drawing.Point(42, 117);
            this.lblBaseMenor.Name = "lblBaseMenor";
            this.lblBaseMenor.Size = new System.Drawing.Size(169, 13);
            this.lblBaseMenor.TabIndex = 0;
            this.lblBaseMenor.Text = "Ingrese la base menor del trapecio";
            // 
            // lblBaseMayor
            // 
            this.lblBaseMayor.AutoSize = true;
            this.lblBaseMayor.Location = new System.Drawing.Point(42, 143);
            this.lblBaseMayor.Name = "lblBaseMayor";
            this.lblBaseMayor.Size = new System.Drawing.Size(168, 13);
            this.lblBaseMayor.TabIndex = 1;
            this.lblBaseMayor.Text = "Ingrese la base mayor del trapecio";
            // 
            // txtBaseMenorTrapecio
            // 
            this.txtBaseMenorTrapecio.Location = new System.Drawing.Point(250, 114);
            this.txtBaseMenorTrapecio.Name = "txtBaseMenorTrapecio";
            this.txtBaseMenorTrapecio.Size = new System.Drawing.Size(100, 20);
            this.txtBaseMenorTrapecio.TabIndex = 2;
            // 
            // txtBaseMayorTrapecio
            // 
            this.txtBaseMayorTrapecio.Location = new System.Drawing.Point(250, 140);
            this.txtBaseMayorTrapecio.Name = "txtBaseMayorTrapecio";
            this.txtBaseMayorTrapecio.Size = new System.Drawing.Size(100, 20);
            this.txtBaseMayorTrapecio.TabIndex = 3;
            // 
            // btnCalcularArea
            // 
            this.btnCalcularArea.Location = new System.Drawing.Point(84, 260);
            this.btnCalcularArea.Name = "btnCalcularArea";
            this.btnCalcularArea.Size = new System.Drawing.Size(81, 23);
            this.btnCalcularArea.TabIndex = 4;
            this.btnCalcularArea.Text = "Calcular area";
            this.btnCalcularArea.UseVisualStyleBackColor = true;
            this.btnCalcularArea.Click += new System.EventHandler(this.btnCalcularArea_Click);
            // 
            // btnCalcularPerimetro
            // 
            this.btnCalcularPerimetro.Location = new System.Drawing.Point(224, 260);
            this.btnCalcularPerimetro.Name = "btnCalcularPerimetro";
            this.btnCalcularPerimetro.Size = new System.Drawing.Size(100, 23);
            this.btnCalcularPerimetro.TabIndex = 5;
            this.btnCalcularPerimetro.Text = "Calcular perimetro";
            this.btnCalcularPerimetro.UseVisualStyleBackColor = true;
            this.btnCalcularPerimetro.Click += new System.EventHandler(this.btnCalcularPerimetro_Click);
            // 
            // lblAlturaTrapecio
            // 
            this.lblAlturaTrapecio.AutoSize = true;
            this.lblAlturaTrapecio.Location = new System.Drawing.Point(45, 166);
            this.lblAlturaTrapecio.Name = "lblAlturaTrapecio";
            this.lblAlturaTrapecio.Size = new System.Drawing.Size(140, 13);
            this.lblAlturaTrapecio.TabIndex = 6;
            this.lblAlturaTrapecio.Text = "Ingrese la altura del trapecio";
            // 
            // txtAlturaTrapecio
            // 
            this.txtAlturaTrapecio.Location = new System.Drawing.Point(250, 166);
            this.txtAlturaTrapecio.Name = "txtAlturaTrapecio";
            this.txtAlturaTrapecio.Size = new System.Drawing.Size(100, 20);
            this.txtAlturaTrapecio.TabIndex = 7;
            // 
            // lblEnunTrapIsos
            // 
            this.lblEnunTrapIsos.AutoSize = true;
            this.lblEnunTrapIsos.Location = new System.Drawing.Point(78, 44);
            this.lblEnunTrapIsos.Name = "lblEnunTrapIsos";
            this.lblEnunTrapIsos.Size = new System.Drawing.Size(246, 13);
            this.lblEnunTrapIsos.TabIndex = 8;
            this.lblEnunTrapIsos.Text = "Calculo de area y perimetro para trapecio isosceles";
            // 
            // lblEnunTrapRecEsca
            // 
            this.lblEnunTrapRecEsca.AutoSize = true;
            this.lblEnunTrapRecEsca.Location = new System.Drawing.Point(390, 44);
            this.lblEnunTrapRecEsca.Name = "lblEnunTrapRecEsca";
            this.lblEnunTrapRecEsca.Size = new System.Drawing.Size(314, 13);
            this.lblEnunTrapRecEsca.TabIndex = 9;
            this.lblEnunTrapRecEsca.Text = "Calculo de area y perimetro para trapecio Rectangulo o Escaleno";
            // 
            // lblBaseMenorTrapecioRE
            // 
            this.lblBaseMenorTrapecioRE.AutoSize = true;
            this.lblBaseMenorTrapecioRE.Location = new System.Drawing.Point(390, 86);
            this.lblBaseMenorTrapecioRE.Name = "lblBaseMenorTrapecioRE";
            this.lblBaseMenorTrapecioRE.Size = new System.Drawing.Size(169, 13);
            this.lblBaseMenorTrapecioRE.TabIndex = 10;
            this.lblBaseMenorTrapecioRE.Text = "Ingrese la base menor del trapecio";
            // 
            // lblBaseMayorTrapecioRE
            // 
            this.lblBaseMayorTrapecioRE.AutoSize = true;
            this.lblBaseMayorTrapecioRE.Location = new System.Drawing.Point(390, 116);
            this.lblBaseMayorTrapecioRE.Name = "lblBaseMayorTrapecioRE";
            this.lblBaseMayorTrapecioRE.Size = new System.Drawing.Size(168, 13);
            this.lblBaseMayorTrapecioRE.TabIndex = 11;
            this.lblBaseMayorTrapecioRE.Text = "Ingrese la base mayor del trapecio";
            // 
            // lblAlturaTrapecioRE
            // 
            this.lblAlturaTrapecioRE.AutoSize = true;
            this.lblAlturaTrapecioRE.Location = new System.Drawing.Point(390, 147);
            this.lblAlturaTrapecioRE.Name = "lblAlturaTrapecioRE";
            this.lblAlturaTrapecioRE.Size = new System.Drawing.Size(140, 13);
            this.lblAlturaTrapecioRE.TabIndex = 12;
            this.lblAlturaTrapecioRE.Text = "Ingrese la altura del trapecio";
            // 
            // txtBaseMenorTrapecioRE
            // 
            this.txtBaseMenorTrapecioRE.Location = new System.Drawing.Point(604, 86);
            this.txtBaseMenorTrapecioRE.Name = "txtBaseMenorTrapecioRE";
            this.txtBaseMenorTrapecioRE.Size = new System.Drawing.Size(100, 20);
            this.txtBaseMenorTrapecioRE.TabIndex = 13;
            // 
            // txtBaseMayorTrapecioRE
            // 
            this.txtBaseMayorTrapecioRE.Location = new System.Drawing.Point(604, 113);
            this.txtBaseMayorTrapecioRE.Name = "txtBaseMayorTrapecioRE";
            this.txtBaseMayorTrapecioRE.Size = new System.Drawing.Size(100, 20);
            this.txtBaseMayorTrapecioRE.TabIndex = 14;
            // 
            // txtAlturaTrapecioRE
            // 
            this.txtAlturaTrapecioRE.Location = new System.Drawing.Point(604, 144);
            this.txtAlturaTrapecioRE.Name = "txtAlturaTrapecioRE";
            this.txtAlturaTrapecioRE.Size = new System.Drawing.Size(100, 20);
            this.txtAlturaTrapecioRE.TabIndex = 15;
            // 
            // lblLadoIzqRE
            // 
            this.lblLadoIzqRE.AutoSize = true;
            this.lblLadoIzqRE.Location = new System.Drawing.Point(390, 173);
            this.lblLadoIzqRE.Name = "lblLadoIzqRE";
            this.lblLadoIzqRE.Size = new System.Drawing.Size(179, 13);
            this.lblLadoIzqRE.TabIndex = 16;
            this.lblLadoIzqRE.Text = "Ingrese el lado izquierdo del trapecio";
            // 
            // lblLadoDerRE
            // 
            this.lblLadoDerRE.AutoSize = true;
            this.lblLadoDerRE.Location = new System.Drawing.Point(390, 199);
            this.lblLadoDerRE.Name = "lblLadoDerRE";
            this.lblLadoDerRE.Size = new System.Drawing.Size(176, 13);
            this.lblLadoDerRE.TabIndex = 17;
            this.lblLadoDerRE.Text = "Ingrese el lado derecho del trapecio";
            // 
            // txtLadoIzqTrapecioRE
            // 
            this.txtLadoIzqTrapecioRE.Location = new System.Drawing.Point(604, 170);
            this.txtLadoIzqTrapecioRE.Name = "txtLadoIzqTrapecioRE";
            this.txtLadoIzqTrapecioRE.Size = new System.Drawing.Size(100, 20);
            this.txtLadoIzqTrapecioRE.TabIndex = 18;
            // 
            // txtLadoDerTrapecioRE
            // 
            this.txtLadoDerTrapecioRE.Location = new System.Drawing.Point(604, 196);
            this.txtLadoDerTrapecioRE.Name = "txtLadoDerTrapecioRE";
            this.txtLadoDerTrapecioRE.Size = new System.Drawing.Size(100, 20);
            this.txtLadoDerTrapecioRE.TabIndex = 19;
            // 
            // btnCalcularAreaRE
            // 
            this.btnCalcularAreaRE.Location = new System.Drawing.Point(444, 260);
            this.btnCalcularAreaRE.Name = "btnCalcularAreaRE";
            this.btnCalcularAreaRE.Size = new System.Drawing.Size(86, 23);
            this.btnCalcularAreaRE.TabIndex = 20;
            this.btnCalcularAreaRE.Text = "Calcular area";
            this.btnCalcularAreaRE.UseVisualStyleBackColor = true;
            this.btnCalcularAreaRE.Click += new System.EventHandler(this.btnCalcularAreaRE_Click);
            // 
            // btnCalcularPerimetroRE
            // 
            this.btnCalcularPerimetroRE.Location = new System.Drawing.Point(563, 260);
            this.btnCalcularPerimetroRE.Name = "btnCalcularPerimetroRE";
            this.btnCalcularPerimetroRE.Size = new System.Drawing.Size(101, 23);
            this.btnCalcularPerimetroRE.TabIndex = 21;
            this.btnCalcularPerimetroRE.Text = "Calcular perimetro";
            this.btnCalcularPerimetroRE.UseVisualStyleBackColor = true;
            this.btnCalcularPerimetroRE.Click += new System.EventHandler(this.btnCalcularPerimetroRE_Click);
            // 
            // Trapecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalcularPerimetroRE);
            this.Controls.Add(this.btnCalcularAreaRE);
            this.Controls.Add(this.txtLadoDerTrapecioRE);
            this.Controls.Add(this.txtLadoIzqTrapecioRE);
            this.Controls.Add(this.lblLadoDerRE);
            this.Controls.Add(this.lblLadoIzqRE);
            this.Controls.Add(this.txtAlturaTrapecioRE);
            this.Controls.Add(this.txtBaseMayorTrapecioRE);
            this.Controls.Add(this.txtBaseMenorTrapecioRE);
            this.Controls.Add(this.lblAlturaTrapecioRE);
            this.Controls.Add(this.lblBaseMayorTrapecioRE);
            this.Controls.Add(this.lblBaseMenorTrapecioRE);
            this.Controls.Add(this.lblEnunTrapRecEsca);
            this.Controls.Add(this.lblEnunTrapIsos);
            this.Controls.Add(this.txtAlturaTrapecio);
            this.Controls.Add(this.lblAlturaTrapecio);
            this.Controls.Add(this.btnCalcularPerimetro);
            this.Controls.Add(this.btnCalcularArea);
            this.Controls.Add(this.txtBaseMayorTrapecio);
            this.Controls.Add(this.txtBaseMenorTrapecio);
            this.Controls.Add(this.lblBaseMayor);
            this.Controls.Add(this.lblBaseMenor);
            this.Name = "Trapecio";
            this.Text = "Trapecio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaseMenor;
        private System.Windows.Forms.Label lblBaseMayor;
        private System.Windows.Forms.TextBox txtBaseMenorTrapecio;
        private System.Windows.Forms.TextBox txtBaseMayorTrapecio;
        private System.Windows.Forms.Button btnCalcularArea;
        private System.Windows.Forms.Button btnCalcularPerimetro;
        private System.Windows.Forms.Label lblAlturaTrapecio;
        private System.Windows.Forms.TextBox txtAlturaTrapecio;
        private System.Windows.Forms.Label lblEnunTrapIsos;
        private System.Windows.Forms.Label lblEnunTrapRecEsca;
        private System.Windows.Forms.Label lblBaseMenorTrapecioRE;
        private System.Windows.Forms.Label lblBaseMayorTrapecioRE;
        private System.Windows.Forms.Label lblAlturaTrapecioRE;
        private System.Windows.Forms.TextBox txtBaseMenorTrapecioRE;
        private System.Windows.Forms.TextBox txtBaseMayorTrapecioRE;
        private System.Windows.Forms.TextBox txtAlturaTrapecioRE;
        private System.Windows.Forms.Label lblLadoIzqRE;
        private System.Windows.Forms.Label lblLadoDerRE;
        private System.Windows.Forms.TextBox txtLadoIzqTrapecioRE;
        private System.Windows.Forms.TextBox txtLadoDerTrapecioRE;
        private System.Windows.Forms.Button btnCalcularAreaRE;
        private System.Windows.Forms.Button btnCalcularPerimetroRE;
    }
}