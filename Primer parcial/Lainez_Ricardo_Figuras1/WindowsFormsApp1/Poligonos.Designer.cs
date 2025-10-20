namespace WindowsFormsApp1
{
    partial class Poligonos
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
            this.lblCantidadDeLados = new System.Windows.Forms.Label();
            this.lblLongitudLado = new System.Windows.Forms.Label();
            this.txtCantidadDeLados = new System.Windows.Forms.TextBox();
            this.txtLongitudDeLado = new System.Windows.Forms.TextBox();
            this.btnCalcularArea = new System.Windows.Forms.Button();
            this.btnCalcularPerimetro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCantidadDeLados
            // 
            this.lblCantidadDeLados.AutoSize = true;
            this.lblCantidadDeLados.Location = new System.Drawing.Point(266, 90);
            this.lblCantidadDeLados.Name = "lblCantidadDeLados";
            this.lblCantidadDeLados.Size = new System.Drawing.Size(143, 13);
            this.lblCantidadDeLados.TabIndex = 0;
            this.lblCantidadDeLados.Text = "Ingrese la cantidad de lados:";
            // 
            // lblLongitudLado
            // 
            this.lblLongitudLado.AutoSize = true;
            this.lblLongitudLado.Location = new System.Drawing.Point(266, 150);
            this.lblLongitudLado.Name = "lblLongitudLado";
            this.lblLongitudLado.Size = new System.Drawing.Size(133, 13);
            this.lblLongitudLado.TabIndex = 1;
            this.lblLongitudLado.Text = "Ingrese la longitud del lado";
            // 
            // txtCantidadDeLados
            // 
            this.txtCantidadDeLados.Location = new System.Drawing.Point(430, 87);
            this.txtCantidadDeLados.Name = "txtCantidadDeLados";
            this.txtCantidadDeLados.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadDeLados.TabIndex = 2;
            // 
            // txtLongitudDeLado
            // 
            this.txtLongitudDeLado.Location = new System.Drawing.Point(430, 150);
            this.txtLongitudDeLado.Name = "txtLongitudDeLado";
            this.txtLongitudDeLado.Size = new System.Drawing.Size(100, 20);
            this.txtLongitudDeLado.TabIndex = 3;
            // 
            // btnCalcularArea
            // 
            this.btnCalcularArea.Location = new System.Drawing.Point(279, 200);
            this.btnCalcularArea.Name = "btnCalcularArea";
            this.btnCalcularArea.Size = new System.Drawing.Size(81, 23);
            this.btnCalcularArea.TabIndex = 4;
            this.btnCalcularArea.Text = "Calcular area";
            this.btnCalcularArea.UseVisualStyleBackColor = true;
            this.btnCalcularArea.Click += new System.EventHandler(this.btnCalcularArea_Click);
            // 
            // btnCalcularPerimetro
            // 
            this.btnCalcularPerimetro.Location = new System.Drawing.Point(413, 199);
            this.btnCalcularPerimetro.Name = "btnCalcularPerimetro";
            this.btnCalcularPerimetro.Size = new System.Drawing.Size(105, 23);
            this.btnCalcularPerimetro.TabIndex = 5;
            this.btnCalcularPerimetro.Text = "Calcular perimetro";
            this.btnCalcularPerimetro.UseVisualStyleBackColor = true;
            this.btnCalcularPerimetro.Click += new System.EventHandler(this.btnCalcularPerimetro_Click);
            // 
            // Poligonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalcularPerimetro);
            this.Controls.Add(this.btnCalcularArea);
            this.Controls.Add(this.txtLongitudDeLado);
            this.Controls.Add(this.txtCantidadDeLados);
            this.Controls.Add(this.lblLongitudLado);
            this.Controls.Add(this.lblCantidadDeLados);
            this.Name = "Poligonos";
            this.Text = "Poligonos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidadDeLados;
        private System.Windows.Forms.Label lblLongitudLado;
        private System.Windows.Forms.TextBox txtCantidadDeLados;
        private System.Windows.Forms.TextBox txtLongitudDeLado;
        private System.Windows.Forms.Button btnCalcularArea;
        private System.Windows.Forms.Button btnCalcularPerimetro;
    }
}