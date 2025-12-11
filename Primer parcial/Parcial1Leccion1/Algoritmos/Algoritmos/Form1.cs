using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class frmAlgoritmos : Form
    {
        public frmAlgoritmos()
        {
            InitializeComponent();
        }
        private void cerrarFormulariohijo()
        {
            foreach (Form formulario in this.MdiChildren)
            {
                formulario.Close();
            }
        }

        private void aLGORITMODDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarFormulariohijo();
            AlgoritmoDDA algoritmoDDA = new AlgoritmoDDA();
            algoritmoDDA.MdiParent = this;
            algoritmoDDA.Show();
        }

        

        private void aLGORITMOPUNTOMEDIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarFormulariohijo();
            AlgoritmoPuntoMedio algoritmoPuntoMedio = new AlgoritmoPuntoMedio();
            algoritmoPuntoMedio.MdiParent = this;
            algoritmoPuntoMedio.Show();
        }

        private void aLGORITMOBRESENHAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarFormulariohijo();
            AlgoritmoBresenham algoritmoBresenham = new AlgoritmoBresenham();
            algoritmoBresenham.MdiParent = this;
            algoritmoBresenham.Show();
        }

        private void aLGORITMOCIRCUNFERENCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarFormulariohijo();
            AlgoritmoCircunferencia algoritmoCircunferencia = new AlgoritmoCircunferencia();
            algoritmoCircunferencia.MdiParent = this;
            algoritmoCircunferencia.Show();
        }

        private void aLGORITMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarFormulariohijo();
            AlgoritmoPolinomicoC algoritmoPolinomicoC = new AlgoritmoPolinomicoC();
            algoritmoPolinomicoC.MdiParent = this;
            algoritmoPolinomicoC.Show();
        }

        private void aLGORITMOTRIGONOMETRICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarFormulariohijo();
            AlgoritmoTrigonometrico algoritmoTrigonometricos = new AlgoritmoTrigonometrico();
            algoritmoTrigonometricos.MdiParent = this;
            algoritmoTrigonometricos.Show();
        }
    }
}
