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
    public partial class Romboide : Form
    {
        public Romboide()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double baseRombo = double.Parse(txtBase.Text);
                double alturaRombo = double.Parse(txtAltura.Text);

                if(baseRombo<=0 || alturaRombo <= 0)
                {
                    MessageBox.Show("La base o la altura deben ser mayor a 0");
                }
                else
                {
                    MessageBox.Show("El area del romboide es: " + (baseRombo * alturaRombo));
                }
            }
            catch (FormatException) {
                MessageBox.Show("Ingrese un número valido");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double baseRombo = double.Parse(txtBase.Text);
                double alturaRombo = double.Parse(txtAltura.Text);

                if (baseRombo<=0 || alturaRombo<=0)
                {
                    MessageBox.Show("La base o la altura deben ser mayor a 0");
                }
                else
                {
                    MessageBox.Show("El perimetro del romboide es: " + (2 * baseRombo + 2 * alturaRombo));
                }
                
            }
            catch (FormatException)
            {

            }
        }
    }
}
