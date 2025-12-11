namespace WinAppStar
{
    partial class frmStar
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
            this.grbEntrada = new System.Windows.Forms.GroupBox();
            this.grbProceso = new System.Windows.Forms.GroupBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grbGrafica = new System.Windows.Forms.GroupBox();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.grbEntrada.SuspendLayout();
            this.grbProceso.SuspendLayout();
            this.grbGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // grbEntrada
            // 
            this.grbEntrada.Controls.Add(this.txtAltura);
            this.grbEntrada.Controls.Add(this.lblAltura);
            this.grbEntrada.Location = new System.Drawing.Point(12, 60);
            this.grbEntrada.Name = "grbEntrada";
            this.grbEntrada.Size = new System.Drawing.Size(255, 100);
            this.grbEntrada.TabIndex = 0;
            this.grbEntrada.TabStop = false;
            this.grbEntrada.Text = "Entradas";
            // 
            // grbProceso
            // 
            this.grbProceso.Controls.Add(this.btnSalir);
            this.grbProceso.Controls.Add(this.btnResetear);
            this.grbProceso.Controls.Add(this.btnGraficar);
            this.grbProceso.Location = new System.Drawing.Point(12, 197);
            this.grbProceso.Name = "grbProceso";
            this.grbProceso.Size = new System.Drawing.Size(255, 100);
            this.grbProceso.TabIndex = 1;
            this.grbProceso.TabStop = false;
            this.grbProceso.Text = "Proceso";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(23, 20);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(143, 13);
            this.lblAltura.TabIndex = 0;
            this.lblAltura.Text = "Altura (Centro - punto Arriba):";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(75, 50);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(100, 20);
            this.txtAltura.TabIndex = 1;
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(7, 49);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(89, 48);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(171, 47);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbGrafica
            // 
            this.grbGrafica.Controls.Add(this.ptbGrafica);
            this.grbGrafica.Location = new System.Drawing.Point(281, 26);
            this.grbGrafica.Name = "grbGrafica";
            this.grbGrafica.Size = new System.Drawing.Size(507, 303);
            this.grbGrafica.TabIndex = 2;
            this.grbGrafica.TabStop = false;
            this.grbGrafica.Text = "Grafica";
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(22, 34);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(467, 249);
            this.ptbGrafica.TabIndex = 0;
            this.ptbGrafica.TabStop = false;
            // 
            // frmStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbGrafica);
            this.Controls.Add(this.grbProceso);
            this.Controls.Add(this.grbEntrada);
            this.Name = "frmStar";
            this.Text = "Estrella";
            this.grbEntrada.ResumeLayout(false);
            this.grbEntrada.PerformLayout();
            this.grbProceso.ResumeLayout(false);
            this.grbGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEntrada;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.GroupBox grbProceso;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox grbGrafica;
        private System.Windows.Forms.PictureBox ptbGrafica;
    }
}

