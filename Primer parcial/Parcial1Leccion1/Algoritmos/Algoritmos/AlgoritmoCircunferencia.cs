using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmos
{
    public partial class AlgoritmoCircunferencia : Form
    {
        public AlgoritmoCircunferencia()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            // 1. Validar que se haya ingresado un radio
            int r;
            if (!int.TryParse(txtRadio.Text, out r))
            {
                MessageBox.Show("Por favor, ingresa un valor numérico válido para el radio.");
                return;
            }

            // 2. Preparar el área de dibujo (Bitmap)
            // Creamos un bitmap del tamaño del PictureBox
            Bitmap bmp = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);

            // 3. Calcular el centro del PictureBox (xc, yc)
            int xc = ptbGrafica.Width / 2;
            int yc = ptbGrafica.Height / 2;

            // 4. Inicializar variables del algoritmo (según tu imagen izquierda)
            int x = 0;
            int y = r;
            int p = 1 - r;

            // 5. Graficar el primer punto y sus simétricos
            DibujarSimetria(xc, yc, x, y, bmp);

            // 6. Ciclo del Algoritmo de Punto Medio (while x < y)
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

                // Graficar los puntos en los 8 octantes para las nuevas coordenadas
                DibujarSimetria(xc, yc, x, y, bmp);
            }

            // 7. Asignar el bitmap final al PictureBox
            ptbGrafica.Image = bmp;
        }

        // Método auxiliar para graficar los 8 puntos de simetría (Imagen derecha)
        private void DibujarSimetria(int xc, int yc, int x, int y, Bitmap bmp)
        {
            Color colorPixel = Color.Black; // Puedes cambiar el color aquí

            // Usamos un try-catch o verificaciones para evitar errores si el radio es más grande que el PictureBox
            try
            {
                // Verifica límites antes de pintar para no dar error fuera de rango
                // Estas son las 8 líneas de código que aparecen en tu imagen de la derecha
                if (DentroDeLimites(xc + x, yc + y, bmp)) bmp.SetPixel(xc + x, yc + y, colorPixel);
                if (DentroDeLimites(xc - x, yc + y, bmp)) bmp.SetPixel(xc - x, yc + y, colorPixel);
                if (DentroDeLimites(xc + x, yc - y, bmp)) bmp.SetPixel(xc + x, yc - y, colorPixel);
                if (DentroDeLimites(xc - x, yc - y, bmp)) bmp.SetPixel(xc - x, yc - y, colorPixel);

                if (DentroDeLimites(xc + y, yc + x, bmp)) bmp.SetPixel(xc + y, yc + x, colorPixel);
                if (DentroDeLimites(xc - y, yc + x, bmp)) bmp.SetPixel(xc - y, yc + x, colorPixel);
                if (DentroDeLimites(xc + y, yc - x, bmp)) bmp.SetPixel(xc + y, yc - x, colorPixel);
                if (DentroDeLimites(xc - y, yc - x, bmp)) bmp.SetPixel(xc - y, yc - x, colorPixel);
            }
            catch (Exception)
            {
                // Ignorar errores de graficado fuera de bordes
            }
        }

        // Función segura para verificar que el pixel esté dentro del bitmap
        private bool DentroDeLimites(int x, int y, Bitmap bmp)
        {
            return x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height;
        }
    }
}