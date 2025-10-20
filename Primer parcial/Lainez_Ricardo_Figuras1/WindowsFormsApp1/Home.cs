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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(txtNum1.Text);
            int num2 = int.Parse(txtNum2.Text);
            MessageBox.Show("la suma es: " + (num1 + num2));
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            int num3 = int.Parse(txtNum1.Text);
            int num4 = int.Parse(txtNum2.Text);
            MessageBox.Show("la resta es: " + (num3 - num4));
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            int num5 = int.Parse(txtNum1.Text);
            int num6 = int.Parse(txtNum2.Text);
            MessageBox.Show("la multiplicacion es: " + (num5 * num6));
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            int num7 = int.Parse(txtNum1.Text);
            int num8 = int.Parse(txtNum2.Text);
            if(num8 == 0)
            {
                MessageBox.Show("no es posible dividir para 0");
            }
            else
            {
                MessageBox.Show("la division es: " + (num7 / num8));
            }
            
        }

        private void txtNum1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNum1_MouseEnter(object sender, EventArgs e)
        {
            txtNum1.BackColor = Color.Azure;
        }
    }
}
