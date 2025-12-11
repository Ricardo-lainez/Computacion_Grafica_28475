using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppStar
{
    public partial class frmStar : Form
    {
        public frmStar()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                float altura = float.Parse(this.txtAltura.Text);
                int centerx = ptbGrafica.Left + ptbGrafica.Width / 2;
                int centery = ptbGrafica.Top + ptbGrafica.Height / 2;


            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de entrada no válido. Por favor, " +
                    "ingrese un número válido para la altura.", "Error de Formato", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

    }
}
