using System;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class PMedio : Form
    {
        private CPMedio ObjPMedio = new CPMedio();

        public PMedio()
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

        private void PMedio_Load(object sender, EventArgs e)
        {
            ObjPMedio.InitializeData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica);

            int maxX = (ptbGrafica.Width / 5) - 1;
            int maxY = (ptbGrafica.Height / 5) - 1;
            this.Text = $"Punto Medio - Rango válido: X(0-{maxX}), Y(0-{maxY})";
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (ObjPMedio.ReadData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica))
            {
                ObjPMedio.CalculateMidpoint(ptbGrafica);
                ObjPMedio.DrawComplete(ptbGrafica);

                // Salidas eliminadas: ya no se muestran DeltaX, DeltaY ni D_Inicial en TextBoxes
                // Tampoco se actualiza el título con el punto actual
            }
        }

    }
}
