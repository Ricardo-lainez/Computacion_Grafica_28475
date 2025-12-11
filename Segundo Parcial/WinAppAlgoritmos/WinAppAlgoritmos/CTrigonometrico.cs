using System;
using System.Collections.Generic;
using System.Drawing; // Necesario para Bitmap, Graphics, Color, Point
using System.Threading.Tasks; // Necesario para Task.Delay
using System.Windows.Forms;   // Necesario para manipular PictureBox y TextBox

namespace Algoritmos
{
    public class CTrigonometrico
    {
        // Configuración visual
        private const int TAMANO_PIXEL = 5;
        private Bitmap mBitmap;

        // Variables de la circunferencia
        private int mRadio;
        private int mCentroX;
        private int mCentroY;

        private List<Point> listaPuntos;

        public CTrigonometrico()
        {
            listaPuntos = new List<Point>();
        }

        public async void Graficar(PictureBox ptbGrafica, TextBox txtRadio)
        {
            // 1. Validaciones
            if (!int.TryParse(txtRadio.Text, out mRadio) || mRadio <= 0)
            {
                MessageBox.Show("Por favor ingrese un radio válido mayor a 0.");
                return;
            }

            // Calculamos el centro del PictureBox en "coordenadas de cuadrícula"
            int columnas = ptbGrafica.Width / TAMANO_PIXEL;
            int filas = ptbGrafica.Height / TAMANO_PIXEL;
            mCentroX = columnas / 2;
            mCentroY = filas / 2;

            // 2. Preparar lienzo
            InicializarLienzo(ptbGrafica);

            // 3. Calcular puntos con fórmula POLAR (Trigonométrica)
            CalcularPuntosPolar();

            // 4. Dibujar con animación
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                foreach (Point p in listaPuntos)
                {
                    // Validar que el punto esté dentro del área visible
                    if (p.X >= 0 && p.X < columnas && p.Y >= 0 && p.Y < filas)
                    {
                        // Transformación a coordenadas de pantalla (píxeles reales)
                        int pixelX = p.X * TAMANO_PIXEL;
                        // Invertimos Y para que el (0,0) cartesiano sea abajo-izquierda visualmente
                        int pixelY = (filas - p.Y - 1) * TAMANO_PIXEL;

                        // Relleno Rojo
                        g.FillRectangle(Brushes.Red, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                        // Borde Negro
                        g.DrawRectangle(Pens.Black, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);

                        ptbGrafica.Refresh();
                        await Task.Delay(5); // Delay pequeño para ver el trazo circular
                    }
                }
            }
        }

        private void CalcularPuntosPolar()
        {
            listaPuntos.Clear();

            // ==========================================================
            // ALGORITMO TRIGONOMÉTRICO (POLAR)
            // x = xc + r * cos(θ)
            // y = yc + r * sin(θ)
            // ==========================================================

            // Definimos el paso del ángulo (theta).
            // Si el paso es muy grande (ej: 0.1), quedarán huecos.
            // La regla de oro es: paso ≈ 1 / radio.
            double paso = 1.0 / mRadio;

            // Iteramos desde 0 hasta 2*PI (Círculo completo, 360 grados)
            for (double theta = 0; theta < 2 * Math.PI; theta += paso)
            {
                // Calculamos X e Y usando trigonométria
                double x_double = mRadio * Math.Cos(theta);
                double y_double = mRadio * Math.Sin(theta);

                // Redondeamos para obtener la coordenada en la grilla
                int x = (int)Math.Round(x_double);
                int y = (int)Math.Round(y_double);

                // Trasladamos al centro y agregamos a la lista
                // Nota: Aquí no necesitamos simetría manual porque el ciclo 
                // for recorre todo el círculo (0 a 360 grados).
                listaPuntos.Add(new Point(mCentroX + x, mCentroY + y));
            }
        }

        private void InicializarLienzo(PictureBox ptbGrafica)
        {
            if (ptbGrafica.Width == 0 || ptbGrafica.Height == 0) return;

            mBitmap = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);

                // Dibujar Cuadrícula
                Pen lapizGris = new Pen(Color.LightGray, 1);

                for (int i = 0; i < ptbGrafica.Width; i += TAMANO_PIXEL)
                    g.DrawLine(lapizGris, i, 0, i, ptbGrafica.Height);

                for (int j = 0; j < ptbGrafica.Height; j += TAMANO_PIXEL)
                    g.DrawLine(lapizGris, 0, j, ptbGrafica.Width, j);

                // Marcar centro (Verde)
                int cPixelX = mCentroX * TAMANO_PIXEL;
                int cPixelY = ((ptbGrafica.Height / TAMANO_PIXEL) - mCentroY - 1) * TAMANO_PIXEL;
                g.FillRectangle(Brushes.Green, cPixelX, cPixelY, TAMANO_PIXEL, TAMANO_PIXEL);
            }
            ptbGrafica.Image = mBitmap;
        }
    }
}