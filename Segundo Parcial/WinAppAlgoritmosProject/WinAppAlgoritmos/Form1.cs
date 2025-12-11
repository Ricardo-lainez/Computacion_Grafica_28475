using Algoritmos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Bresenham Bresenham = new Bresenham();
            Bresenham.MdiParent = this;
            Bresenham.WindowState = FormWindowState.Maximized;
            Bresenham.Show();
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            PMedio PuntoMedio = new PMedio();
            PuntoMedio.MdiParent = this;
            PuntoMedio.WindowState = FormWindowState.Maximized;
            PuntoMedio.Show();
        }

        private void aLGORITMOCIRCUNFERENCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Circunferencia Circunferencia = new Circunferencia();
            Circunferencia.MdiParent = this;
            Circunferencia.Show();

        }

        private void aLGORITMODDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            DDA DDA = new DDA();
            DDA.MdiParent = this;
            DDA.Show();
        }

        private void aLGORITMOBRESENHAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Bresenham Bresenham = new Bresenham();
            Bresenham.MdiParent = this;
            Bresenham.Show();
        }

        private void aLGORITMOPUNTOMEDIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            PMedio PuntoMedio = new PMedio();
            PuntoMedio.MdiParent = this;
            PuntoMedio.Show();
        }

        private void aLGORITMOSIMETRIA8LADOSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Circunferencia circunferencia = new Circunferencia();
            circunferencia.MdiParent = this;
            circunferencia.Show();
        }

        private void aLGORITMOPOLINOMICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            AlgoritmoPolinomicoC polinomico = new AlgoritmoPolinomicoC();
            polinomico.MdiParent = this;
            polinomico.Show();
        }

        private void aLGORITMOTRIGONOMETRICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            AlgoritmoTrigonometrico trigonometrico = new AlgoritmoTrigonometrico();
            trigonometrico.MdiParent = this;
            trigonometrico.Show();
        }

        // Asegúrate de que este evento esté linkeado en el Designer al item "ALGORITMO DE RECORTE"
        private void aLGORITMODERELLENOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Como no hay submenús en el designer para elegir Linea o Poligono,
            // crearemos una pequeña pregunta:
            DialogResult result = MessageBox.Show(
                "¿Deseas abrir el Recorte de LÍNEAS?\n\nSí = Líneas (Cohen-Sutherland)\nNo = Polígonos (Sutherland-Hodgman)\nCancelar = Salir",
                "Seleccionar Algoritmo de Recorte",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Cancel) return;

            CerrarFormulariosHijos();

            if (result == DialogResult.Yes)
            {
                // Opción Líneas
                CohenSutherland frmLineas = new CohenSutherland();
                frmLineas.MdiParent = this;
                frmLineas.Text = "Recorte de Líneas (3 Variantes)";
                frmLineas.Show();
            }
            else
            {
                // Opción Polígonos
                SutherlandHodgman frmPoligonos = new SutherlandHodgman();
                frmPoligonos.MdiParent = this;
                frmPoligonos.Text = "Recorte de Polígonos (3 Variantes)";
                frmPoligonos.Show();
            }
        }
    }
}
