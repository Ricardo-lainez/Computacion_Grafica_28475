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
    public partial class Circulo : Form
    {
        public Circulo()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double radioCirculo = double.Parse(txtRadioCirculo.Text);

                if (radioCirculo <= 0)
                {
                    MessageBox.Show("El radio debe ser mayor que 0");
                }
                else
                {
                    double resultado;
                    resultado = Math.PI * radioCirculo * radioCirculo;
                    MessageBox.Show("El area del circulo es: " + resultado); 
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ingrese numeros validos");
            }
            

        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double radioCirculo = double.Parse(txtRadioCirculo.Text);

                if (radioCirculo <= 0)
                {
                    MessageBox.Show("El radio debe ser mayor que 0");
                }
                else
                {
                    double resultado;
                    resultado = 2* Math.PI * radioCirculo;
                    MessageBox.Show("El perimetro del circulo es: " + resultado);
                }

            }
            catch (FormatException) {
                MessageBox.Show("Ingresar numeros validos");
            }
        }
    }
}
