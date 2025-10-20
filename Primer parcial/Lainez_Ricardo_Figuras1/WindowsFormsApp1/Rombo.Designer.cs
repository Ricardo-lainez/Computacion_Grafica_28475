namespace WindowsFormsApp1
{
    partial class Rombo
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
            this.lblDmayor = new System.Windows.Forms.Label();
            this.lbldmenor = new System.Windows.Forms.Label();
            this.btncalcular = new System.Windows.Forms.Button();
            this.btnperimetro = new System.Windows.Forms.Button();
            this.txtDmayor = new System.Windows.Forms.TextBox();
            this.txtdmenor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDmayor
            // 
            this.lblDmayor.AutoSize = true;
            this.lblDmayor.Location = new System.Drawing.Point(262, 82);
            this.lblDmayor.Name = "lblDmayor";
            this.lblDmayor.Size = new System.Drawing.Size(119, 13);
            this.lblDmayor.TabIndex = 0;
            this.lblDmayor.Text = "Ingrese Diagonal Mayor";
            // 
            // lbldmenor
            // 
            this.lbldmenor.AutoSize = true;
            this.lbldmenor.Location = new System.Drawing.Point(265, 125);
            this.lbldmenor.Name = "lbldmenor";
            this.lbldmenor.Size = new System.Drawing.Size(117, 13);
            this.lbldmenor.TabIndex = 1;
            this.lbldmenor.Text = "Ingrese diagonal menor";
            // 
            // btncalcular
            // 
            this.btncalcular.Location = new System.Drawing.Point(197, 199);
            this.btncalcular.Name = "btncalcular";
            this.btncalcular.Size = new System.Drawing.Size(98, 23);
            this.btncalcular.TabIndex = 2;
            this.btncalcular.Text = "Calcular area";
            this.btncalcular.UseVisualStyleBackColor = true;
            this.btncalcular.Click += new System.EventHandler(this.btncalcular_Click);
            // 
            // btnperimetro
            // 
            this.btnperimetro.Location = new System.Drawing.Point(422, 198);
            this.btnperimetro.Name = "btnperimetro";
            this.btnperimetro.Size = new System.Drawing.Size(126, 23);
            this.btnperimetro.TabIndex = 3;
            this.btnperimetro.Text = "Calcular perimetro";
            this.btnperimetro.UseVisualStyleBackColor = true;
            // 
            // txtDmayor
            // 
            this.txtDmayor.Location = new System.Drawing.Point(463, 74);
            this.txtDmayor.Name = "txtDmayor";
            this.txtDmayor.Size = new System.Drawing.Size(100, 20);
            this.txtDmayor.TabIndex = 4;
            // 
            // txtdmenor
            // 
            this.txtdmenor.Location = new System.Drawing.Point(463, 117);
            this.txtdmenor.Name = "txtdmenor";
            this.txtdmenor.Size = new System.Drawing.Size(100, 20);
            this.txtdmenor.TabIndex = 5;
            // 
            // Rombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtdmenor);
            this.Controls.Add(this.txtDmayor);
            this.Controls.Add(this.btnperimetro);
            this.Controls.Add(this.btncalcular);
            this.Controls.Add(this.lbldmenor);
            this.Controls.Add(this.lblDmayor);
            this.Name = "Rombo";
            this.Text = "Rombo";
            this.Load += new System.EventHandler(this.Rombo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDmayor;
        private System.Windows.Forms.Label lbldmenor;
        private System.Windows.Forms.Button btncalcular;
        private System.Windows.Forms.Button btnperimetro;
        private System.Windows.Forms.TextBox txtDmayor;
        private System.Windows.Forms.TextBox txtdmenor;
    }
}