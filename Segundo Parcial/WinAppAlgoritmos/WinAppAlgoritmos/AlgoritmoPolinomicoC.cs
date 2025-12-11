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
    public partial class AlgoritmoPolinomicoC : Form
    {
        // Instancia de nuestra clase lógica
        private CPolinomico objPolinomico = new CPolinomico();
        
        // Instancias de las clases de relleno
        private CFloodFill objFloodFill = new CFloodFill();
        private CBoundaryFill objBoundaryFill = new CBoundaryFill();
        private CScanLineFill objScanLineFill = new CScanLineFill();

        public AlgoritmoPolinomicoC()
        {
            InitializeComponent();
            
            // Suscribir el evento MouseClick del PictureBox
            ptbGrafica.MouseClick += PtbGrafica_MouseClick;
        }

        private void PtbGrafica_MouseClick(object sender, MouseEventArgs e)
        {
            // Delegar el evento a Flood Fill si está esperando un clic
            if (objFloodFill.EstaEsperandoClick())
            {
                objFloodFill.OnPictureBoxClick(sender, e, ptbGrafica);
            }
            // Delegar el evento a Boundary Fill si está esperando un clic
            else if (objBoundaryFill.EstaEsperandoClick())
            {
                objBoundaryFill.OnPictureBoxClick(sender, e, ptbGrafica);
            }
            // Delegar el evento a Scan Line Fill si está esperando un clic
            else if (objScanLineFill.EstaEsperandoClick())
            {
                objScanLineFill.OnPictureBoxClick(sender, e, ptbGrafica);
            }
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            // Llamamos al método de la clase lógica
            // Pasamos los controles del formulario para que la clase los manipule
            objPolinomico.Graficar(ptbGrafica, txtRadio);
        }

        private void ptbGrafica_Click(object sender, EventArgs e)
        {

        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            // Activar modo de selección de punto para Flood Fill
            objFloodFill.ActivarSeleccionPunto(ptbGrafica);
        }

        private void btnBoundaryFill_Click(object sender, EventArgs e)
        {
            // Activar modo de selección de punto para Boundary Fill
            objBoundaryFill.ActivarSeleccionPunto(ptbGrafica);
        }

        private void btnScanLineFill_Click(object sender, EventArgs e)
        {
            // Activar modo de selección de punto para Scan Line Fill
            objScanLineFill.ActivarSeleccionPunto(ptbGrafica);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancelar cualquier selección pendiente al cerrar el formulario
            objFloodFill.CancelarSeleccion(ptbGrafica);
            objBoundaryFill.CancelarSeleccion(ptbGrafica);
            objScanLineFill.CancelarSeleccion(ptbGrafica);
            base.OnFormClosing(e);
        }
    }
}