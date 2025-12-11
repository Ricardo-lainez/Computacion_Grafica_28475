using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    internal class CCircunferencia
    {
        private int mCentroX, mCentroY, mRadio;
        private List<Point> mCirclePoints;
        private int mCurrentStep;
        private Bitmap mBitmap;
        private const int PIXEL_SIZE = 5;
        private int canvasPixelRows = 0;
        private int canvasPixelCols = 0;

        // Propiedades para mostrar valores específicos del algoritmo
        public int Radio { get; private set; } = 0;
        public int P_Inicial { get; private set; } = 0;

        public CCircunferencia()
        {
            mCirclePoints = new List<Point>();
            mCurrentStep = 0;
        }

        public bool ReadData(TextBox txtRadio, PictureBox picCanvas)
        {
            try
            {
                mRadio = int.Parse(txtRadio.Text);

                if (mRadio <= 0)
                {
                    MessageBox.Show("El radio debe ser un número positivo mayor a 0", "Error de validación");
                    return false;
                }

                // El centro será el centro del canvas
                mCentroX = (picCanvas.Width / PIXEL_SIZE) / 2;
                mCentroY = (picCanvas.Height / PIXEL_SIZE) / 2;

                // Validar que la circunferencia quepa en el canvas
                int maxRadius = Math.Min(mCentroX, mCentroY) - 1;

                if (mRadio > maxRadius)
                {
                    MessageBox.Show($"El radio máximo permitido es: {maxRadius}", "Error de validación");
                    return false;
                }

                Radio = mRadio;
                return true;
            }
            catch
            {
                MessageBox.Show("Ingrese un radio válido (solo números enteros)", "Error de entrada");
                return false;
            }
        }

        // Calcula todos los puntos usando el algoritmo de circunferencia (Punto Medio)
        public void CalculateCircle(PictureBox picCanvas)
        {
            mCirclePoints.Clear();

            canvasPixelRows = picCanvas.Height / PIXEL_SIZE;
            canvasPixelCols = picCanvas.Width / PIXEL_SIZE;

            int x = 0;
            int y = mRadio;
            int p = 1 - mRadio;
            P_Inicial = p;

            // Agregar los 8 puntos simétricos del punto inicial
            AddCirclePoints(x, y);

            // Ciclo del algoritmo
            while (x < y)
            {
                x = x + 1;

                if (p < 0)
                {
                    p = p + 2 * x + 3;
                }
                else
                {
                    y = y - 1;
                    p = p + 2 * (x - y) + 5;
                }

                // Agregar los 8 puntos simétricos para cada punto calculado
                AddCirclePoints(x, y);
            }

            mCurrentStep = 0;
        }

        // Agrega los 8 puntos simétricos de la circunferencia
        private void AddCirclePoints(int x, int y)
        {
            // 8 octantes de simetría
            mCirclePoints.Add(new Point(mCentroX + x, mCentroY + y));
            mCirclePoints.Add(new Point(mCentroX - x, mCentroY + y));
            mCirclePoints.Add(new Point(mCentroX + x, mCentroY - y));
            mCirclePoints.Add(new Point(mCentroX - x, mCentroY - y));
            mCirclePoints.Add(new Point(mCentroX + y, mCentroY + x));
            mCirclePoints.Add(new Point(mCentroX - y, mCentroY + x));
            mCirclePoints.Add(new Point(mCentroX + y, mCentroY - x));
            mCirclePoints.Add(new Point(mCentroX - y, mCentroY - x));
        }

        public async void DrawComplete(PictureBox picCanvas)
        {
            InitializeCanvas(picCanvas);
            for (int i = 0; i < mCirclePoints.Count; i++)
            {
                mCurrentStep = i;
                DrawUpToStep(picCanvas, i);
                await System.Threading.Tasks.Task.Delay(20);
            }
        }

        public void DrawUpToStep(PictureBox picCanvas, int step)
        {
            InitializeCanvas(picCanvas);

            // Pintar los puntos de la circunferencia
            for (int i = 0; i <= Math.Min(step, mCirclePoints.Count - 1); i++)
            {
                Point p = mCirclePoints[i];
                int yOriginInvertido = canvasPixelRows - p.Y - 1;
                Color pointColor = (i == step) ? Color.Red : Color.Blue;
                
                // Validar que el punto esté dentro del canvas
                if (p.X >= 0 && p.X < canvasPixelCols && yOriginInvertido >= 0 && yOriginInvertido < canvasPixelRows)
                {
                    DrawPixel(p.X, yOriginInvertido, pointColor);
                }
            }

            // Dibujar el centro de la circunferencia
            int yCentro = canvasPixelRows - mCentroY - 1;
            DrawPixel(mCentroX, yCentro, Color.Green);

            picCanvas.Image = mBitmap;
        }

        public void NextStep(PictureBox picCanvas)
        {
            if (mCurrentStep < mCirclePoints.Count - 1)
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

        public void InitializeData(TextBox txtRadio, PictureBox picCanvas)
        {
            mRadio = 0;
            mCentroX = 0;
            mCentroY = 0;
            txtRadio.Text = "";
            mCirclePoints.Clear();
            mCurrentStep = 0;
            picCanvas.Image = null;
            picCanvas.Refresh();
            txtRadio.Focus();
        }

        public string GetCurrentPointInfo()
        {
            if (mCirclePoints.Count == 0 || mCurrentStep >= mCirclePoints.Count)
                return "Sin datos";

            Point current = mCirclePoints[mCurrentStep];
            return $"Paso {mCurrentStep + 1}/{mCirclePoints.Count} - Punto ({current.X}, {current.Y}) - Radio: {mRadio}";
        }
    }
}