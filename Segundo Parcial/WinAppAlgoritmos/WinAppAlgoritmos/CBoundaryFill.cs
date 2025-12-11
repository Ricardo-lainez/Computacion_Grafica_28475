using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public class CBoundaryFill
    {
        private const int TAMANO_PIXEL = 5;
        private Bitmap mBitmap;
        private int canvasPixelCols;
        private int canvasPixelRows;
        private HashSet<Point> visitados;
        private bool esperandoClick = false;
        private PictureBox ptbGrafica;

        public CBoundaryFill()
        {
        }

        /// <summary>
        /// Activa el modo de selección de punto
        /// </summary>
        public void ActivarSeleccionPunto(PictureBox ptbGrafica)
        {
            if (ptbGrafica.Image == null)
            {
                MessageBox.Show("Primero debe graficar una circunferencia.", "Advertencia");
                return;
            }

            this.ptbGrafica = ptbGrafica;
            esperandoClick = true;

            // Cambiar el cursor a una cruz para indicar modo de selección
            ptbGrafica.Cursor = Cursors.Cross;

            MessageBox.Show("Haga clic en el punto donde desea iniciar el relleno.", "Boundary Fill - Seleccionar punto");
        }

        /// <summary>
        /// Maneja el evento de clic en el PictureBox
        /// </summary>
        public async void OnPictureBoxClick(object sender, MouseEventArgs e, PictureBox ptbGrafica)
        {
            if (!esperandoClick)
                return;

            esperandoClick = false;
            ptbGrafica.Cursor = Cursors.Default;

            // Convertir las coordenadas del mouse a coordenadas de cuadrícula
            int gridX = e.X / TAMANO_PIXEL;
            int gridY = e.Y / TAMANO_PIXEL;

            // Obtener el bitmap actual
            mBitmap = new Bitmap(ptbGrafica.Image);
            canvasPixelCols = mBitmap.Width / TAMANO_PIXEL;
            canvasPixelRows = mBitmap.Height / TAMANO_PIXEL;

            // Convertir Y a coordenadas de cuadrícula invertidas
            int gridYInvertido = canvasPixelRows - gridY - 1;

            // Validar que el punto esté dentro del canvas
            if (gridX < 0 || gridX >= canvasPixelCols || gridYInvertido < 0 || gridYInvertido >= canvasPixelRows)
            {
                MessageBox.Show("El punto seleccionado está fuera del área válida.", "Error");
                return;
            }

            // Obtener el color del punto seleccionado
            Color colorPunto = ObtenerColorPixel(gridX, gridYInvertido);
            Color colorRelleno = Color.Cyan;
            Color colorBorde = Color.Red;

            if (!EsColorRellenable(colorPunto))
            {
                MessageBox.Show("Solo puede rellenar áreas blancas o sin relleno previo.\nNo puede iniciar desde bordes o áreas ya rellenadas.", "Advertencia");
                return;
            }

            // Inicializar el conjunto de visitados
            visitados = new HashSet<Point>();

            // Ejecutar Boundary Fill con animación desde el punto seleccionado
            int pixelesRellenados = await BoundaryFillIterativo(gridX, gridYInvertido, colorBorde, colorRelleno, ptbGrafica);

            MessageBox.Show($"Relleno completado. Pixeles rellenados: {pixelesRellenados}\nPunto inicial: ({gridX}, {gridYInvertido})", "Boundary Fill");
        }

        /// <summary>
        /// Ejecuta el algoritmo Boundary Fill desde el centro del canvas (modo automático)
        /// </summary>
        public async void EjecutarBoundaryFill(PictureBox ptbGrafica)
        {
            if (ptbGrafica.Image == null)
            {
                MessageBox.Show("Primero debe graficar una circunferencia.", "Advertencia");
                return;
            }

            // Obtener el bitmap actual del PictureBox
            mBitmap = new Bitmap(ptbGrafica.Image);
            canvasPixelCols = mBitmap.Width / TAMANO_PIXEL;
            canvasPixelRows = mBitmap.Height / TAMANO_PIXEL;

            // Calcular el centro del canvas
            int centroX = canvasPixelCols / 2;
            int centroY = canvasPixelRows / 2;

            // Buscar un punto blanco cerca del centro (evitando el punto verde central)
            Point puntoInicio = BuscarPuntoBlanco(centroX, centroY);
            
            if (puntoInicio.X == -1)
            {
                MessageBox.Show("No se encontró un área blanca para rellenar.\nAsegúrese de graficar primero una circunferencia.", "Advertencia");
                return;
            }

            Color colorRelleno = Color.Cyan;
            Color colorBorde = Color.Red;

            // Inicializar el conjunto de visitados
            visitados = new HashSet<Point>();

            // Ejecutar Boundary Fill con animación
            int pixelesRellenados = await BoundaryFillIterativo(puntoInicio.X, puntoInicio.Y, colorBorde, colorRelleno, ptbGrafica);

            MessageBox.Show($"Relleno completado. Pixeles rellenados: {pixelesRellenados}", "Boundary Fill");
        }

        /// <summary>
        /// Verifica si está esperando un clic
        /// </summary>
        public bool EstaEsperandoClick()
        {
            return esperandoClick;
        }

        /// <summary>
        /// Cancela el modo de selección
        /// </summary>
        public void CancelarSeleccion(PictureBox ptbGrafica)
        {
            esperandoClick = false;
            if (ptbGrafica != null)
                ptbGrafica.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Busca un punto blanco cerca del centro (evitando el punto verde central)
        /// </summary>
        private Point BuscarPuntoBlanco(int centroX, int centroY)
        {
            // Buscar en espiral desde el centro hacia afuera
            for (int radio = 1; radio <= 10; radio++)
            {
                // Buscar en las 4 direcciones cardinales y diagonales
                Point[] puntosABuscar = new Point[]
                {
                    new Point(centroX + radio, centroY),
                    new Point(centroX - radio, centroY),
                    new Point(centroX, centroY + radio),
                    new Point(centroX, centroY - radio),
                    new Point(centroX + radio, centroY + radio),
                    new Point(centroX - radio, centroY - radio),
                    new Point(centroX + radio, centroY - radio),
                    new Point(centroX - radio, centroY + radio)
                };

                foreach (Point p in puntosABuscar)
                {
                    if (p.X >= 0 && p.X < canvasPixelCols && p.Y >= 0 && p.Y < canvasPixelRows)
                    {
                        Color color = ObtenerColorPixel(p.X, p.Y);
                        if (EsColorBlanco(color))
                        {
                            return p;
                        }
                    }
                }
            }

            return new Point(-1, -1);
        }

        /// <summary>
        /// Verifica si un color es blanco (con tolerancia)
        /// </summary>
        private bool EsColorBlanco(Color color)
        {
            int tolerancia = 30;
            return color.R >= (255 - tolerancia) && 
                   color.G >= (255 - tolerancia) && 
                   color.B >= (255 - tolerancia);
        }

        private bool EsColorRellenable(Color color)
        {
            if (EsColorBlanco(color))
                return true;

            if (Math.Abs(color.R - 211) <= 30 && Math.Abs(color.G - 211) <= 30 && Math.Abs(color.B - 211) <= 30)
                return true;

            if (color.R > 200 && color.G < 100 && color.B < 100)
                return false;

            if (color.B > 150 && color.R < 100 && color.G < 100)
                return false;

            if (color.R > 200 && color.G > 200 && color.B < 100)
                return false;

            if (color.R < 100 && color.G > 150 && color.B > 150)
                return false;

            if (color.R > 200 && color.G < 100 && color.B > 150)
                return false;

            if (color.G > 100 && color.R < 100 && color.B < 100)
                return false;

            if (color.R < 50 && color.G < 50 && color.B < 50)
                return false;

            return true;
        }

        /// <summary>
        /// Algoritmo Boundary Fill iterativo (4-conectado)
        /// </summary>
        private async Task<int> BoundaryFillIterativo(int x, int y, Color colorBorde, Color colorRelleno, PictureBox ptbGrafica)
        {
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(x, y));

            int contador = 0;
            int pixelesRellenados = 0;

            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                int px = p.X;
                int py = p.Y;

                // Verificar límites
                if (px < 0 || px >= canvasPixelCols || py < 0 || py >= canvasPixelRows)
                    continue;

                // Si ya fue visitado, continuar
                if (visitados.Contains(p))
                    continue;

                // Marcar como visitado
                visitados.Add(p);

                // Obtener el color actual del pixel
                Color colorActual = ObtenerColorPixel(px, py);

                // Verificar si es el color del borde o si ya está rellenado
                if (!EsColorRellenable(colorActual))
                    continue;

                // Pintar el pixel
                PintarPixel(px, py, colorRelleno);
                pixelesRellenados++;

                // Actualizar la vista con animación cada 100 pixeles
                contador++;
                if (contador % 1 == 0)
                {
                    ptbGrafica.Image = mBitmap;
                    ptbGrafica.Refresh();
                    await Task.Delay(1);
                }

                // Agregar los 4 vecinos a la pila (4-conectado)
                pila.Push(new Point(px + 1, py));
                pila.Push(new Point(px - 1, py));
                pila.Push(new Point(px, py + 1));
                pila.Push(new Point(px, py - 1));
            }

            // Actualización final
            ptbGrafica.Image = mBitmap;
            ptbGrafica.Refresh();

            return pixelesRellenados;
        }

        /// <summary>
        /// Verifica si un color es el color del borde
        /// </summary>
        private bool EsColorBorde(Color color, Color colorBorde)
        {
            int tolerancia = 50;
            return Math.Abs(color.R - colorBorde.R) <= tolerancia &&
                   Math.Abs(color.G - colorBorde.G) <= tolerancia &&
                   Math.Abs(color.B - colorBorde.B) <= tolerancia;
        }

        /// <summary>
        /// Verifica si dos colores son similares
        /// </summary>
        private bool EsColorSimilar(Color c1, Color c2)
        {
            int tolerancia = 50;
            return Math.Abs(c1.R - c2.R) <= tolerancia &&
                   Math.Abs(c1.G - c2.G) <= tolerancia &&
                   Math.Abs(c1.B - c2.B) <= tolerancia;
        }

        /// <summary>
        /// Obtiene el color de un pixel en coordenadas de cuadrícula
        /// </summary>
        private Color ObtenerColorPixel(int gridX, int gridY)
        {
            int pixelX = gridX * TAMANO_PIXEL + (TAMANO_PIXEL / 2);
            int pixelY = (canvasPixelRows - gridY - 1) * TAMANO_PIXEL + (TAMANO_PIXEL / 2);

            if (pixelX < 0 || pixelX >= mBitmap.Width || pixelY < 0 || pixelY >= mBitmap.Height)
                return Color.Black;

            try
            {
                return mBitmap.GetPixel(pixelX, pixelY);
            }
            catch
            {
                return Color.Black;
            }
        }

        /// <summary>
        /// Pinta un pixel en coordenadas de cuadrícula
        /// </summary>
        private void PintarPixel(int gridX, int gridY, Color color)
        {
            int pixelX = gridX * TAMANO_PIXEL;
            int pixelY = (canvasPixelRows - gridY - 1) * TAMANO_PIXEL;

            if (pixelX < 0 || pixelX >= mBitmap.Width || pixelY < 0 || pixelY >= mBitmap.Height)
                return;

            using (Graphics g = Graphics.FromImage(mBitmap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                g.DrawRectangle(Pens.Black, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
            }
        }
    }
}