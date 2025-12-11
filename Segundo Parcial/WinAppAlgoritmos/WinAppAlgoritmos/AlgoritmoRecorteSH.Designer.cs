namespace WinAppAlgoritmos
{
    partial class AlgoritmoRecorteSH
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.btnPoligono = new System.Windows.Forms.Button();
            this.btnVentana = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(6, 19);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(560, 401);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // btnPoligono
            // 
            this.btnPoligono.Location = new System.Drawing.Point(35, 88);
            this.btnPoligono.Name = "btnPoligono";
            this.btnPoligono.Size = new System.Drawing.Size(97, 23);
            this.btnPoligono.TabIndex = 2;
            this.btnPoligono.Text = "dibujar Poligono";
            this.btnPoligono.UseVisualStyleBackColor = true;
            this.btnPoligono.Click += new System.EventHandler(this.btnPoligono_Click);
            // 
            // btnVentana
            // 
            this.btnVentana.Location = new System.Drawing.Point(35, 131);
            this.btnVentana.Name = "btnVentana";
            this.btnVentana.Size = new System.Drawing.Size(97, 23);
            this.btnVentana.TabIndex = 3;
            this.btnVentana.Text = "definir ventana";
            this.btnVentana.UseVisualStyleBackColor = true;
            this.btnVentana.Click += new System.EventHandler(this.btnVentana_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(35, 171);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(97, 23);
            this.btnRecortar.TabIndex = 4;
            this.btnRecortar.Text = "aplicar recorte";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(35, 201);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(15, 42);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(117, 13);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "selecciona una opcion:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.canvas);
            this.groupBox1.Location = new System.Drawing.Point(216, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 426);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // AlgoritmoRecorteSH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRecortar);
            this.Controls.Add(this.btnVentana);
            this.Controls.Add(this.btnPoligono);
            this.Name = "AlgoritmoRecorteSH";
            this.Text = "AlgoritmoRecorteSH";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btnPoligono;
        private System.Windows.Forms.Button btnVentana;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}