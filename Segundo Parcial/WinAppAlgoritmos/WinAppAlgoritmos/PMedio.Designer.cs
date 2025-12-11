namespace WinAppAlgoritmos
{
    partial class PMedio
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
            this.btnDraw = new System.Windows.Forms.Button();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFinalY = new System.Windows.Forms.TextBox();
            this.txtFinalX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInicioY = new System.Windows.Forms.TextBox();
            this.lblSide = new System.Windows.Forms.Label();
            this.txtInicioX = new System.Windows.Forms.TextBox();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.grbInputs.SuspendLayout();
            this.grbProcess.SuspendLayout();
            this.grbCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(99, 33);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 10;
            this.btnDraw.Text = "Graficar";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(6, 19);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(468, 310);
            this.ptbGrafica.TabIndex = 2;
            this.ptbGrafica.TabStop = false;
            // 
            // grbInputs
            // 
            this.grbInputs.Controls.Add(this.label9);
            this.grbInputs.Controls.Add(this.label4);
            this.grbInputs.Controls.Add(this.label8);
            this.grbInputs.Controls.Add(this.label5);
            this.grbInputs.Controls.Add(this.label7);
            this.grbInputs.Controls.Add(this.label3);
            this.grbInputs.Controls.Add(this.label6);
            this.grbInputs.Controls.Add(this.label2);
            this.grbInputs.Controls.Add(this.txtFinalY);
            this.grbInputs.Controls.Add(this.txtFinalX);
            this.grbInputs.Controls.Add(this.label1);
            this.grbInputs.Controls.Add(this.txtInicioY);
            this.grbInputs.Controls.Add(this.lblSide);
            this.grbInputs.Controls.Add(this.txtInicioX);
            this.grbInputs.Location = new System.Drawing.Point(12, 86);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(281, 111);
            this.grbInputs.TabIndex = 12;
            this.grbInputs.TabStop = false;
            this.grbInputs.Text = "Entradas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "X";
            // 
            // txtFinalY
            // 
            this.txtFinalY.Location = new System.Drawing.Point(174, 69);
            this.txtFinalY.Name = "txtFinalY";
            this.txtFinalY.Size = new System.Drawing.Size(32, 20);
            this.txtFinalY.TabIndex = 13;
            // 
            // txtFinalX
            // 
            this.txtFinalX.Location = new System.Drawing.Point(122, 69);
            this.txtFinalX.Name = "txtFinalX";
            this.txtFinalX.Size = new System.Drawing.Size(32, 20);
            this.txtFinalX.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Coordenada final : ";
            // 
            // txtInicioY
            // 
            this.txtInicioY.Location = new System.Drawing.Point(174, 28);
            this.txtInicioY.Name = "txtInicioY";
            this.txtInicioY.Size = new System.Drawing.Size(32, 20);
            this.txtInicioY.TabIndex = 10;
            // 
            // lblSide
            // 
            this.lblSide.AutoSize = true;
            this.lblSide.Location = new System.Drawing.Point(10, 36);
            this.lblSide.Name = "lblSide";
            this.lblSide.Size = new System.Drawing.Size(103, 13);
            this.lblSide.TabIndex = 2;
            this.lblSide.Text = "Coordenada inicial : ";
            // 
            // txtInicioX
            // 
            this.txtInicioX.Location = new System.Drawing.Point(122, 29);
            this.txtInicioX.Name = "txtInicioX";
            this.txtInicioX.Size = new System.Drawing.Size(32, 20);
            this.txtInicioX.TabIndex = 9;
            // 
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.btnDraw);
            this.grbProcess.Location = new System.Drawing.Point(12, 214);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(281, 85);
            this.grbProcess.TabIndex = 10;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "Proceso";
            // 
            // grbCanvas
            // 
            this.grbCanvas.Controls.Add(this.ptbGrafica);
            this.grbCanvas.Location = new System.Drawing.Point(308, 12);
            this.grbCanvas.Name = "grbCanvas";
            this.grbCanvas.Size = new System.Drawing.Size(480, 335);
            this.grbCanvas.TabIndex = 13;
            this.grbCanvas.TabStop = false;
            this.grbCanvas.Text = "Gráfico ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "(";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = ")";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "(";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(212, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = ")";
            // 
            // PMedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbInputs);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbCanvas);
            this.Name = "PMedio";
            this.Text = "PMedio";
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.grbProcess.ResumeLayout(false);
            this.grbCanvas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFinalY;
        private System.Windows.Forms.TextBox txtFinalX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInicioY;
        private System.Windows.Forms.Label lblSide;
        private System.Windows.Forms.TextBox txtInicioX;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}