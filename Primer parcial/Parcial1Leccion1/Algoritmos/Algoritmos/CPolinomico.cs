using System;
using System.Collections.Generic;
using System.Drawing; // Necesario para Bitmap, Graphics, Color, Point
using System.Threading.Tasks; // Necesario para la animación (Task.Delay)
using System.Windows.Forms;   // Necesario para manipular PictureBox y TextBox

namespace Algoritmos
{
    public class CPolinomico
    {
        // Configuración visual
        private const int TAMANO_PIXEL = 5; // Tamaño de cada cuadrito
        private Bitmap mBitmap;

        // Variables de la circunferencia
        private int mRadio;
        private int mCentroX;
        private int mCentroY;

        // Lista para guardar los puntos calculados antes de dibujar
        private List<Point> listaPuntos;

        public CPolinomico()
        {
            listaPuntos = new List<Point>();
        }

        // Método principal que llama el Formulario
        public async void Graficar(PictureBox ptbGrafica, TextBox txtRadio)
        {
            // 1. Validaciones y Lectura de datos
            if (!int.TryParse(txtRadio.Text, out mRadio) || mRadio <= 0)
            {
                MessageBox.Show("Por favor ingrese un radio válido mayor a 0.");
                return;
            }

            // Calculamos el centro basado en las dimensiones del PictureBox
            int columnas = ptbGrafica.Width / TAMANO_PIXEL;
            int filas = ptbGrafica.Height / TAMANO_PIXEL;
            mCentroX = columnas / 2;
            mCentroY = filas / 2;

            // 2. Inicializar el Bitmap y dibujar la cuadrícula base
            InicializarLienzo(ptbGrafica);

            // 3. Calcular los puntos usando la Ecuación Polinómica
            CalcularPuntosPolinomico();

            // 4. Dibujar los puntos con animación
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                foreach (Point p in listaPuntos)
                {
                    // Pintar el pixel simulado (rectángulo relleno)
                    // Nota: Invertimos Y (filas - y - 1) porque en C# el 0,0 está arriba-izquierda
                    int pixelX = p.X * TAMANO_PIXEL;
                    int pixelY = (filas - p.Y - 1) * TAMANO_PIXEL;

                    // Dibujar el cuadrado relleno (Rojo)
                    g.FillRectangle(Brushes.Red, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);
                    // Dibujar el borde del cuadrado (Negro) para que se vea la cuadrícula
                    g.DrawRectangle(Pens.Black, pixelX, pixelY, TAMANO_PIXEL, TAMANO_PIXEL);

                    // Actualizar el PictureBox
                    ptbGrafica.Refresh();

                    // Pequeña pausa para simular la animación "se vaya pintando"
                    await Task.Delay(10);
                }
            }
        }

        private void CalcularPuntosPolinomico()
        {
            listaPuntos.Clear();

            // ALGORITMO POLINÓMICO: y = Raiz(r^2 - x^2)
            // Iteramos x desde 0 hasta el radio
            for (int x = 0; x <= mRadio; x++)
            {
                // Aplicamos la fórmula despejada de Pitágoras
                double yDouble = Math.Sqrt((mRadio * mRadio) - (x * x));

                // Redondeamos al entero más cercano para obtener el pixel
                int y = (int)Math.Round(yDouble);

                // Como la fórmula solo calcula un cuadrante, usamos simetría de 4 lados
                // para llenar toda la circunferencia.

                // Cuadrante 1 (+x, +y)
                listaPuntos.Add(new Point(mCentroX + x, mCentroY + y));
                // Cuadrante 2 (-x, +y)
                listaPuntos.Add(new Point(mCentroX - x, mCentroY + y));
                // Cuadrante 3 (-x, -y)
                listaPuntos.Add(new Point(mCentroX - x, mCentroY - y));
                // Cuadrante 4 (+x, -y)
                listaPuntos.Add(new Point(mCentroX + x, mCentroY - y));
            }
        }

        private void InicializarLienzo(PictureBox ptbGrafica)
        {
            if (ptbGrafica.Width == 0 || ptbGrafica.Height == 0) return;

            mBitmap = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);

                // Dibujar Cuadrícula de fondo
                Pen lapizGris = new Pen(Color.LightGray, 1);

                // Líneas Verticales
                for (int i = 0; i < ptbGrafica.Width; i += TAMANO_PIXEL)
                    g.DrawLine(lapizGris, i, 0, i, ptbGrafica.Height);

                // Líneas Horizontales
                for (int j = 0; j < ptbGrafica.Height; j += TAMANO_PIXEL)
                    g.DrawLine(lapizGris, 0, j, ptbGrafica.Width, j);

                // Marcar el centro (opcional, en Verde)
                int cPixelX = mCentroX * TAMANO_PIXEL;
                int cPixelY = ((ptbGrafica.Height / TAMANO_PIXEL) - mCentroY - 1) * TAMANO_PIXEL;
                g.FillRectangle(Brushes.Green, cPixelX, cPixelY, TAMANO_PIXEL, TAMANO_PIXEL);
            }

            ptbGrafica.Image = mBitmap;
        }
    }
}