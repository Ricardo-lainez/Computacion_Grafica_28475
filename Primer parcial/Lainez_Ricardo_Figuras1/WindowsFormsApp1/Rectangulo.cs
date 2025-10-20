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
    public partial class Rectangulo : Form
    {
        public Rectangulo()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double baseRectangulo = double.Parse(txtBaseRectangulo.Text);
                double alturaRectangulo = double.Parse(txtalturaRectangulo.Text);

                if (baseRectangulo<=0 || alturaRectangulo <= 0)
                {
                    MessageBox.Show("La base o la altura deben ser mayor que 0");
                }
                else
                {
                    MessageBox.Show("El area del rectangulo es: " + (baseRectangulo * alturaRectangulo));
                }
            }
            catch (FormatException) {
                MessageBox.Show("Ingrese un numero valido");
            }
            

        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double baseRectangulo = double.Parse(txtBaseRectangulo.Text);
                double alturaRectangulo = double.Parse(txtalturaRectangulo.Text);

                if (baseRectangulo <= 0 || alturaRectangulo <= 0)
                {
                    MessageBox.Show("La base o la altura deben ser mayor que 0");
                }
                else
                {
                    MessageBox.Show("El perimetro del triangulo es: " + (2 * baseRectangulo + 2 * alturaRectangulo));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }
    }
}
