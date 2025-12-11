namespace LainezRicardoLeccion1
{
    partial class frmLeccion1
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
            this.btnGraficar = new System.Windows.Forms.Button();
            this.lblCantidadLinea = new System.Windows.Forms.Label();
            this.txtCantidadLinea = new System.Windows.Forms.TextBox();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.btnResetear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(41, 155);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // lblCantidadLinea
            // 
            this.lblCantidadLinea.AutoSize = true;
            this.lblCantidadLinea.Location = new System.Drawing.Point(47, 52);
            this.lblCantidadLinea.Name = "lblCantidadLinea";
            this.lblCantidadLinea.Size = new System.Drawing.Size(145, 13);
            this.lblCantidadLinea.TabIndex = 1;
            this.lblCantidadLinea.Text = "Ingrese la cantidad de lineas:";
            // 
            // txtCantidadLinea
            // 
            this.txtCantidadLinea.Location = new System.Drawing.Point(67, 84);
            this.txtCantidadLinea.Name = "txtCantidadLinea";
            this.txtCantidadLinea.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadLinea.TabIndex = 2;
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(222, 30);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(534, 390);
            this.ptbGrafica.TabIndex = 3;
            this.ptbGrafica.TabStop = false;
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(123, 154);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 4;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // frmLeccion1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.ptbGrafica);
            this.Controls.Add(this.txtCantidadLinea);
            this.Controls.Add(this.lblCantidadLinea);
            this.Controls.Add(this.btnGraficar);
            this.Name = "frmLeccion1";
            this.Text = "Lección 1";
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Label lblCantidadLinea;
        private System.Windows.Forms.TextBox txtCantidadLinea;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.Button btnResetear;
    }
}

