using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    internal class CPMedio
    {
        private int mX1, mY1, mX2, mY2;
        private List<Point> mLinePoints;
        private int mCurrentStep;
        private Bitmap mBitmap;
        private const int PIXEL_SIZE = 5;
        private int canvasPixelRows = 0;
        private int canvasPixelCols = 0;

        // Propiedades para mostrar valores específicos de Punto Medio
        public int DeltaX { get; private set; } = 0;
        public int DeltaY { get; private set; } = 0;
        public int D_Inicial { get; private set; } = 0;

        public CPMedio()
        {
            mLinePoints = new List<Point>();
            mCurrentStep = 0;
        }

        public bool ReadData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2, PictureBox picCanvas)
        {
            try
            {
                mX1 = int.Parse(txtX1.Text);
                mY1 = int.Parse(txtY1.Text);
                mX2 = int.Parse(txtX2.Text);
                mY2 = int.Parse(txtY2.Text);

                if (mX1 < 0 || mY1 < 0 || mX2 < 0 || mY2 < 0)
                {
                    MessageBox.Show("Las coordenadas deben ser números positivos", "Error de validación");
                    return false;
                }

                int maxX = (picCanvas.Width / PIXEL_SIZE) - 1;
                int maxY = (picCanvas.Height / PIXEL_SIZE) - 1;

                if (mX1 > maxX || mX2 > maxX || mY1 > maxY || mY2 > maxY)
                {
                    MessageBox.Show($"Las coordenadas deben estar dentro del rango:\nX: 0 - {maxX}\nY: 0 - {maxY}",
                                    "Error de validación");
                    return false;
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Ingrese coordenadas válidas (solo números enteros)", "Error de entrada");
                return false;
            }
        }

        // Calcula todos los puntos usando el algoritmo de Punto Medio
        public void CalculateMidpoint(PictureBox picCanvas)
        {
            mLinePoints.Clear();

            int dx = Math.Abs(mX2 - mX1);
            int dy = Math.Abs(mY2 - mY1);

            DeltaX = dx;
            DeltaY = dy;

            int sx = (mX1 < mX2) ? 1 : -1;
            int sy = (mY1 < mY2) ? 1 : -1;

            canvasPixelRows = picCanvas.Height / PIXEL_SIZE;
            canvasPixelCols = picCanvas.Width / PIXEL_SIZE;

            int x = mX1;
            int y = mY1;

            // Algoritmo de Punto Medio
            if (dx > dy)
            {
                // Pendiente < 1
                int d = 2 * dy - dx;
                D_Inicial = d;

                mLinePoints.Add(new Point(x, y));

                while (x != mX2)
                {
                    x += sx;

                    if (d < 0)
                    {
                        d = d + 2 * dy;
                    }
                    else
                    {
                        y += sy;
                        d = d + 2 * dy - 2 * dx;
                    }

                    mLinePoints.Add(new Point(x, y));
                }
            }
            else
            {
                // Pendiente >= 1
                int d = 2 * dx - dy;
                D_Inicial = d;

                mLinePoints.Add(new Point(x, y));

                while (y != mY2)
                {
                    y += sy;

                    if (d < 0)
                    {
                        d = d + 2 * dx;
                    }
                    else
                    {
                        x += sx;
                        d = d + 2 * dx - 2 * dy;
                    }

                    mLinePoints.Add(new Point(x, y));
                }
            }

            mCurrentStep = 0;
        }

        public async void DrawComplete(PictureBox picCanvas)
        {
            InitializeCanvas(picCanvas);
            for (int i = 0; i < mLinePoints.Count; i++)
            {
                mCurrentStep = i;
                DrawUpToStep(picCanvas, i);
                await System.Threading.Tasks.Task.Delay(50);
            }
        }

        public void DrawUpToStep(PictureBox picCanvas, int step)
        {
            InitializeCanvas(picCanvas);

            // 1. Pintar los puntos primero
            for (int i = 0; i <= Math.Min(step, mLinePoints.Count - 1); i++)
            {
                Point p = mLinePoints[i];
                int yOriginInvertido = canvasPixelRows - p.Y - 1;
                Color pointColor = (i == step) ? Color.Red : Color.Blue;
                DrawPixel(p.X, yOriginInvertido, pointColor);
            }

            // 2. Dibujar la línea continua desde el inicio hasta el punto actual
            if (step >= 0 && step < mLinePoints.Count && mLinePoints.Count > 1)
            {
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Point currentPoint = mLinePoints[step];

                    int y1 = canvasPixelRows - mY1 - 1;
                    int yStep = canvasPixelRows - currentPoint.Y - 1;

                    using (Pen thickPen = new Pen(Color.Red, 2))
                    {
                        g.DrawLine(thickPen,
                                  mX1 * PIXEL_SIZE + PIXEL_SIZE / 2,
                                  y1 * PIXEL_SIZE + PIXEL_SIZE / 2,
                                  currentPoint.X * PIXEL_SIZE + PIXEL_SIZE / 2,
                                  yStep * PIXEL_SIZE + PIXEL_SIZE / 2);
                    }
                }
            }

            picCanvas.Image = mBitmap;
        }

        public void NextStep(PictureBox picCanvas)
        {
            if (mCurrentStep < mLinePoints.Count - 1)
            {
                mCurrentStep++;
                DrawUpToStep(picCanvas, mCurrentStep);
            }
        }

        public void PreviousStep(PictureBox picCanvas)
        {
            if (mCurrentStep > 0)
            {
                mCurrentStep--;
                DrawUpToStep(picCanvas, mCurrentStep);
            }
        }

        private void InitializeCanvas(PictureBox picCanvas)
        {
            if (mBitmap == null || mBitmap.Width != picCanvas.Width || mBitmap.Height != picCanvas.Height)
                mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);
                DrawGrid(g, picCanvas.Width, picCanvas.Height);
            }
        }

        private void DrawGrid(Graphics g, int width, int height)
        {
            using (Pen gridPen = new Pen(Color.LightGray, 1))
            {
                for (int x = 0; x < width; x += PIXEL_SIZE)
                { g.DrawLine(gridPen, x, 0, x, height); }
                for (int y = 0; y < height; y += PIXEL_SIZE)
                { g.DrawLine(gridPen, 0, y, width, y); }
            }
        }

        private void DrawPixel(int x, int y, Color color)
        {
            using (Graphics g = Graphics.FromImage(mBitmap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x * PIXEL_SIZE, y * PIXEL_SIZE, PIXEL_SIZE, PIXEL_SIZE);
                g.DrawRectangle(Pens.Black, x * PIXEL_SIZE, y * PIXEL_SIZE, PIXEL_SIZE, PIXEL_SIZE);
            }
        }

        public void InitializeData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2,
                                   PictureBox picCanvas)
        {
            mX1 = 0; mY1 = 0; mX2 = 0; mY2 = 0;
            txtX1.Text = ""; txtY1.Text = "";
            txtX2.Text = ""; txtY2.Text = "";
            mLinePoints.Clear();
            mCurrentStep = 0;
            picCanvas.Image = null;
            picCanvas.Refresh();
            txtX1.Focus();
        }

        public string GetCurrentPointInfo()
        {
            if (mLinePoints.Count == 0 || mCurrentStep >= mLinePoints.Count)
                return "Sin datos";

            Point current = mLinePoints[mCurrentStep];
            return $"Paso {mCurrentStep + 1}/{mLinePoints.Count} - Punto ({current.X}, {current.Y})";
        }
    }
}
