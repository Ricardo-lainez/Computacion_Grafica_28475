using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppProjectU1
{
    public partial class Figura6 : Form
    {
        private FigureTransformer transformer;
        private float currentRadioCm = 0;
        private bool isTranslating = false;

        public Figura6()
        {
            InitializeComponent();
            transformer = new FigureTransformer();
        }

        private void Figura6_Load(object sender, EventArgs e)
        {
            hScrollBarEscala.Minimum = 10;
            hScrollBarEscala.Maximum = 200;
            hScrollBarEscala.Value = 100;
            hScrollBarEscala.LargeChange = 10;
            hScrollBarEscala.SmallChange = 1;
        }

        /// <summary>
        /// Dibuja la Flor de la Vida (19 círculos)
        /// </summary>
        private void DrawFigure()
        {
            if (currentRadioCm <= 0)
            {
                if (ptbGrafica.Image != null)
                {
                    ptbGrafica.Image.Dispose();
                    ptbGrafica.Image = null;
                }
                return;
            }

            // Preparar el área de dibujo
            Bitmap bmp = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Black);

                // Conversión de cm a píxeles
                float dpi = g.DpiX;
                float pixelesPorCm = dpi / 2.54f;
                float radio = currentRadioCm * pixelesPorCm;

                PointF center = new PointF(ptbGrafica.Width / 2f, ptbGrafica.Height / 2f);

                transformer.Center = center;
                transformer.ApplyTransform(g);

                using (Pen whitePen = new Pen(Color.White, 2.0f))
                using (Pen dashedPen = new Pen(Color.Gray, 1.5f))
                {
                    dashedPen.DashStyle = DashStyle.Dash;

                    // Red triangular equilátera para la Flor de la Vida
                    // Distancia horizontal entre centros: r
                    // Distancia vertical entre filas: (√3/2)·r

                    float dx = radio; // Distancia horizontal
                    float dy = radio * (float)Math.Sqrt(3) / 2f; // Distancia vertical

                    // Radio del círculo envolvente
                    float radioEnvolvente = 2 * radio;

                    // Límite inferior para eliminar la última fila
                    float limiteInferior = -dy * 2.5f;

                    // Lista para almacenar los centros de círculos válidos
                    List<PointF> centros = new List<PointF>();

                    // Generar la red triangular
                    // Recorrer filas desde arriba hacia abajo
                    int maxFilas = (int)Math.Ceiling(radioEnvolvente / dy) + 2;

                    for (int fila = -maxFilas; fila <= maxFilas; fila++)
                    {
                        float y = fila * dy;

                        // Offset horizontal para filas impares (patrón hexagonal)
                        float offsetX = (fila % 2 == 0) ? 0 : dx / 2f;

                        // Recorrer columnas
                        int maxCols = (int)Math.Ceiling(radioEnvolvente / dx) + 2;
                        for (int col = -maxCols; col <= maxCols; col++)
                        {
                            float x = col * dx + offsetX;

                            // Verificar si el círculo completo está dentro del círculo envolvente
                            float distancia = (float)Math.Sqrt(x * x + y * y);

                            // El círculo debe estar completamente dentro y por encima del límite inferior
                            if (distancia + radio <= radioEnvolvente && y > limiteInferior)
                            {
                                // Agregar este centro a la lista
                                centros.Add(new PointF(center.X + x, center.Y + y));
                            }
                        }
                    }

                    // Dibujar todos los círculos válidos con su patrón interno
                    foreach (PointF punto in centros)
                    {
                        DrawCircle(g, whitePen, punto, radio);

                        // Dibujar los 6 círculos que rodean cada círculo (patrón de pétalos)
                        for (int i = 0; i < 6; i++)
                        {
                            float angulo = i * 60f * (float)Math.PI / 180f;
                            float petalX = punto.X + radio * (float)Math.Cos(angulo);
                            float petalY = punto.Y + radio * (float)Math.Sin(angulo);
                            DrawCircle(g, whitePen, new PointF(petalX, petalY), radio);
                        }
                    }

                    // Círculo exterior punteado (radio 2r)
                    DrawCircle(g, dashedPen, center, radioEnvolvente);
                }
            }

            // Asignar el dibujo final al PictureBox
            if (ptbGrafica.Image != null)
            {
                ptbGrafica.Image.Dispose();
            }
            ptbGrafica.Image = bmp;
        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {
            // Opcional: validación en tiempo real si lo deseas
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtRadio.Text, out float radioCm) || radioCm <= 0)
            {
                MessageBox.Show("Por favor, ingresa un número válido y positivo para el radio en CENTÍMETROS.");
                return;
            }

            currentRadioCm = radioCm;
            transformer.Reset();
            isTranslating = false;
            btnTrasladar.Text = "Trasladar";
            hScrollBarEscala.Value = 100;

            DrawFigure();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (ptbGrafica.Image != null)
            {
                ptbGrafica.Image.Dispose();
                ptbGrafica.Image = null;
            }

            txtRadio.Text = "";
            currentRadioCm = 0;

            transformer.Reset();

            hScrollBarEscala.Value = 100;
            isTranslating = false;
            btnTrasladar.Text = "Trasladar";
        }

        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            isTranslating = !isTranslating;

            if (isTranslating)
            {
                btnTrasladar.Text = "Fijar Posición";
                ptbGrafica.Focus();
                MessageBox.Show("Modo Traslación Activado.\nUsa las flechas del teclado para mover la figura.",
                    "Trasladar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnTrasladar.Text = "Trasladar";
                this.ActiveControl = null;
            }
        }

        private void btnRotarIzq_Click(object sender, EventArgs e)
        {
            transformer.Rotate(-15.0f);
            DrawFigure();
        }

        private void btnRotarDer_Click(object sender, EventArgs e)
        {
            transformer.Rotate(15.0f);
            DrawFigure();
        }

        private void hScrollBarEscala_Scroll(object sender, ScrollEventArgs e)
        {
            float newScale = hScrollBarEscala.Value / 100.0f;
            transformer.SetScale(newScale);
            DrawFigure();
        }

        private void ptbGrafica_Click(object sender, EventArgs e)
        {
            // Opcional: puedes agregar funcionalidad aquí si lo necesitas
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isTranslating)
            {
                float moveAmount = 10.0f;
                bool handled = false;

                switch (keyData)
                {
                    case Keys.Left:
                        transformer.Translate(-moveAmount, 0);
                        handled = true;
                        break;
                    case Keys.Right:
                        transformer.Translate(moveAmount, 0);
                        handled = true;
                        break;
                    case Keys.Up:
                        transformer.Translate(0, -moveAmount);
                        handled = true;
                        break;
                    case Keys.Down:
                        transformer.Translate(0, moveAmount);
                        handled = true;
                        break;
                }

                if (handled)
                {
                    DrawFigure();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DrawCircle(Graphics g, Pen p, PointF center, float radius)
        {
            if (radius > 0)
            {
                g.DrawEllipse(p,
                    center.X - radius,
                    center.Y - radius,
                    radius * 2,
                    radius * 2);
            }
        }
    }
}