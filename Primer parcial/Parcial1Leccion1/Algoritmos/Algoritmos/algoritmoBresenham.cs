using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmos
{
    public partial class AlgoritmoBresenham : Form // Nota: Puedes renombrar la clase
    {
        // Variables de clase para el manejo del dibujo y la animación
        private Bitmap _lienzoBitmap;
        private Graphics _lienzoGraphics;
        private readonly int _pixelSize = 10;
        private List<Point> _linePoints;     // Lista para los puntos calculados por Bresenham
        private int _currentPointIndex;      // Índice del punto actual a dibujar en la animación

        // Variables para el centrado
        private int _centerX;
        private int _centerY;

        // Variables para almacenar los puntos inicial y final originales (para la línea continua)
        private Point _originalStartPoint;
        private Point _originalEndPoint;

        // Asegúrate de que tienes un componente Timer llamado 'lineTimer' en el diseño.

        public AlgoritmoBresenham()
        {
            InitializeComponent();

            InitializeLienzo();
            this.Resize += new EventHandler(AlgoritmoBresenham_Resize);

            if (lineTimer != null)
            {
                lineTimer.Interval = 50;
            }
        }

        // --- Métodos de Inicialización y Dibujo de Cuadrícula (Iguales a DDA) ---

        private void InitializeLienzo()
        {
            if (pictureBoxLienzo.Width <= 0 || pictureBoxLienzo.Height <= 0) return;

            if (_lienzoGraphics != null) _lienzoGraphics.Dispose();
            if (_lienzoBitmap != null) _lienzoBitmap.Dispose();

            _lienzoBitmap = new Bitmap(pictureBoxLienzo.Width, pictureBoxLienzo.Height);
            _lienzoGraphics = Graphics.FromImage(_lienzoBitmap);
            pictureBoxLienzo.Image = _lienzoBitmap;

            _centerX = (pictureBoxLienzo.Width / _pixelSize) / 2;
            _centerY = (pictureBoxLienzo.Height / _pixelSize) / 2;

            DrawGrid();
        }

        private void AlgoritmoBresenham_Resize(object sender, EventArgs e)
        {
            InitializeLienzo();
        }

        private void DrawGrid()
        {
            _lienzoGraphics.Clear(Color.White);

            using (Pen gridPen = new Pen(Color.LightGray, 1))
            using (Pen axisPen = new Pen(Color.DarkBlue, 2))
            {
                for (int i = 0; i < pictureBoxLienzo.Width; i += _pixelSize)
                    _lienzoGraphics.DrawLine(gridPen, i, 0, i, pictureBoxLienzo.Height);
                for (int i = 0; i < pictureBoxLienzo.Height; i += _pixelSize)
                    _lienzoGraphics.DrawLine(gridPen, 0, i, pictureBoxLienzo.Width, i);

                int screenXCenter = _centerX * _pixelSize;
                int screenYCenter = _centerY * _pixelSize;

                _lienzoGraphics.DrawLine(axisPen, 0, screenYCenter, pictureBoxLienzo.Width, screenYCenter);
                _lienzoGraphics.DrawLine(axisPen, screenXCenter, 0, screenXCenter, pictureBoxLienzo.Height);
            }
            pictureBoxLienzo.Invalidate();
        }

        // --- Implementación del Algoritmo de Bresenham ---

        private List<Point> CalcularLineaBresenham(int x1, int y1, int x2, int y2)
        {
            List<Point> points = new List<Point>();

            // Puntos a manipular (usamos variables locales para el intercambio y la simetría)
            int currentX = x1;
            int currentY = y1;
            int endX = x2;
            int endY = y2;

            // Calculamos las diferencias absolutas
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            // Determinamos la dirección (signo) de los incrementos
            int stepX = (x1 < x2) ? 1 : -1;
            int stepY = (y1 < y2) ? 1 : -1;

            // Flags para saber si debemos intercambiar X e Y (para el caso |dy| > |dx|)
            bool swapped = false;

            // 1. Manejo de pendientes m > 1 (Intercambio de ejes)
            if (dy > dx)
            {
                int temp = dx;
                dx = dy;
                dy = temp;
                swapped = true;
            }

            // 2. Inicialización del parámetro de decisión (p_k)
            // p_inicial = 2*dy - dx
            int p = 2 * dy - dx;

            // El punto inicial siempre se dibuja
            points.Add(new Point(currentX, currentY));

            // 3. Iteración principal
            for (int i = 0; i < dx; i++)
            {
                if (p < 0)
                {
                    // Elegimos el píxel E (East) o NE si los ejes fueron intercambiados
                    // p_k+1 = p_k + 2*dy
                    p += 2 * dy;

                    // Solo incrementamos la variable principal (X si no se intercambió, Y si se intercambió)
                    if (swapped)
                    {
                        currentY += stepY;
                    }
                    else
                    {
                        currentX += stepX;
                    }
                }
                else
                {
                    // Elegimos el píxel NE (Northeast) o N si los ejes fueron intercambiados
                    // p_k+1 = p_k + 2*dy - 2*dx
                    p += 2 * dy - 2 * dx;

                    // Incrementamos ambos (X y Y si no se intercambió, Y y X si se intercambió)
                    currentX += stepX;
                    currentY += stepY;
                }

                points.Add(new Point(currentX, currentY));
            }

            return points;
        }

        // --- Eventos de Control y Animación ---

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (lineTimer != null) lineTimer.Stop();

            if (!int.TryParse(txtCoordenadaIx.Text, out int x1) ||
                !int.TryParse(txtCoordenadaIy.Text, out int y1) ||
                !int.TryParse(txtCoordenadaFx.Text, out int x2) ||
                !int.TryParse(txtCoordenadaFy.Text, out int y2))
            {
                MessageBox.Show("Por favor, ingrese coordenadas enteras válidas.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Almacenar los puntos originales para la línea continua
            _originalStartPoint = new Point(x1, y1);
            _originalEndPoint = new Point(x2, y2);

            DrawGrid();

            // Llama al algoritmo de Bresenham
            _linePoints = CalcularLineaBresenham(x1, y1, x2, y2);
            _currentPointIndex = 0;

            if (lineTimer != null)
            {
                lineTimer.Start();
            }
            else
            {
                MessageBox.Show("¡ERROR! El componente Timer (lineTimer) no está inicializado. Vuelve a agregarlo al diseñador.", "Error de Componente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // Evento que dibuja un píxel en cada "tick" (Animación Pixel por Pixel)
        private void lineTimer_Tick(object sender, EventArgs e)
        {
            if (_linePoints != null && _currentPointIndex < _linePoints.Count)
            {
                Point p = _linePoints[_currentPointIndex];

                // Dibujar en color ROJO (los píxeles Bresenham)
                using (Brush brush = new SolidBrush(Color.Red))
                {
                    // 1. Traslación y Escalado para X
                    int screenX = (p.X + _centerX) * _pixelSize;

                    // 2. Traslación, Inversión Y, y ajuste (-1) para el origen correcto
                    int screenY = (_centerY - p.Y - 1) * _pixelSize;

                    _lienzoGraphics.FillRectangle(brush, screenX, screenY, _pixelSize, _pixelSize);
                }

                pictureBoxLienzo.Invalidate();

                _currentPointIndex++;
            }
            else
            {
                // La animación Bresenham ha terminado
                if (lineTimer != null)
                {
                    lineTimer.Stop();
                }

                // Dibuja la línea negra continua sobre los píxeles rojos
                DibujarLineaContinuaNegra(_originalStartPoint, _originalEndPoint);
                pictureBoxLienzo.Invalidate();
            }
        }

        // Método auxiliar para convertir coordenadas lógicas a coordenadas de pantalla (Centrado de Línea Continua)
        private System.Drawing.Point ConvertToScreenCoordinates(Point logicalPoint)
        {
            // 1. Calcular el punto de inicio (esquina superior izquierda) de la celda DDA
            int screenX_start = (logicalPoint.X + _centerX) * _pixelSize;
            int screenY_start = (_centerY - logicalPoint.Y - 1) * _pixelSize;

            // 2. Añadir el offset para encontrar el CENTRO exacto de la celda DDA
            int pixelCenterOffset = _pixelSize / 2;

            int screenX_center = screenX_start + pixelCenterOffset;
            int screenY_center = screenY_start + pixelCenterOffset;

            return new System.Drawing.Point(screenX_center, screenY_center);
        }

        // Método para dibujar una línea continua (negra) sobre los píxeles
        private void DibujarLineaContinuaNegra(Point startPoint, Point endPoint)
        {
            using (Pen blackPen = new Pen(Color.Black, 2))
            {
                System.Drawing.Point screenStart = ConvertToScreenCoordinates(startPoint);
                System.Drawing.Point screenEnd = ConvertToScreenCoordinates(endPoint);

                _lienzoGraphics.DrawLine(blackPen, screenStart, screenEnd);
            }
        }

        // Liberación de recursos
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_lienzoGraphics != null) _lienzoGraphics.Dispose();
            if (_lienzoBitmap != null) _lienzoBitmap.Dispose();
        }
    }
}