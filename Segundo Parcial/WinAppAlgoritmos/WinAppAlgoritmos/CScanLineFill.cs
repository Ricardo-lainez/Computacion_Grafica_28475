using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public class CScanLineFill
    {
        private const int TAMANO_PIXEL = 5;
        private Bitmap mBitmap;
        private int canvasPixelCols;
        private int canvasPixelRows;
        private bool esperandoClick = false;
        private PictureBox ptbGrafica;

        public CScanLineFill()
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
            ptbGrafica.Cursor = Cursors.Cross;
            MessageBox.Show("Haga clic en el punto donde desea iniciar el relleno.", "Scan Line Fill - Seleccionar punto");
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

            int gridX = e.X / TAMANO_PIXEL;
            int gridY = e.Y / TAMANO_PIXEL;

            mBitmap = new Bitmap(ptbGrafica.Image);
            canvasPixelCols = mBitmap.Width / TAMANO_PIXEL;
            canvasPixelRows = mBitmap.Height / TAMANO_PIXEL;

            int gridYInvertido = canvasPixelRows - gridY - 1;

            if (gridX < 0 || gridX >= canvasPixelCols || gridYInvertido < 0 || gridYInvertido >= canvasPixelRows)
            {
                MessageBox.Show("El punto seleccionado está fuera del área válida.", "Error");
                return;
            }

            Color colorPunto = ObtenerColorPixel(gridX, gridYInvertido);
            Color colorRelleno = Color.Magenta;
            Color colorBorde = Color.Red;

            // Validar que el punto sea rellenable
            if (!EsColorRellenable(colorPunto))
            {
                MessageBox.Show("Solo puede rellenar áreas blancas o sin relleno previo.\nNo puede iniciar desde bordes o áreas ya rellenadas.", "Advertencia");
                return;
            }

            int pixelesRellenados = await ScanLineFillIterativo(gridX, gridYInvertido, colorBorde, colorRelleno, ptbGrafica);
            MessageBox.Show($"Relleno completado. Pixeles rellenados: {pixelesRellenados}\nPunto inicial: ({gridX}, {gridYInvertido})", "Scan Line Fill");
        }

        /// <summary>
        /// Ejecuta el algoritmo Scan Line Fill desde el centro del canvas (modo automático)
        /// </summary>
        public async void EjecutarScanLineFill(PictureBox ptbGrafica)
        {
            if (ptbGrafica.Image == null)
            {
                MessageBox.Show("Primero debe graficar una circunferencia.", "Advertencia");
                return;
            }

            mBitmap = new Bitmap(ptbGrafica.Image);
            canvasPixelCols = mBitmap.Width / TAMANO_PIXEL;
            canvasPixelRows = mBitmap.Height / TAMANO_PIXEL;

            int centroX = canvasPixelCols / 2;
            int centroY = canvasPixelRows / 2;

            Point puntoInicio = BuscarPuntoBlanco(centroX, centroY);
            
            if (puntoInicio.X == -1)
            {
                MessageBox.Show("No se encontró un área blanca para rellenar.\nAsegúrese de graficar primero una circunferencia.", "Advertencia");
                return;
            }

            Color colorRelleno = Color.Magenta;
            Color colorBorde = Color.Red;

            int pixelesRellenados = await ScanLineFillIterativo(puntoInicio.X, puntoInicio.Y, colorBorde, colorRelleno, ptbGrafica);
            MessageBox.Show($"Relleno completado. Pixeles rellenados: {pixelesRellenados}", "Scan Line Fill");
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
        /// Algoritmo Scan Line Fill mejorado
        /// Rellena línea por línea (escaneo horizontal) solo en áreas rellenables
        /// </summary>
        private async Task<int> ScanLineFillIterativo(int x, int y, Color colorBorde, Color colorRelleno, PictureBox ptbGrafica)
        {
            Stack<Point> pila = new Stack<Point>();
            HashSet<Point> visitados = new HashSet<Point>();
            pila.Push(new Point(x, y));

            int contador = 0;
            int pixelesRellenados = 0;

            while (pila.Count > 0)
            {
                Point seed = pila.Pop();
                int px = seed.X;
                int py = seed.Y;

                // Verificar límites
                if (px < 0 || px >= canvasPixelCols || py < 0 || py >= canvasPixelRows)
                    continue;

                // Si ya fue visitado, continuar
                if (visitados.Contains(seed))
                    continue;

                // Marcar como visitado
                visitados.Add(seed);

                // Obtener el color actual
                Color colorActual = ObtenerColorPixel(px, py);

                // Si no es rellenable, continuar
                if (!EsColorRellenable(colorActual))
                    continue;

                // SCAN LINE FILL: Encontrar límite izquierdo
                int xIzq = px;
                while (xIzq >= 0)
                {
                    Color c = ObtenerColorPixel(xIzq, py);
                    if (!EsColorRellenable(c))
                        break;

                    xIzq--;
                }
                xIzq++; // Ajustar al último pixel válido

                // Encontrar límite derecho
                int xDer = px;
                while (xDer < canvasPixelCols)
                {
                    Color c = ObtenerColorPixel(xDer, py);
                    if (!EsColorRellenable(c))
                        break;

                    xDer++;
                }
                xDer--; // Ajustar al último pixel válido

                // Rellenar toda la línea horizontal (scan line)
                bool buscarArriba = false;
                bool buscarAbajo = false;

                for (int i = xIzq; i <= xDer; i++)
                {
                    // Verificar que el pixel sea rellenable antes de pintar
                    Color colorPixel = ObtenerColorPixel(i, py);
                    if (EsColorRellenable(colorPixel))
                    {
                        PintarPixel(i, py, colorRelleno);
                        pixelesRellenados++;

                        // Actualizar vista cada ciertos pixeles
                        contador++;
                        if (contador % 1 == 0)
                        {
                            ptbGrafica.Image = mBitmap;
                            ptbGrafica.Refresh();
                            await Task.Delay(1);
                        }
                    }

                    // Buscar segmentos en la línea superior
                    if (py + 1 < canvasPixelRows)
                    {
                        Color cSup = ObtenerColorPixel(i, py + 1);
                        bool pixelSupRellenable = EsColorRellenable(cSup);

                        if (!buscarArriba && pixelSupRellenable && !visitados.Contains(new Point(i, py + 1)))
                        {
                            pila.Push(new Point(i, py + 1));
                            buscarArriba = true;
                        }
                        else if (buscarArriba && !pixelSupRellenable)
                        {
                            buscarArriba = false;
                        }
                    }

                    // Buscar segmentos en la línea inferior
                    if (py - 1 >= 0)
                    {
                        Color cInf = ObtenerColorPixel(i, py - 1);
                        bool pixelInfRellenable = EsColorRellenable(cInf);

                        if (!buscarAbajo && pixelInfRellenable && !visitados.Contains(new Point(i, py - 1)))
                        {
                            pila.Push(new Point(i, py - 1));
                            buscarAbajo = true;
                        }
                        else if (buscarAbajo && !pixelInfRellenable)
                        {
                            buscarAbajo = false;
                        }
                    }
                }

                // Actualización visual después de cada línea completa
                ptbGrafica.Image = mBitmap;
                ptbGrafica.Refresh();
                await Task.Delay(10);
            }

            // Actualización final
            ptbGrafica.Image = mBitmap;
            ptbGrafica.Refresh();

            return pixelesRellenados;
        }

        /// <summary>
        /// Busca un punto blanco cerca del centro
        /// </summary>
        private Point BuscarPuntoBlanco(int centroX, int centroY)
        {
            for (int radio = 1; radio <= 10; radio++)
            {
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
        /// Verifica si un color es blanco
        /// </summary>
        private bool EsColorBlanco(Color color)
        {
            int tolerancia = 30;
            return color.R >= (255 - tolerancia) && 
                   color.G >= (255 - tolerancia) && 
                   color.B >= (255 - tolerancia);
        }

        /// <summary>
        /// Verifica si un color es rellenable (blanco, gris claro o color de cuadrícula)
        /// Excluye bordes (rojo, azul) y áreas ya rellenadas (amarillo, cyan, magenta)
        /// </summary>
        private bool EsColorRellenable(Color color)
        {
            // Es blanco o casi blanco
            if (EsColorBlanco(color))
                return true;

            // Es gris claro (cuadrícula)
            if (Math.Abs(color.R - 211) <= 30 && Math.Abs(color.G - 211) <= 30 && Math.Abs(color.B - 211) <= 30)
                return true;

            // Rechazar rojos (borde)
            if (color.R > 200 && color.G < 100 && color.B < 100)
                return false;

            // Rechazar azules (borde)
            if (color.B > 150 && color.R < 100 && color.G < 100)
                return false;

            // Rechazar amarillos (Flood Fill previo)
            if (color.R > 200 && color.G > 200 && color.B < 100)
                return false;

            // Rechazar cyans (Boundary Fill previo)
            if (color.R < 100 && color.G > 150 && color.B > 150)
                return false;

            // Rechazar magentas (Scan Line Fill previo)
            if (color.R > 200 && color.G < 100 && color.B > 150)
                return false;

            // Rechazar verdes (centro)
            if (color.G > 100 && color.R < 100 && color.B < 100)
                return false;

            // Rechazar negros (borde de cuadrícula)
            if (color.R < 50 && color.G < 50 && color.B < 50)
                return false;

            return true;
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