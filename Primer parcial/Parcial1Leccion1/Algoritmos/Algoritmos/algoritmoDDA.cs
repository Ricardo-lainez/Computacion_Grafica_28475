using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Algoritmos
{
    public partial class AlgoritmoDDA : Form
    {
        // ... (Variables de clase, InitializeComponent, InitializeLienzo, DrawGrid, etc. permanecen igual) ...
        private Bitmap _lienzoBitmap;
        private Graphics _lienzoGraphics;
        private readonly int _pixelSize = 10;
        private List<Point> _linePoints;
        private int _currentPointIndex;
        private int _centerX;
        private int _centerY;
        private Point _originalStartPoint;
        private Point _originalEndPoint;

        public AlgoritmoDDA()
        {
            InitializeComponent();
            InitializeLienzo();
            this.Resize += new EventHandler(AlgoritmoDDA_Resize);
            if (lineTimer != null) lineTimer.Interval = 50;
        }

        // Métodos InitializeLienzo, AlgoritmoDDA_Resize, DrawGrid (código omitido por ser igual)
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

        private void AlgoritmoDDA_Resize(object sender, EventArgs e)
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

        // Método CalcularLineaDDA (código omitido por ser igual)
        private List<Point> CalcularLineaDDA(int x1, int y1, int x2, int y2)
        {
            List<Point> points = new List<Point>();
            int dx = x2 - x1;
            int dy = y2 - y1;
            int pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));
            if (pasos == 0) { points.Add(new Point(x1, y1)); return points; }

            float xIncremento = (float)dx / pasos;
            float yIncremento = (float)dy / pasos;
            float x = x1;
            float y = y1;

            for (int i = 0; i <= pasos; i++)
            {
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xIncremento;
                y += yIncremento;
            }
            return points;
        }

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

            _linePoints = CalcularLineaDDA(x1, y1, x2, y2);
            _currentPointIndex = 0;

            if (lineTimer != null)
            {
                lineTimer.Start();
            }
        }

        // Evento que dibuja un píxel en cada "tick" (Animación Pixel por Pixel)
        private void lineTimer_Tick(object sender, EventArgs e)
        {
            if (_linePoints != null && _currentPointIndex < _linePoints.Count)
            {
                Point p = _linePoints[_currentPointIndex];

                // Dibujar en color ROJO (los píxeles DDA)
                using (Brush brush = new SolidBrush(Color.Red))
                {
                    int screenX = (p.X + _centerX) * _pixelSize;
                    int screenY = (_centerY - p.Y - 1) * _pixelSize; // Ajuste para origen y Y invertida

                    _lienzoGraphics.FillRectangle(brush, screenX, screenY, _pixelSize, _pixelSize);
                }

                pictureBoxLienzo.Invalidate();

                _currentPointIndex++;
            }
            else
            {
                // La animación DDA ha terminado
                if (lineTimer != null)
                {
                    lineTimer.Stop();
                }

                // NUEVO PASO: Dibuja la línea negra continua
                DibujarLineaContinuaNegra(_originalStartPoint, _originalEndPoint);
                pictureBoxLienzo.Invalidate();
            }
        }

        // Método auxiliar para convertir coordenadas lógicas a coordenadas de pantalla (con centrado y centrado de píxel)
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

        // Método para dibujar una línea continua (negra) usando los centros de los píxeles
        private void DibujarLineaContinuaNegra(Point startPoint, Point endPoint)
        {
            using (Pen blackPen = new Pen(Color.Black, 2))
            {
                // Convertir los puntos lógicos a coordenadas de pantalla centradas
                System.Drawing.Point screenStart = ConvertToScreenCoordinates(startPoint);
                System.Drawing.Point screenEnd = ConvertToScreenCoordinates(endPoint);

                // Dibujar la línea nativa (recta) entre los centros de los píxeles inicial y final
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