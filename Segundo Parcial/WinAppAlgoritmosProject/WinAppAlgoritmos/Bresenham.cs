using System;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class Bresenham : Form
    {
        private CBresenham ObjBresenham = new CBresenham();

        public Bresenham()
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

        private void Bresenham_Load(object sender, EventArgs e)
        {
            ObjBresenham.InitializeData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica);

            int maxX = (ptbGrafica.Width / 5) - 1;
            int maxY = (ptbGrafica.Height / 5) - 1;
            this.Text = $"Bresenham - Rango válido: X(0-{maxX}), Y(0-{maxY})";
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (ObjBresenham.ReadData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica))
            {
                ObjBresenham.CalculateBresenham(ptbGrafica);
                ObjBresenham.DrawComplete(ptbGrafica);

                // Salidas eliminadas: ya no se muestran DeltaX, DeltaY ni P en TextBoxes
                // Tampoco se actualiza el título con el punto actual
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            ObjBresenham.PreviousStep(ptbGrafica);
            // Removida actualización del título
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ObjBresenham.NextStep(ptbGrafica);
            // Removida actualización del título
        }
    }
}
