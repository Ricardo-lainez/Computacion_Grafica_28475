namespace WinAppStar
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxGrafico = new System.Windows.Forms.PictureBox();
            this.buttonGraficar = new System.Windows.Forms.Button();
            this.buttonResetear = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.altura = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafico)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.altura);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSalir);
            this.groupBox2.Controls.Add(this.buttonResetear);
            this.groupBox2.Controls.Add(this.buttonGraficar);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proceso";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxGrafico);
            this.groupBox3.Location = new System.Drawing.Point(288, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 412);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grafico";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Altura (centro del punto para arriba)";
            // 
            // pictureBoxGrafico
            // 
            this.pictureBoxGrafico.Location = new System.Drawing.Point(6, 30);
            this.pictureBoxGrafico.Name = "pictureBoxGrafico";
            this.pictureBoxGrafico.Size = new System.Drawing.Size(466, 355);
            this.pictureBoxGrafico.TabIndex = 0;
            this.pictureBoxGrafico.TabStop = false;
            // 
            // buttonGraficar
            // 
            this.buttonGraficar.Location = new System.Drawing.Point(9, 38);
            this.buttonGraficar.Name = "buttonGraficar";
            this.buttonGraficar.Size = new System.Drawing.Size(75, 23);
            this.buttonGraficar.TabIndex = 1;
            this.buttonGraficar.Text = "Graficar";
            this.buttonGraficar.UseVisualStyleBackColor = true;
            this.buttonGraficar.Click += new System.EventHandler(this.buttonGraficar_Click);
            // 
            // buttonResetear
            // 
            this.buttonResetear.Location = new System.Drawing.Point(98, 39);
            this.buttonResetear.Name = "buttonResetear";
            this.buttonResetear.Size = new System.Drawing.Size(75, 23);
            this.buttonResetear.TabIndex = 2;
            this.buttonResetear.Text = "Resetear";
            this.buttonResetear.UseVisualStyleBackColor = true;
            this.buttonResetear.Click += new System.EventHandler(this.buttonResetear_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(189, 39);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 3;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // altura
            // 
            this.altura.Location = new System.Drawing.Point(49, 44);
            this.altura.Name = "altura";
            this.altura.Size = new System.Drawing.Size(144, 20);
            this.altura.TabIndex = 1;
            this.altura.TextChanged += new System.EventHandler(this.altura_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox altura;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonResetear;
        private System.Windows.Forms.Button buttonGraficar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBoxGrafico;
    }
}

