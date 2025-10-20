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
    public partial class Triangulo : Form
    {
        public Triangulo()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double baseTriangulo = double.Parse(txtBaseTriangulo.Text);
                double alturaTriangulo = double.Parse(txtAlturaTriangulo.Text);

                if (baseTriangulo <= 0 || alturaTriangulo <= 0)
                {
                    MessageBox.Show("La base o la altura deben ser mayor que 0");
                }
                else {
                    MessageBox.Show("El area del triangulo es: " + ((baseTriangulo * alturaTriangulo) / 2));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double baseTriangulo = double.Parse(txtBaseTriangulo.Text);
                if (baseTriangulo<=0)
                {
                    MessageBox.Show("la base del triangulo debe ser un numero mayor a 0");
                }
                else
                {
                    double resultado = 3 * baseTriangulo;
                    MessageBox.Show("El perimetro es: " + resultado);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("debe ingresar un numero valido");
            }
        }
    }
}
