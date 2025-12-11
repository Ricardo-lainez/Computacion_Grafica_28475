using System;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class DDA : Form
    {
        private CDDA ObjDDA = new CDDA();

        public DDA()
        {
            InitializeComponent();
            if (ptbGrafica != null)
                ptbGrafica.BackColor = System.Drawing.Color.White;

            ConfigurarValidaciones();
        }

        private void ConfigurarValidaciones()
        {
            txtInicioX.KeyPress += TextBox_KeyPress;
            txtInicioY.KeyPress += TextBox_KeyPress;
            txtFinalX.KeyPress += TextBox_KeyPress;
            txtFinalY.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DDA_Load(object sender, EventArgs e)
        {
            ObjDDA.InitializeData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica);

            int maxX = (ptbGrafica.Width / 5) - 1;
            int maxY = (ptbGrafica.Height / 5) - 1;
            this.Text = $"DDA - Rango válido: X(0-{maxX}), Y(0-{maxY})";
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (ObjDDA.ReadData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica))
            {
                ObjDDA.CalculateDDA(ptbGrafica);
                ObjDDA.DrawComplete(ptbGrafica);

                // Salidas eliminadas: ya no se muestran Pendiente ni K en TextBoxes
                // Tampoco se actualiza el título con el punto actual
            }
        }

        
    }
}
