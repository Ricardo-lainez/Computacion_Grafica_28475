namespace WinAppTriangleSt
{
    partial class frmTriangleStar
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
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.grbSalida = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.grbGafico = new System.Windows.Forms.GroupBox();
            this.ptbGrafico = new System.Windows.Forms.PictureBox();
            this.grbTraslacion = new System.Windows.Forms.GroupBox();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.grbRotacion = new System.Windows.Forms.GroupBox();
            this.grbEscala = new System.Windows.Forms.GroupBox();
            this.hScrollEscala = new System.Windows.Forms.HScrollBar();
            this.btnEscala = new System.Windows.Forms.Button();
            this.btnRotarDerecha = new System.Windows.Forms.Button();
            this.btnRotarIzquierda = new System.Windows.Forms.Button();
            this.grbEntrada.SuspendLayout();
            this.grbSalida.SuspendLayout();
            this.grbGafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafico)).BeginInit();
            this.grbTraslacion.SuspendLayout();
            this.grbRotacion.SuspendLayout();
            this.grbEscala.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEntrada
            // 
            this.grbEntrada.Controls.Add(this.txtRadio);
            this.grbEntrada.Controls.Add(this.lblAltura);
            this.grbEntrada.Location = new System.Drawing.Point(12, 24);
            this.grbEntrada.Name = "grbEntrada";
            this.grbEntrada.Size = new System.Drawing.Size(256, 64);
            this.grbEntrada.TabIndex = 0;
            this.grbEntrada.TabStop = false;
            this.grbEntrada.Text = "Entrada";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(106, 25);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 20);
            this.txtRadio.TabIndex = 1;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(25, 28);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(75, 13);
            this.lblAltura.TabIndex = 0;
            this.lblAltura.Text = "Ingrese Altura:";
            // 
            // grbSalida
            // 
            this.grbSalida.Controls.Add(this.btnSalir);
            this.grbSalida.Controls.Add(this.btnResetear);
            this.grbSalida.Controls.Add(this.btnGraficar);
            this.grbSalida.Location = new System.Drawing.Point(12, 94);
            this.grbSalida.Name = "grbSalida";
            this.grbSalida.Size = new System.Drawing.Size(256, 58);
            this.grbSalida.TabIndex = 1;
            this.grbSalida.TabStop = false;
            this.grbSalida.Text = "Salida";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(175, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(93, 20);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(12, 20);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // grbGafico
            // 
            this.grbGafico.Controls.Add(this.ptbGrafico);
            this.grbGafico.Location = new System.Drawing.Point(290, 24);
            this.grbGafico.Name = "grbGafico";
            this.grbGafico.Size = new System.Drawing.Size(498, 414);
            this.grbGafico.TabIndex = 2;
            this.grbGafico.TabStop = false;
            this.grbGafico.Text = "Grafico";
            // 
            // ptbGrafico
            // 
            this.ptbGrafico.Location = new System.Drawing.Point(23, 28);
            this.ptbGrafico.Name = "ptbGrafico";
            this.ptbGrafico.Size = new System.Drawing.Size(459, 364);
            this.ptbGrafico.TabIndex = 0;
            this.ptbGrafico.TabStop = false;
            // 
            // grbTraslacion
            // 
            this.grbTraslacion.Controls.Add(this.btnTrasladar);
            this.grbTraslacion.Location = new System.Drawing.Point(12, 158);
            this.grbTraslacion.Name = "grbTraslacion";
            this.grbTraslacion.Size = new System.Drawing.Size(256, 88);
            this.grbTraslacion.TabIndex = 3;
            this.grbTraslacion.TabStop = false;
            this.grbTraslacion.Text = "Traslación";
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Location = new System.Drawing.Point(93, 38);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(75, 23);
            this.btnTrasladar.TabIndex = 0;
            this.btnTrasladar.Text = "Trasladar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click_1);
            // 
            // grbRotacion
            // 
            this.grbRotacion.Controls.Add(this.btnRotarIzquierda);
            this.grbRotacion.Controls.Add(this.btnRotarDerecha);
            this.grbRotacion.Location = new System.Drawing.Point(18, 252);
            this.grbRotacion.Name = "grbRotacion";
            this.grbRotacion.Size = new System.Drawing.Size(250, 78);
            this.grbRotacion.TabIndex = 4;
            this.grbRotacion.TabStop = false;
            this.grbRotacion.Text = "Rotación";
            // 
            // grbEscala
            // 
            this.grbEscala.Controls.Add(this.hScrollEscala);
            this.grbEscala.Controls.Add(this.btnEscala);
            this.grbEscala.Location = new System.Drawing.Point(18, 336);
            this.grbEscala.Name = "grbEscala";
            this.grbEscala.Size = new System.Drawing.Size(250, 102);
            this.grbEscala.TabIndex = 5;
            this.grbEscala.TabStop = false;
            this.grbEscala.Text = "Escala";
            this.grbEscala.UseWaitCursor = true;
            // 
            // hScrollEscala
            // 
            this.hScrollEscala.Location = new System.Drawing.Point(22, 62);
            this.hScrollEscala.Name = "hScrollEscala";
            this.hScrollEscala.Size = new System.Drawing.Size(200, 18);
            this.hScrollEscala.TabIndex = 1;
            this.hScrollEscala.UseWaitCursor = true;
            this.hScrollEscala.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollEscala_Scroll);
            // 
            // btnEscala
            // 
            this.btnEscala.Location = new System.Drawing.Point(87, 28);
            this.btnEscala.Name = "btnEscala";
            this.btnEscala.Size = new System.Drawing.Size(75, 23);
            this.btnEscala.TabIndex = 0;
            this.btnEscala.Text = "Escala";
            this.btnEscala.UseVisualStyleBackColor = true;
            this.btnEscala.UseWaitCursor = true;
            this.btnEscala.Click += new System.EventHandler(this.btnEscala_Click_1);
            // 
            // btnRotarDerecha
            // 
            this.btnRotarDerecha.Location = new System.Drawing.Point(154, 37);
            this.btnRotarDerecha.Name = "btnRotarDerecha";
            this.btnRotarDerecha.Size = new System.Drawing.Size(90, 23);
            this.btnRotarDerecha.TabIndex = 1;
            this.btnRotarDerecha.Text = "Rotar derecha";
            this.btnRotarDerecha.UseVisualStyleBackColor = true;
            this.btnRotarDerecha.Click += new System.EventHandler(this.btnRotarDerecha_Click);
            // 
            // btnRotarIzquierda
            // 
            this.btnRotarIzquierda.Location = new System.Drawing.Point(22, 37);
            this.btnRotarIzquierda.Name = "btnRotarIzquierda";
            this.btnRotarIzquierda.Size = new System.Drawing.Size(91, 23);
            this.btnRotarIzquierda.TabIndex = 2;
            this.btnRotarIzquierda.Text = "Rotar Izquierda";
            this.btnRotarIzquierda.UseVisualStyleBackColor = true;
            this.btnRotarIzquierda.Click += new System.EventHandler(this.btnRotarIzquierda_Click);
            // 
            // frmTriangleStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbEscala);
            this.Controls.Add(this.grbRotacion);
            this.Controls.Add(this.grbTraslacion);
            this.Controls.Add(this.grbGafico);
            this.Controls.Add(this.grbSalida);
            this.Controls.Add(this.grbEntrada);
            this.Name = "frmTriangleStar";
            this.Text = "Triangulo con forma de estrella";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTriangleStar_KeyDown);
            this.grbEntrada.ResumeLayout(false);
            this.grbEntrada.PerformLayout();
            this.grbSalida.ResumeLayout(false);
            this.grbGafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafico)).EndInit();
            this.grbTraslacion.ResumeLayout(false);
            this.grbRotacion.ResumeLayout(false);
            this.grbEscala.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEntrada;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.GroupBox grbSalida;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox grbGafico;
        private System.Windows.Forms.PictureBox ptbGrafico;
        private System.Windows.Forms.GroupBox grbTraslacion;
        private System.Windows.Forms.GroupBox grbRotacion;
        private System.Windows.Forms.GroupBox grbEscala;
        private System.Windows.Forms.Button btnEscala;
        private System.Windows.Forms.HScrollBar hScrollEscala;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.Button btnRotarDerecha;
        private System.Windows.Forms.Button btnRotarIzquierda;
    }
}

