using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public class CPolinomico
    {
        private const int TAMANO_PIXEL = 5;
        private Bitmap mBitmap;
        private int mRadio;
        private int mCentroX;
        private int mCentroY;
        private List<Point> listaPuntos;

        public CPolinomico()
        {
            listaPuntos = new List<Point>();
        }

        public async void Graficar(PictureBox ptbGrafica, TextBox txtRadio)
        {
            if (!int.TryParse(txtRadio.Text, out mRadio) || mRadio <= 0)
            {
                MessageBox.Show("Por favor ingrese un radio válido mayor a 0.");
                return;
            }

            int columnas = ptbGrafica.Width / TAMANO_PIXEL;
            int filas = ptbGrafica.Height / TAMANO_PIXEL;
            mCentroX = columnas / 2;
            mCentroY = filas / 2;

            InicializarLienzo(ptbGrafica);
            CalcularPuntosPolinomico();

            // Dibujar los puntos del algoritmo polinómico con animación
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                foreach (Point p in listaPuntos)
                {
                    int pixelX = p.X * TAMANO_PIXEL;
                    int pixelY = (filas - p.Y - 1) * TAMANO_PIXEL;

                    g.FillRectangle(Brushes.Red, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                    g.DrawRectangle(Pens.Black, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);

                    ptbGrafica.Refresh();
                    await Task.Delay(3);
                }
            }

            // Cerrar completamente el círculo
            CerrarCirculoCompleto(ptbGrafica, filas);
            ptbGrafica.Refresh();
        }

        /// <summary>
        /// Cierra el círculo completamente usando un enfoque por ángulos
        /// </summary>
        private void CerrarCirculoCompleto(PictureBox ptbGrafica, int filas)
        {
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                // Crear un conjunto ordenado de puntos por ángulo
                var puntosOrdenados = listaPuntos
                    .Select(p => new
                    {
                        Punto = p,
                        Angulo = Math.Atan2(p.Y - mCentroY, p.X - mCentroX)
                    })
                    .OrderBy(x => x.Angulo)
                    .Select(x => x.Punto)
                    .ToList();

                // Conectar cada punto con el siguiente en orden angular
                for (int i = 0; i < puntosOrdenados.Count; i++)
                {
                    Point actual = puntosOrdenados[i];
                    Point siguiente = puntosOrdenados[(i + 1) % puntosOrdenados.Count];

                    // Solo dibujar línea si los puntos están cerca (evitar líneas largas incorrectas)
                    double distancia = Math.Sqrt(
                        Math.Pow(siguiente.X - actual.X, 2) + 
                        Math.Pow(siguiente.Y - actual.Y, 2)
                    );

                    if (distancia <= 3) // Umbral de distancia
                    {
                        DibujarLineaBresenham(actual, siguiente, g, filas);
                    }
                }

                // Rellenar huecos adicionales usando un algoritmo de barrido circular
                RellenarHuecosCirculares(g, filas);
            }
        }

        /// <summary>
        /// Rellena huecos usando un barrido circular completo
        /// </summary>
        private void RellenarHuecosCirculares(Graphics g, int filas)
        {
            // Usar un barrido angular para asegurar que todos los puntos del círculo estén pintados
            int numPasos = mRadio * 8; // Más pasos = mayor precisión
            
            for (int i = 0; i < numPasos; i++)
            {
                double angulo = (2 * Math.PI * i) / numPasos;
                
                // Calcular punto en el círculo usando trigonometría
                int x = (int)Math.Round(mCentroX + mRadio * Math.Cos(angulo));
                int y = (int)Math.Round(mCentroY + mRadio * Math.Sin(angulo));

                // Pintar el punto
                int pixelX = x * TAMANO_PIXEL;
                int pixelY = (filas - y - 1) * TAMANO_PIXEL;

                if (pixelX >= 0 && pixelX < mBitmap.Width && pixelY >= 0 && pixelY < mBitmap.Height)
                {
                    g.FillRectangle(Brushes.Red, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                    g.DrawRectangle(Pens.Black, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                }
            }
        }

        /// <summary>
        /// Dibuja una línea entre dos puntos usando Bresenham
        /// </summary>
        private void DibujarLineaBresenham(Point p1, Point p2, Graphics g, int filas)
        {
            int x0 = p1.X;
            int y0 = p1.Y;
            int x1 = p2.X;
            int y1 = p2.Y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                int pixelX = x0 * TAMANO_PIXEL;
                int pixelY = (filas - y0 - 1) * TAMANO_PIXEL;

                if (pixelX >= 0 && pixelX < mBitmap.Width && pixelY >= 0 && pixelY < mBitmap.Height)
                {
                    g.FillRectangle(Brushes.Red, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                    g.DrawRectangle(Pens.Black, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                }

                if (x0 == x1 && y0 == y1) break;

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        private void CalcularPuntosPolinomico()
        {
            listaPuntos.Clear();

            // ALGORITMO POLINÓMICO: y = √(r² - x²)
            // Calcular puntos iterando sobre X
            for (int x = 0; x <= mRadio; x++)
            {
                double yDouble = Math.Sqrt((mRadio * mRadio) - (x * x));
                int y = (int)Math.Round(yDouble);

                // Agregar los 4 puntos simétricos
                listaPuntos.Add(new Point(mCentroX + x, mCentroY + y));
                listaPuntos.Add(new Point(mCentroX - x, mCentroY + y));
                listaPuntos.Add(new Point(mCentroX - x, mCentroY - y));
                listaPuntos.Add(new Point(mCentroX + x, mCentroY - y));
            }

            // Calcular puntos iterando sobre Y para mayor cobertura
            for (int y = 0; y <= mRadio; y++)
            {
                double xDouble = Math.Sqrt((mRadio * mRadio) - (y * y));
                int x = (int)Math.Round(xDouble);

                // Agregar los 4 puntos simétricos
                listaPuntos.Add(new Point(mCentroX + x, mCentroY + y));
                listaPuntos.Add(new Point(mCentroX - x, mCentroY + y));
                listaPuntos.Add(new Point(mCentroX - x, mCentroY - y));
                listaPuntos.Add(new Point(mCentroX + x, mCentroY - y));
            }

            // Eliminar duplicados
            listaPuntos = listaPuntos.Distinct().ToList();
        }

        private void InicializarLienzo(PictureBox ptbGrafica)
        {
            if (ptbGrafica.Width == 0 || ptbGrafica.Height == 0) return;

            mBitmap = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);

                Pen lapizGris = new Pen(Color.LightGray, 1);

                for (int i = 0; i < ptbGrafica.Width; i += TAMANO_PIXEL)
                    g.DrawLine(lapizGris, i, 0, i, ptbGrafica.Height);

                for (int j = 0; j < ptbGrafica.Height; j += TAMANO_PIXEL)
                    g.DrawLine(lapizGris, 0, j, ptbGrafica.Width, j);

                int cPixelX = mCentroX * TAMANO_PIXEL;
                int cPixelY = ((ptbGrafica.Height / TAMANO_PIXEL) - mCentroY - 1) * TAMANO_PIXEL;
                g.FillRectangle(Brushes.Green, cPixelX, cPixelY, TAMANO_PIXEL, TAMANO_PIXEL);
            }

            ptbGrafica.Image = mBitmap;
        }
    }
}