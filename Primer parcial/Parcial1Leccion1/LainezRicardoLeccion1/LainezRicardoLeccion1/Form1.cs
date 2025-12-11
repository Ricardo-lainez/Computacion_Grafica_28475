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
            ptbGrafica.Refresh();
            txtCantidadLinea.Clear();
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

                int W = ptbGrafica.Width;
                int H = ptbGrafica.Height;
                PointF O = new PointF(W / 2f, H / 2f); // Centro

       
                float stepX = (W / 2f) / N;
                float stepY = (H / 2f) / N;

                List<PointF> puntos_O_A = new List<PointF>(); // O -> A (Arriba)
                List<PointF> puntos_O_B = new List<PointF>(); // O -> B (Derecha)
                List<PointF> puntos_O_C = new List<PointF>(); // O -> C (Abajo)
                List<PointF> puntos_O_D = new List<PointF>(); // O -> D (Izquierda)

                for (int i = 0; i <= N; i++)
                {
                    // (O.X, O.Y - i * stepY) -> [0]=O, [N]=A
                    puntos_O_A.Add(new PointF(O.X, O.Y - i * stepY));

                    // (O.X + i * stepX, O.Y) -> [0]=O, [1]=O+h, [N]=B
                    puntos_O_B.Add(new PointF(O.X + i * stepX, O.Y));

                    // (O.X, O.Y + i * stepY) -> [0]=O, [N]=C
                    puntos_O_C.Add(new PointF(O.X, O.Y + i * stepY));

                    // (O.X - i * stepX, O.Y) -> [0]=O, [1]=O+h, [N]=D
                    puntos_O_D.Add(new PointF(O.X - i * stepX, O.Y));
                }

                for (int i = 0; i < N; i++)
                {
                    // Lógica del diagrama:
                    // A (puntos_O_A[N]) se conecta con O+h (puntos_O_B[1])
                    // A-h (puntos_O_A[N-1]) se conecta con O+h+h (puntos_O_B[2])
                    // asi sucesivamente
                    // P_Vertical[N-i] se conecta con P_Horizontal[i+1]

                    // Cuadrante 1 (Superior-Derecho): Eje A con Eje B
                    g.DrawLine(pen, puntos_O_A[N - i], puntos_O_B[i + 1]);

                    g.DrawLine(pen, puntos_O_A[N - i], puntos_O_D[i + 1]);

                    g.DrawLine(pen, puntos_O_C[N - i], puntos_O_D[i + 1]);

                    g.DrawLine(pen, puntos_O_C[N - i], puntos_O_B[i + 1]);
                }
            }
        }

    }
}