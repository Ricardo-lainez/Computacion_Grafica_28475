using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq; // Necesario para .FirstOrDefault()

namespace WinAppTriangleSt
{
    public partial class frmTriangleStar : Form
    {
        // --- 1. VARIABLES DE ESTADO ---

        // ¡Nuestra nueva clase!
        // Maneja todo el estado de rotación, escala y traslación.
        private FigureTransformer figureTransform = new FigureTransformer();

        // El radio sigue siendo una propiedad del dibujo, no de la transformación.
        private double currentRadius = 0;

        // El modo ahora solo se preocupa por la traslación.
        private enum TransformMode { None, Translate }
        private TransformMode currentMode = TransformMode.None;


        // --- 2. CONSTRUCTOR ---
        public frmTriangleStar()
        {
            InitializeComponent();
            this.ptbGrafico.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ptbGrafico_MouseWheel);
            this.KeyPreview = true;
        }

        // --- 3. BOTÓN PRINCIPAL ---
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            double r;
            if (!double.TryParse(txtRadio.Text, out r) || r <= 0)
            {
                MessageBox.Show("Por favor, ingresa un número válido y positivo para el radio.");
                return;
            }

            // (1) Resetear el estado
            currentRadius = r;
            figureTransform.Reset(); // Llama al reset de nuestra clase

            // (2) Establecer el pivote en el centro del PictureBox
            figureTransform.Pivot = new PointF(ptbGrafico.Width / 2.0f, ptbGrafico.Height / 2.0f);

            currentMode = TransformMode.None;
            hScrollEscala.Value = 50; // Pone el scroll en el centro

            RedrawFigure();
        }

        // --- 4. MÉTODO DE DIBUJO CENTRAL ---
        private void RedrawFigure()
        {
            if (currentRadius <= 0) return;

            if (ptbGrafico.Image != null)
            {
                ptbGrafico.Image.Dispose();
            }
            Bitmap bmp = new Bitmap(ptbGrafico.Width, ptbGrafico.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // --- ¡LA MAGIA! APLICAR TRANSFORMACIONES ---
                // Le pedimos a nuestra clase que aplique sus transformaciones al lienzo 'g'
                figureTransform.ApplyTransforms(g);

                // --- El resto del código de dibujo es idéntico ---
                // Se dibuja centrado en (0, 0) porque 'g' ya está transformado.
                const int numLados = 8;
                const double anguloPaso = 45.0;

                Color[] coloresTriangulos = new Color[]
                {
                    Color.Purple, Color.Blue, Color.Yellow, Color.Red,
                    Color.Purple, Color.Yellow, Color.Purple, Color.Green
                };

                double r = currentRadius;

                for (int i = 0; i < numLados; i++)
                {
                    double angulo_i_rad = (90 + i * anguloPaso) * Math.PI / 180.0;
                    double angulo_next_rad = (90 + (i + 1) * anguloPaso) * Math.PI / 180.0;

                    PointF vPoint = new PointF((float)(r * Math.Cos(angulo_i_rad)), (float)(r * Math.Sin(angulo_i_rad)));
                    double distInterseccion = r * Math.Cos(anguloPaso * Math.PI / 180.0);
                    PointF pPoint = new PointF((float)(distInterseccion * Math.Cos(angulo_next_rad)), (float)(distInterseccion * Math.Sin(angulo_next_rad)));
                    PointF centerPoint = new PointF(0, 0);

                    PointF[] trianguloPoints = { centerPoint, vPoint, pPoint };
                    using (Brush brush = new SolidBrush(coloresTriangulos[i]))
                    {
                        g.FillPolygon(brush, trianguloPoints);
                    }
                    g.DrawLine(pen, centerPoint, vPoint);
                    g.DrawLine(pen, vPoint, pPoint);
                }
            }
            ptbGrafico.Image = bmp;
            ptbGrafico.Refresh();
        }

        // --- 5. BOTONES DE MODO Y ACCIÓN ---
        private void btnTrasladar_Click_1(object sender, EventArgs e)
        {
            currentMode = TransformMode.Translate;
            ptbGrafico.Focus();
        }

        // (El botón btnRotar original se fue)

        // Botones de rotación directa
        private void btnRotarIzquierda_Click(object sender, EventArgs e)
        {
            figureTransform.Rotate(-5); // Le dice a la clase que rote -5 grados
            RedrawFigure();
        }

        private void btnRotarDerecha_Click(object sender, EventArgs e)
        {
            figureTransform.Rotate(5); // Le dice a la clase que rote +5 grados
            RedrawFigure();
        }

        // (El botón btnEscala original se fue)
        private void btnEscala_Click_1(object sender, EventArgs e) { /* Botón no utilizado */ }


        // --- 6. MANEJADORES DE INPUT ---

        // Evento KeyDown (Solo para Traslación)
        private void frmTriangleStar_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentMode != TransformMode.Translate) return;

            bool needsRedraw = false;
            switch (currentMode)
            {
                case TransformMode.Translate:
                    if (e.KeyCode == Keys.Left) { figureTransform.Translate(-5, 0); needsRedraw = true; }
                    else if (e.KeyCode == Keys.Right) { figureTransform.Translate(5, 0); needsRedraw = true; }
                    else if (e.KeyCode == Keys.Up) { figureTransform.Translate(0, -5); needsRedraw = true; }
                    else if (e.KeyCode == Keys.Down) { figureTransform.Translate(0, 5); needsRedraw = true; }
                    break;
            }
            if (needsRedraw)
            {
                RedrawFigure();
                e.Handled = true;
            }
        }

        // Evento MouseWheel (para Escala)
        private void ptbGrafico_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                figureTransform.AdjustScale(1.1f); // Le dice a la clase que aumente
            else if (e.Delta < 0)
                figureTransform.AdjustScale(1 / 1.1f); // Le dice a la clase que reduzca

            // Sincronizar el HScrollBar con la nueva escala
            int newScrollValue = (int)(figureTransform.Scale * 100);

            if (newScrollValue < hScrollEscala.Minimum) newScrollValue = hScrollEscala.Minimum;
            if (newScrollValue > hScrollEscala.Maximum) newScrollValue = hScrollEscala.Maximum;

            // Actualizamos la escala por si fue limitada por el min/max
            figureTransform.SetScale(newScrollValue / 100.0f);
            hScrollEscala.Value = newScrollValue;

            RedrawFigure();
        }

        // Evento del HScrollBar (para Escala)
        private void hScrollEscala_Scroll(object sender, ScrollEventArgs e)
        {
            float newScale = e.NewValue / 100.0f;
            figureTransform.SetScale(newScale); // Le dice a la clase la nueva escala
            RedrawFigure();
        }

        // --- 7. BOTONES DE UTILIDAD ---
        private void btnResetear_Click(object sender, EventArgs e)
        {
            var tbAlt = this.Controls.Find("txtRadio", true).FirstOrDefault() as TextBox;
            if (tbAlt != null) tbAlt.Text = string.Empty;

            // Resetear estado
            currentRadius = 0;
            figureTransform.Reset(); // ¡Llamada a la nueva clase!
            currentMode = TransformMode.None;
            hScrollEscala.Value = 100;

            // Limpiar PictureBox
            if (this.ptbGrafico != null)
            {
                this.ptbGrafico.Image?.Dispose();
                var bmp = new Bitmap(Math.Max(1, this.ptbGrafico.Width), Math.Max(1, this.ptbGrafico.Height));
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                this.ptbGrafico.Image = bmp;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) { }
    }
}