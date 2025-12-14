namespace WinAppCurvas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.gbAnimacion = new System.Windows.Forms.GroupBox();
            this.chkVerLineas = new System.Windows.Forms.CheckBox();
            this.btnAnimar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gbDescripcion = new System.Windows.Forms.GroupBox();
            this.lblDescripcionTecnica = new System.Windows.Forms.Label();
            this.gbAlgoritmo = new System.Windows.Forms.GroupBox();
            this.rbBSpline = new System.Windows.Forms.RadioButton();
            this.rbBezier = new System.Windows.Forms.RadioButton();
            this.ptbLienzo = new System.Windows.Forms.PictureBox();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            this.gbAnimacion.SuspendLayout();
            this.gbDescripcion.SuspendLayout();
            this.gbAlgoritmo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.Controls.Add(this.gbAnimacion);
            this.pnlMenu.Controls.Add(this.lblEstado);
            this.pnlMenu.Controls.Add(this.btnLimpiar);
            this.pnlMenu.Controls.Add(this.gbDescripcion);
            this.pnlMenu.Controls.Add(this.gbAlgoritmo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMenu.Size = new System.Drawing.Size(220, 561);
            this.pnlMenu.TabIndex = 0;
            // 
            // gbAnimacion
            // 
            this.gbAnimacion.Controls.Add(this.chkVerLineas);
            this.gbAnimacion.Controls.Add(this.btnAnimar);
            this.gbAnimacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAnimacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbAnimacion.Location = new System.Drawing.Point(10, 245);
            this.gbAnimacion.Name = "gbAnimacion";
            this.gbAnimacion.Size = new System.Drawing.Size(200, 100);
            this.gbAnimacion.TabIndex = 4;
            this.gbAnimacion.TabStop = false;
            this.gbAnimacion.Text = "Control de Animación";
            // 
            // chkVerLineas
            // 
            this.chkVerLineas.AutoSize = true;
            this.chkVerLineas.Checked = true;
            this.chkVerLineas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerLineas.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkVerLineas.Location = new System.Drawing.Point(15, 60);
            this.chkVerLineas.Name = "chkVerLineas";
            this.chkVerLineas.Size = new System.Drawing.Size(148, 17);
            this.chkVerLineas.TabIndex = 1;
            this.chkVerLineas.Text = "Ver líneas (De Casteljau)";
            this.chkVerLineas.UseVisualStyleBackColor = true;
            // 
            // btnAnimar
            // 
            this.btnAnimar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnimar.Location = new System.Drawing.Point(15, 25);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(170, 30);
            this.btnAnimar.TabIndex = 0;
            this.btnAnimar.Text = "Iniciar Animación";
            this.btnAnimar.UseVisualStyleBackColor = true;
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.DimGray;
            this.lblEstado.Location = new System.Drawing.Point(13, 360);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(114, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Esperando entrada...";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLimpiar.Location = new System.Drawing.Point(10, 511);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 40);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Lienzo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // gbDescripcion
            // 
            this.gbDescripcion.Controls.Add(this.lblDescripcionTecnica);
            this.gbDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbDescripcion.Location = new System.Drawing.Point(10, 95);
            this.gbDescripcion.Name = "gbDescripcion";
            this.gbDescripcion.Size = new System.Drawing.Size(200, 150);
            this.gbDescripcion.TabIndex = 1;
            this.gbDescripcion.TabStop = false;
            this.gbDescripcion.Text = "Descripción Técnica";
            // 
            // lblDescripcionTecnica
            // 
            this.lblDescripcionTecnica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescripcionTecnica.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescripcionTecnica.Location = new System.Drawing.Point(3, 19);
            this.lblDescripcionTecnica.Name = "lblDescripcionTecnica";
            this.lblDescripcionTecnica.Size = new System.Drawing.Size(194, 128);
            this.lblDescripcionTecnica.TabIndex = 0;
            this.lblDescripcionTecnica.Text = "...";
            // 
            // gbAlgoritmo
            // 
            this.gbAlgoritmo.Controls.Add(this.rbBSpline);
            this.gbAlgoritmo.Controls.Add(this.rbBezier);
            this.gbAlgoritmo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAlgoritmo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbAlgoritmo.Location = new System.Drawing.Point(10, 10);
            this.gbAlgoritmo.Name = "gbAlgoritmo";
            this.gbAlgoritmo.Size = new System.Drawing.Size(200, 85);
            this.gbAlgoritmo.TabIndex = 0;
            this.gbAlgoritmo.TabStop = false;
            this.gbAlgoritmo.Text = "Selección de Algoritmo";
            // 
            // rbBSpline
            // 
            this.rbBSpline.AutoSize = true;
            this.rbBSpline.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbBSpline.Location = new System.Drawing.Point(15, 50);
            this.rbBSpline.Name = "rbBSpline";
            this.rbBSpline.Size = new System.Drawing.Size(69, 19);
            this.rbBSpline.TabIndex = 1;
            this.rbBSpline.Text = "B-Spline";
            this.rbBSpline.UseVisualStyleBackColor = true;
            this.rbBSpline.CheckedChanged += new System.EventHandler(this.rbAlgoritmo_CheckedChanged);
            // 
            // rbBezier
            // 
            this.rbBezier.AutoSize = true;
            this.rbBezier.Checked = true;
            this.rbBezier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbBezier.Location = new System.Drawing.Point(15, 25);
            this.rbBezier.Name = "rbBezier";
            this.rbBezier.Size = new System.Drawing.Size(106, 19);
            this.rbBezier.TabIndex = 0;
            this.rbBezier.TabStop = true;
            this.rbBezier.Text = "Curva de Bézier";
            this.rbBezier.UseVisualStyleBackColor = true;
            this.rbBezier.CheckedChanged += new System.EventHandler(this.rbAlgoritmo_CheckedChanged);
            // 
            // ptbLienzo
            // 
            this.ptbLienzo.BackColor = System.Drawing.Color.White;
            this.ptbLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbLienzo.Location = new System.Drawing.Point(220, 0);
            this.ptbLienzo.Name = "ptbLienzo";
            this.ptbLienzo.Size = new System.Drawing.Size(564, 561);
            this.ptbLienzo.TabIndex = 1;
            this.ptbLienzo.TabStop = false;
            this.ptbLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.ptbLienzo_Paint);
            this.ptbLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbLienzo_MouseDown);
            this.ptbLienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbLienzo_MouseMove);
            this.ptbLienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbLienzo_MouseUp);
            // 
            // tmrAnimacion
            // 
            this.tmrAnimacion.Interval = 20;
            this.tmrAnimacion.Tick += new System.EventHandler(this.tmrAnimacion_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ptbLienzo);
            this.Controls.Add(this.pnlMenu);
            this.Name = "Form1";
            this.Text = "Sistema de Curvas - Estudiante Lainez Ricardo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.gbAnimacion.ResumeLayout(false);
            this.gbAnimacion.PerformLayout();
            this.gbDescripcion.ResumeLayout(false);
            this.gbAlgoritmo.ResumeLayout(false);
            this.gbAlgoritmo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLienzo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.GroupBox gbAlgoritmo;
        private System.Windows.Forms.RadioButton rbBSpline;
        private System.Windows.Forms.RadioButton rbBezier;
        private System.Windows.Forms.GroupBox gbDescripcion;
        private System.Windows.Forms.Label lblDescripcionTecnica;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.PictureBox ptbLienzo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox gbAnimacion;
        private System.Windows.Forms.Button btnAnimar;
        private System.Windows.Forms.CheckBox chkVerLineas;
        private System.Windows.Forms.Timer tmrAnimacion;
    }
}