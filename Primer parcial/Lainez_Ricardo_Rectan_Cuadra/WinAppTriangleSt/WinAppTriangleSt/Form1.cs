using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Necesario para SmoothingMode
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LainezRicardoLeccion1
{
    public partial class frmLeccion1 : Form
    {
        public frmLeccion1()
        {
            InitializeComponent();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            ptbGrafica.Refresh(); // Limpia el PictureBox
            txtCantidadLinea.Clear(); // Limpia el TextBox
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            // 1. Validar la entrada del usuario
            if (!int.TryParse(txtCantidadLinea.Text, out int N) || N <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número de líneas válido (mayor a 0).");
                return;
            }

            // 2. Preparar el lienzo (PictureBox)
            ptbGrafica.Refresh();

            using (Graphics g = ptbGrafica.CreateGraphics())
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // 3. Definir las dimensiones y los puntos clave
                int W = ptbGrafica.Width;
                int H = ptbGrafica.Height;

                // Puntos cardinales en el medio de los lados
                PointF A = new PointF(W / 2f, 0);     // Arriba (Top-Middle)
                PointF B = new PointF(W, H / 2f);     // Derecha (Right-Middle)
                PointF C = new PointF(W / 2f, H);     // Abajo (Bottom-Middle)
                PointF D = new PointF(0, H / 2f);     // Izquierda (Left-Middle)
                PointF O = new PointF(W / 2f, H / 2f); // Centro

                // Calculamos el tamaño de cada "paso" o "h" en cada cuadrante
                // para que los puntos se distribuyan uniformemente.
                // Es la longitud del lado de un "cuadrante" dividida por el número de líneas N
                float stepX = (W / 2f) / N; // De O a B o de O a D
                float stepY = (H / 2f) / N; // De O a A o de O a C

                // Dibujar líneas para el primer "cuadrante" (A-O-B)
                // Conectando el lado A-O con el lado O-B
                for (int i = 0; i <= N; i++)
                {
                    // Primer cuadrante: Superior Derecho (desde A hacia O, y desde O hacia B)
                    // Puntos en el segmento A-O: y-coordenada va de 0 a H/2
                    PointF p1 = new PointF(A.X, A.Y + i * stepY);
                    // Puntos en el segmento O-B: x-coordenada va de W/2 a W
                    PointF p2 = new PointF(O.X + (N - i) * stepX, B.Y);
                    g.DrawLine(pen, p1, p2);

                    // Segundo cuadrante: Inferior Derecho (desde B hacia O, y desde O hacia C)
                    // Puntos en el segmento B-O: x-coordenada va de W a W/2
                    PointF p3 = new PointF(B.X - i * stepX, B.Y);
                    // Puntos en el segmento O-C: y-coordenada va de H/2 a H
                    PointF p4 = new PointF(O.X, O.Y + (N - i) * stepY);
                    g.DrawLine(pen, p3, p4);

                    // Tercer cuadrante: Inferior Izquierdo (desde C hacia O, y desde O hacia D)
                    // Puntos en el segmento C-O: y-coordenada va de H a H/2
                    PointF p5 = new PointF(C.X, C.Y - i * stepY);
                    // Puntos en el segmento O-D: x-coordenada va de W/2 a 0
                    PointF p6 = new PointF(O.X - (N - i) * stepX, D.Y);
                    g.DrawLine(pen, p5, p6);

                    // Cuarto cuadrante: Superior Izquierdo (desde D hacia O, y desde O hacia A)
                    // Puntos en el segmento D-O: x-coordenada va de 0 a W/2
                    PointF p7 = new PointF(D.X + i * stepX, D.Y);
                    // Puntos en el segmento O-A: y-coordenada va de H/2 a 0
                    PointF p8 = new PointF(O.X, O.Y - (N - i) * stepY);
                    g.DrawLine(pen, p7, p8);
                }
            }
        }

        // La función Interpolar ya no es necesaria con esta nueva lógica
        // y se puede eliminar si no se usa en otras partes del código.
        // private PointF Interpolar(PointF p1, PointF p2, float t)
        // {
        //     float x = p1.X + (p2.X - p1.X) * t;
        //     float y = p1.Y + (p2.Y - p1.Y) * t;
        //     return new PointF(x, y);
        // }
    }
}