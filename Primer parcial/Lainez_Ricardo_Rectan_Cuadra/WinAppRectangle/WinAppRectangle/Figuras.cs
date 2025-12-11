using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class Figuras : Form
    {
        public Figuras()
        {
            InitializeComponent();
        }
        private void CerrarFormulariosHijos()
        {
            // MdiChildren es una propiedad de la clase Form MDI Parent
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmRectangle frmRect = new frmRectangle();
            frmRect.MdiParent = this;
            frmRect.Show();

        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmSquare frmSquare = new frmSquare();
            frmSquare.MdiParent = this;
            frmSquare.Show();
        }
    }
}
