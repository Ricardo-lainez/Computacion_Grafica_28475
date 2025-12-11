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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gbAnimacion = new System.Windows.Forms.GroupBox();
            this.chkVerConstruccion = new System.Windows.Forms.CheckBox();
            this.btnAnimar = new System.Windows.Forms.Button();
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.rbBSpline = new System.Windows.Forms.RadioButton();
            this.rbBezierN = new System.Windows.Forms.RadioButton();
            this.rbBezierCubica = new System.Windows.Forms.RadioButton();
            this.rbBezierCuadratica = new System.Windows.Forms.RadioButton();
            this.rbBezierLineal = new System.Windows.Forms.RadioButton();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.ptbLienzo = new System.Windows.Forms.PictureBox();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);
            this.pnlControls.SuspendLayout();
            this.gbAnimacion.SuspendLayout();
            this.gbTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControls.Controls.Add(this.lblInfo);
            this.pnlControls.Controls.Add(this.gbAnimacion);
            this.pnlControls.Controls.Add(this.gbTipo);
            this.pnlControls.Controls.Add(this.btnLimpiar);
            this.pnlControls.Controls.Add(this.lblInstrucciones);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(10);
            this.pnlControls.Size = new System.Drawing.Size(200, 561);
            this.pnlControls.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 494);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(43, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Puntos:";
            // 
            // gbAnimacion
            // 
            this.gbAnimacion.Controls.Add(this.chkVerConstruccion);
            this.gbAnimacion.Controls.Add(this.btnAnimar);
            this.gbAnimacion.Location = new System.Drawing.Point(12, 305);
            this.gbAnimacion.Name = "gbAnimacion";
            this.gbAnimacion.Size = new System.Drawing.Size(175, 100);
            this.gbAnimacion.TabIndex = 4;
            this.gbAnimacion.TabStop = false;
            this.gbAnimacion.Text = "Animación";
            // 
            // chkVerConstruccion
            // 
            this.chkVerConstruccion.AutoSize = true;
            this.chkVerConstruccion.Checked = true;
            this.chkVerConstruccion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerConstruccion.Location = new System.Drawing.Point(10, 55);
            this.chkVerConstruccion.Name = "chkVerConstruccion";
            this.chkVerConstruccion.Size = new System.Drawing.Size(143, 17);
            this.chkVerConstruccion.TabIndex = 1;
            this.chkVerConstruccion.Text = "Ver líneas (De Casteljau)";
            this.chkVerConstruccion.UseVisualStyleBackColor = true;
            this.chkVerConstruccion.CheckedChanged += new System.EventHandler(this.chkVerConstruccion_CheckedChanged);
            // 
            // btnAnimar
            // 
            this.btnAnimar.Location = new System.Drawing.Point(10, 20);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(155, 30);
            this.btnAnimar.TabIndex = 0;
            this.btnAnimar.Text = "Iniciar Animación";
            this.btnAnimar.UseVisualStyleBackColor = true;
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // gbTipo
            // 
            this.gbTipo.Controls.Add(this.rbBSpline);
            this.gbTipo.Controls.Add(this.rbBezierN);
            this.gbTipo.Controls.Add(this.rbBezierCubica);
            this.gbTipo.Controls.Add(this.rbBezierCuadratica);
            this.gbTipo.Controls.Add(this.rbBezierLineal);
            this.gbTipo.Location = new System.Drawing.Point(12, 122);
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.Size = new System.Drawing.Size(175, 150);
            this.gbTipo.TabIndex = 3;
            this.gbTipo.TabStop = false;
            this.gbTipo.Text = "Tipo de Curva";
            // 
            // rbBSpline
            // 
            this.rbBSpline.AutoSize = true;
            this.rbBSpline.Location = new System.Drawing.Point(10, 115);
            this.rbBSpline.Name = "rbBSpline";
            this.rbBSpline.Size = new System.Drawing.Size(64, 17);
            this.rbBSpline.TabIndex = 4;
            this.rbBSpline.Text = "B-Spline";
            this.rbBSpline.UseVisualStyleBackColor = true;
            this.rbBSpline.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            // 
            // rbBezierN
            // 
            this.rbBezierN.AutoSize = true;
            this.rbBezierN.Location = new System.Drawing.Point(10, 92);
            this.rbBezierN.Name = "rbBezierN";
            this.rbBezierN.Size = new System.Drawing.Size(102, 17);
            this.rbBezierN.TabIndex = 3;
            this.rbBezierN.Text = "Bézier N Grados";
            this.rbBezierN.UseVisualStyleBackColor = true;
            this.rbBezierN.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            // 
            // rbBezierCubica
            // 
            this.rbBezierCubica.AutoSize = true;
            this.rbBezierCubica.Checked = true;
            this.rbBezierCubica.Location = new System.Drawing.Point(10, 69);
            this.rbBezierCubica.Name = "rbBezierCubica";
            this.rbBezierCubica.Size = new System.Drawing.Size(122, 17);
            this.rbBezierCubica.TabIndex = 2;
            this.rbBezierCubica.TabStop = true;
            this.rbBezierCubica.Text = "Bézier Cúbica (4 pts)";
            this.rbBezierCubica.UseVisualStyleBackColor = true;
            this.rbBezierCubica.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            // 
            // rbBezierCuadratica
            // 
            this.rbBezierCuadratica.AutoSize = true;
            this.rbBezierCuadratica.Location = new System.Drawing.Point(10, 46);
            this.rbBezierCuadratica.Name = "rbBezierCuadratica";
            this.rbBezierCuadratica.Size = new System.Drawing.Size(140, 17);
            this.rbBezierCuadratica.TabIndex = 1;
            this.rbBezierCuadratica.Text = "Bézier Cuadrática (3 pts)";
            this.rbBezierCuadratica.UseVisualStyleBackColor = true;
            this.rbBezierCuadratica.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            // 
            // rbBezierLineal
            // 
            this.rbBezierLineal.AutoSize = true;
            this.rbBezierLineal.Location = new System.Drawing.Point(10, 23);
            this.rbBezierLineal.Name = "rbBezierLineal";
            this.rbBezierLineal.Size = new System.Drawing.Size(117, 17);
            this.rbBezierLineal.TabIndex = 0;
            this.rbBezierLineal.Text = "Bézier Lineal (2 pts)";
            this.rbBezierLineal.UseVisualStyleBackColor = true;
            this.rbBezierLineal.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 433);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(175, 30);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Lienzo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstrucciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.Location = new System.Drawing.Point(10, 10);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(180, 65);
            this.lblInstrucciones.TabIndex = 1;
            this.lblInstrucciones.Text = "1. Selecciona Algoritmo\r\n2. Clic en lienzo para agregar puntos\r\n3. Arrastra los p" +
    "untos rojos";
            // 
            // ptbLienzo
            // 
            this.ptbLienzo.BackColor = System.Drawing.Color.White;
            this.ptbLienzo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ptbLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbLienzo.Location = new System.Drawing.Point(200, 0);
            this.ptbLienzo.Name = "ptbLienzo";
            this.ptbLienzo.Size = new System.Drawing.Size(584, 561);
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
            this.Controls.Add(this.pnlControls);
            this.Name = "Form1";
            this.Text = "Visualizador de Curvas - WinAppCurvas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.gbAnimacion.ResumeLayout(false);
            this.gbAnimacion.PerformLayout();
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.PictureBox ptbLienzo;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.RadioButton rbBSpline;
        private System.Windows.Forms.RadioButton rbBezierN;
        private System.Windows.Forms.RadioButton rbBezierCubica;
        private System.Windows.Forms.RadioButton rbBezierCuadratica;
        private System.Windows.Forms.RadioButton rbBezierLineal;
        private System.Windows.Forms.GroupBox gbAnimacion;
        private System.Windows.Forms.CheckBox chkVerConstruccion;
        private System.Windows.Forms.Button btnAnimar;
        private System.Windows.Forms.Timer tmrAnimacion;
        private System.Windows.Forms.Label lblInfo;
    }
}