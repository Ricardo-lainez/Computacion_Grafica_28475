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
    public partial class Rombo : Form
    {
        public Rombo()
        {
            InitializeComponent();
        }

        private void Rombo_Load(object sender, EventArgs e)
        {

        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int Dmayor = int.Parse(txtDmayor.Text);
                int dmenor = int.Parse(txtdmenor.Text);

                MessageBox.Show("el area de la altura" + (Dmayor + dmenor));
            }
            catch (FormatException)
            {
                MessageBox.Show("ingresar numeros validos");
            }
        }
    }
}
