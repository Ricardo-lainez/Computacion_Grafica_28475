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

        public AlgoritmoPolinomicoC()
        {
            InitializeComponent();
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
    }
}