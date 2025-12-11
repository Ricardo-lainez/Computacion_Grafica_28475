using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppProjectU1
{
    public partial class ProyectoU1 : Form
    {
        public ProyectoU1()
        {
            InitializeComponent();
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }


        private void figura1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            poligono16 poligono16frm = new poligono16();
            poligono16frm.MdiParent = this; 
            poligono16frm.Show();
        }

        private void figura2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            circuloCuadrado circuloCuadradofrm = new circuloCuadrado();
            circuloCuadradofrm.MdiParent = this; 
            circuloCuadradofrm.Show();

        }
    }
}
