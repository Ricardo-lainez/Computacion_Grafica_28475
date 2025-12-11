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
    public partial class AlgoritmoTrigonometrico : Form
    {
        // Instancia de la clase lógica del Algoritmo Trigonométrico
        private CTrigonometrico objTrigonometrico = new CTrigonometrico();

        public AlgoritmoTrigonometrico()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            // Ejecutar el graficado pasando los controles
            objTrigonometrico.Graficar(ptbGrafica, txtRadio);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRadio_Click(object sender, EventArgs e)
        {

        }
    }
}