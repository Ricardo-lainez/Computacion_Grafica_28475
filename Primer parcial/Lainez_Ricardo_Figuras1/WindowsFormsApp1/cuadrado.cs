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
    public partial class Formcuadrado : Form
    {
        public Formcuadrado()
        {
            InitializeComponent();
        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int area = int.Parse(txtlado.Text);

                MessageBox.Show("el area es: " + (area * area));

            }
            catch (FormatException){
                MessageBox.Show("ingrese un numero valido.");

            }
            
        }

        private void btnperimetro_Click(object sender, EventArgs e)
        {
            try
            {
                int perimetro = int.Parse(txtlado.Text);
                MessageBox.Show("el perimetro es: " + (4 * perimetro));
            }
            catch (FormatException)
            {
                MessageBox.Show("ingrese un numero valido.");
            }
            
        }
    }
}
