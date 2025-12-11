using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppStar
{
    public partial class Form1 : Form
    {   
        private const float SF = 20f;

        public Form1()
        {
            InitializeComponent();

            this.altura.KeyPress += altura_KeyPress;

            if (this.pictureBoxGrafico != null)
            {
                this.pictureBoxGrafico.Image?.Dispose();
                var bmpInit = new Bitmap(Math.Max(1, this.pictureBoxGrafico.Width), Math.Max(1, this.pictureBoxGrafico.Height));
                using (var g = Graphics.FromImage(bmpInit))
                {
                    g.Clear(Color.White);
                }
                this.pictureBoxGrafico.Image = bmpInit;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void altura_TextChanged(object sender, EventArgs e)
        {

        }

        private void altura_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
                return;
            }

            var decSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            char decChar = decSep[0];

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == decChar)
            {
                if (tb.Text.Contains(decSep))
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }

        private void buttonGraficar_Click(object sender, EventArgs e)
        {
            var tbAlt = this.Controls.Find("altura", true).FirstOrDefault() as TextBox;
            if (tbAlt == null)
            {
                MessageBox.Show("Control 'altura' no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbAlt.Text))
            {
                MessageBox.Show($"Introduzca la altura de la estrella en unidades (1 unidad = {SF} px).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbAlt.Focus();
                return;
            }

            if (!float.TryParse(tbAlt.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out float requestedUnits))
            {
                MessageBox.Show("Altura inválida. Introduzca un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbAlt.Focus();
                return;
            }

            if (requestedUnits <= 0f)
            {
                MessageBox.Show("La altura debe ser mayor que 0 (unidades).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbAlt.Focus();
                return;
            }

            if (this.pictureBoxGrafico == null)
            {
                MessageBox.Show("Control 'pictureBoxGrafico' no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int pbWidth = Math.Max(1, this.pictureBoxGrafico.Width);
            int pbHeight = Math.Max(1, this.pictureBoxGrafico.Height);
            int maxOuterPx = Math.Min(pbWidth, pbHeight) / 2 - 10;
            if (maxOuterPx <= 5)
            {
                MessageBox.Show("El área de dibujo es demasiado pequeña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double outerRadiusPx = requestedUnits * SF;

            const double MinPixels = 10.0;
            if (outerRadiusPx < MinPixels)
            {
                MessageBox.Show($"La altura solicitada es demasiado pequeña para dibujar (mínimo {MinPixels / SF:0.##} unidades = {MinPixels} px).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbAlt.Focus();
                return;
            }

            if (outerRadiusPx > maxOuterPx)
            {
                double maxOuterUnits = maxOuterPx / SF;
                var result = MessageBox.Show(
                    $"La altura solicitada ({requestedUnits:0.##} unidades) supera el máximo visible ({maxOuterUnits:0.##} unidades). Se reducirá a {maxOuterUnits:0.##} unidades. ¿Continuar?",
                    "Ajuste de tamaño",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                outerRadiusPx = maxOuterPx;
            }

            var centerX = pbWidth / 2;
            var centerY = pbHeight / 2;

            this.pictureBoxGrafico.Image?.Dispose();
            var bmp = new Bitmap(pbWidth, pbHeight);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                DrawFivePointStar(g, centerX, centerY, (float)outerRadiusPx, Pens.Black);
            }

            this.pictureBoxGrafico.Image = bmp;
        }

        private void buttonResetear_Click(object sender, EventArgs e)
        {
            var tbAlt = this.Controls.Find("altura", true).FirstOrDefault() as TextBox;
            if (tbAlt != null) tbAlt.Text = string.Empty;

            if (this.pictureBoxGrafico != null)
            {
                this.pictureBoxGrafico.Image?.Dispose();
                var bmp = new Bitmap(Math.Max(1, this.pictureBoxGrafico.Width), Math.Max(1, this.pictureBoxGrafico.Height));
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                this.pictureBoxGrafico.Image = bmp;
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrawFivePointStar(Graphics g, int cx, int cy, float outerRadius, Pen pen)
        {
            const int points = 5;
            PointF[] outer = new PointF[points];

            double degToRad = Math.PI / 180.0;
            double cos18 = Math.Cos(18.0 * degToRad);
            double cos36 = Math.Cos(36.0 * degToRad);

            outer[0] = new PointF(cx, cy - outerRadius);

            // Vértices superiores 
            double horizUpper = outerRadius * cos18;
            double sqrtPartUpper = Math.Sqrt(Math.Max(0.0, (double)outerRadius * outerRadius - horizUpper * horizUpper));
            float yUpper = (float)(cy - sqrtPartUpper);
            outer[1] = new PointF(cx + (float)horizUpper, yUpper); // superior derecha
            outer[4] = new PointF(cx - (float)horizUpper, yUpper); // superior izquierda

            // Vértices inferiores 
            double vertLower = outerRadius * cos36;
            double horizLower = Math.Sqrt(Math.Max(0.0, (double)outerRadius * outerRadius - vertLower * vertLower));
            float yLower = (float)(cy + vertLower);
            outer[2] = new PointF(cx + (float)horizLower, yLower); // inferior derecha
            outer[3] = new PointF(cx - (float)horizLower, yLower); // inferior izquierda

            PointF[] order = new PointF[points + 1];
            for (int i = 0; i < points; i++)
            {
                order[i] = outer[(i * 2) % points];
            }
            order[points] = order[0];

            g.DrawLines(pen, order);
        }
    }
}