using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class home2 : Form
    {
        public home2()
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
        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Formcuadrado cuadrado = new Formcuadrado();
            cuadrado.MdiParent = this;
            cuadrado.Show();
        }
        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Rectangulo rectangulo = new Rectangulo();
            rectangulo.MdiParent = this;
            rectangulo.Show();
        }
        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Triangulo triangulo = new Triangulo();
            triangulo.MdiParent = this;
            triangulo.Show();
        }
        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Rombo rombo = new Rombo();
            rombo.MdiParent = this;
            rombo.Show();
        }

        private void romboideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Romboide romboide = new Romboide();
            romboide.MdiParent = this;
            romboide.Show();
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Trapecio trapecio = new Trapecio();
            trapecio.MdiParent = this;
            trapecio.Show();
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Circulo circulo = new Circulo();
            circulo.MdiParent = this;
            circulo.Show();
        }

        private void poligonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Poligonos poligonos = new Poligonos();
            poligonos.MdiParent = this;
            poligonos.Show();
        }

        private void home2_Load(object sender, EventArgs e)
        {

        }
    }
}
