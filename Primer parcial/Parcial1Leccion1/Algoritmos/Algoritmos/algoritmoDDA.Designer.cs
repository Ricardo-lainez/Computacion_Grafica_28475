namespace Algoritmos
{
    partial class AlgoritmoDDA
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
            this.components = new System.ComponentModel.Container();
            this.lblCoordenadaInicial = new System.Windows.Forms.Label();
            this.lblCoordenadaFinal = new System.Windows.Forms.Label();
            this.grbEntrada = new System.Windows.Forms.GroupBox();
            this.lblParentesisFy = new System.Windows.Forms.Label();
            this.lblParentesisFx = new System.Windows.Forms.Label();
            this.lblParentesisIy = new System.Windows.Forms.Label();
            this.lblParentesisIx = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.txtCoordenadaFy = new System.Windows.Forms.TextBox();
            this.txtCoordenadaFx = new System.Windows.Forms.TextBox();
            this.txtCoordenadaIy = new System.Windows.Forms.TextBox();
            this.txtCoordenadaIx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxLienzo = new System.Windows.Forms.PictureBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.lineTimer = new System.Windows.Forms.Timer(this.components);
            this.grbEntrada.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCoordenadaInicial
            // 
            this.lblCoordenadaInicial.AutoSize = true;
            this.lblCoordenadaInicial.Location = new System.Drawing.Point(17, 55);
            this.lblCoordenadaInicial.Name = "lblCoordenadaInicial";
            this.lblCoordenadaInicial.Size = new System.Drawing.Size(97, 13);
            this.lblCoordenadaInicial.TabIndex = 0;
            this.lblCoordenadaInicial.Text = "Coordenada inicial:";
            // 
            // lblCoordenadaFinal
            // 
            this.lblCoordenadaFinal.AutoSize = true;
            this.lblCoordenadaFinal.Location = new System.Drawing.Point(17, 86);
            this.lblCoordenadaFinal.Name = "lblCoordenadaFinal";
            this.lblCoordenadaFinal.Size = new System.Drawing.Size(90, 13);
            this.lblCoordenadaFinal.TabIndex = 1;
            this.lblCoordenadaFinal.Text = "Coordenada final:";
            // 
            // grbEntrada
            // 
            this.grbEntrada.Controls.Add(this.lblParentesisFy);
            this.grbEntrada.Controls.Add(this.lblParentesisFx);
            this.grbEntrada.Controls.Add(this.lblParentesisIy);
            this.grbEntrada.Controls.Add(this.lblParentesisIx);
            this.grbEntrada.Controls.Add(this.lblY);
            this.grbEntrada.Controls.Add(this.lblX);
            this.grbEntrada.Controls.Add(this.txtCoordenadaFy);
            this.grbEntrada.Controls.Add(this.txtCoordenadaFx);
            this.grbEntrada.Controls.Add(this.txtCoordenadaIy);
            this.grbEntrada.Controls.Add(this.txtCoordenadaIx);
            this.grbEntrada.Controls.Add(this.lblCoordenadaInicial);
            this.grbEntrada.Controls.Add(this.lblCoordenadaFinal);
            this.grbEntrada.Location = new System.Drawing.Point(12, 12);
            this.grbEntrada.Name = "grbEntrada";
            this.grbEntrada.Size = new System.Drawing.Size(281, 130);
            this.grbEntrada.TabIndex = 2;
            this.grbEntrada.TabStop = false;
            this.grbEntrada.Text = "Entradas";
            // 
            // lblParentesisFy
            // 
            this.lblParentesisFy.AutoSize = true;
            this.lblParentesisFy.Location = new System.Drawing.Point(252, 89);
            this.lblParentesisFy.Name = "lblParentesisFy";
            this.lblParentesisFy.Size = new System.Drawing.Size(10, 13);
            this.lblParentesisFy.TabIndex = 3;
            this.lblParentesisFy.Text = ")";
            // 
            // lblParentesisFx
            // 
            this.lblParentesisFx.AutoSize = true;
            this.lblParentesisFx.Location = new System.Drawing.Point(120, 89);
            this.lblParentesisFx.Name = "lblParentesisFx";
            this.lblParentesisFx.Size = new System.Drawing.Size(10, 13);
            this.lblParentesisFx.TabIndex = 3;
            this.lblParentesisFx.Text = "(";
            // 
            // lblParentesisIy
            // 
            this.lblParentesisIy.AutoSize = true;
            this.lblParentesisIy.Location = new System.Drawing.Point(252, 58);
            this.lblParentesisIy.Name = "lblParentesisIy";
            this.lblParentesisIy.Size = new System.Drawing.Size(10, 13);
            this.lblParentesisIy.TabIndex = 3;
            this.lblParentesisIy.Text = ")";
            // 
            // lblParentesisIx
            // 
            this.lblParentesisIx.AutoSize = true;
            this.lblParentesisIx.Location = new System.Drawing.Point(120, 58);
            this.lblParentesisIx.Name = "lblParentesisIx";
            this.lblParentesisIx.Size = new System.Drawing.Size(10, 13);
            this.lblParentesisIx.TabIndex = 3;
            this.lblParentesisIx.Text = "(";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(216, 36);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(152, 36);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "X";
            // 
            // txtCoordenadaFy
            // 
            this.txtCoordenadaFy.Location = new System.Drawing.Point(193, 86);
            this.txtCoordenadaFy.Name = "txtCoordenadaFy";
            this.txtCoordenadaFy.Size = new System.Drawing.Size(53, 20);
            this.txtCoordenadaFy.TabIndex = 5;
            // 
            // txtCoordenadaFx
            // 
            this.txtCoordenadaFx.Location = new System.Drawing.Point(136, 86);
            this.txtCoordenadaFx.Name = "txtCoordenadaFx";
            this.txtCoordenadaFx.Size = new System.Drawing.Size(51, 20);
            this.txtCoordenadaFx.TabIndex = 4;
            // 
            // txtCoordenadaIy
            // 
            this.txtCoordenadaIy.Location = new System.Drawing.Point(193, 55);
            this.txtCoordenadaIy.Name = "txtCoordenadaIy";
            this.txtCoordenadaIy.Size = new System.Drawing.Size(53, 20);
            this.txtCoordenadaIy.TabIndex = 3;
            // 
            // txtCoordenadaIx
            // 
            this.txtCoordenadaIx.Location = new System.Drawing.Point(136, 55);
            this.txtCoordenadaIx.Name = "txtCoordenadaIx";
            this.txtCoordenadaIx.Size = new System.Drawing.Size(51, 20);
            this.txtCoordenadaIx.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxLienzo);
            this.groupBox1.Location = new System.Drawing.Point(300, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 425);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grafica";
            // 
            // pictureBoxLienzo
            // 
            this.pictureBoxLienzo.Location = new System.Drawing.Point(7, 20);
            this.pictureBoxLienzo.Name = "pictureBoxLienzo";
            this.pictureBoxLienzo.Size = new System.Drawing.Size(475, 390);
            this.pictureBoxLienzo.TabIndex = 0;
            this.pictureBoxLienzo.TabStop = false;
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(45, 172);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 3;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // lineTimer
            // 
            this.lineTimer.Tick += new System.EventHandler(this.lineTimer_Tick);
            // 
            // AlgoritmoDDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.grbEntrada);
            this.Name = "AlgoritmoDDA";
            this.Text = "Algoritmo DDA";
            this.grbEntrada.ResumeLayout(false);
            this.grbEntrada.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCoordenadaInicial;
        private System.Windows.Forms.Label lblCoordenadaFinal;
        private System.Windows.Forms.GroupBox grbEntrada;
        private System.Windows.Forms.Label lblParentesisIx;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox txtCoordenadaFy;
        private System.Windows.Forms.TextBox txtCoordenadaFx;
        private System.Windows.Forms.TextBox txtCoordenadaIy;
        private System.Windows.Forms.TextBox txtCoordenadaIx;
        private System.Windows.Forms.Label lblParentesisFy;
        private System.Windows.Forms.Label lblParentesisFx;
        private System.Windows.Forms.Label lblParentesisIy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxLienzo;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Timer lineTimer;
    }
}