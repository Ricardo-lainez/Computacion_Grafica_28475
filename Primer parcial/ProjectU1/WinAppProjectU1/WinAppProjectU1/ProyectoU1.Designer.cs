namespace WinAppProjectU1
{
    partial class ProyectoU1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.figura1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figura1ToolStripMenuItem,
            this.figura2ToolStripMenuItem,
            this.figura2ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // figura1ToolStripMenuItem
            // 
            this.figura1ToolStripMenuItem.Name = "figura1ToolStripMenuItem";
            this.figura1ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.figura1ToolStripMenuItem.Text = "Figura 1";
            this.figura1ToolStripMenuItem.Click += new System.EventHandler(this.figura1ToolStripMenuItem_Click);
            // 
            // figura2ToolStripMenuItem
            // 
            this.figura2ToolStripMenuItem.Name = "figura2ToolStripMenuItem";
            this.figura2ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.figura2ToolStripMenuItem.Text = "Figura 2";
            this.figura2ToolStripMenuItem.Click += new System.EventHandler(this.figura2ToolStripMenuItem_Click);
            // 
            // figura2ToolStripMenuItem1
            // 
            this.figura2ToolStripMenuItem1.Name = "figura2ToolStripMenuItem1";
            this.figura2ToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.figura2ToolStripMenuItem1.Text = "Figura 3";
            // 
            // ProyectoU1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProyectoU1";
            this.Text = "ProyectoU1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem figura1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura2ToolStripMenuItem1;
    }
}