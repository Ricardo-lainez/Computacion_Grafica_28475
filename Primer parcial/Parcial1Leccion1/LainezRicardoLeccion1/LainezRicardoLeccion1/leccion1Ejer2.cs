using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // ¡Importante! Añadido para el SmoothingMode
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LainezRicardoLeccion1
{
    public partial class frmEjercicio2 : Form
    {
        public frmEjercicio2()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
 
            if (!int.TryParse(txtCantidadLinea.Text, out int N) || N <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número de líneas válido (mayor a 0).");
                return;
            }

          
            ptbGrafica.Refresh();

            using (Graphics g = ptbGrafica.CreateGraphics())
            using (Pen penGreen = new Pen(Color.Green, 1))
            using (Pen penRed = new Pen(Color.Red, 1))
            using (Pen penBlue = new Pen(Color.Blue, 1))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int W = ptbGrafica.Width - 1; // -1 para que no se dibuje fuera de borde
                int H = ptbGrafica.Height - 1;

                PointF A = new PointF(0, 0);     // Superior Izquierda
                PointF B = new PointF(W, 0);     // Superior Derecha
                PointF C = new PointF(W, H);     // Inferior Derecha
                PointF D = new PointF(0, H);     // Inferior Izquierda

                float stepX = (float)W / N;
                float stepY = (float)H / N;

              
                List<PointF> Puntos_BA = new List<PointF>(); // Lado Superior (B -> A)
                List<PointF> Puntos_AD = new List<PointF>(); // Lado Izquierdo (A -> D)
                List<PointF> Puntos_DC = new List<PointF>(); // Lado Inferior (D -> C)
                List<PointF> Puntos_CB = new List<PointF>(); // Lado Derecho (C -> B)

                for (int i = 0; i <= N; i++)
                {
                    
                    Puntos_BA.Add(new PointF(B.X - i * stepX, B.Y));

                    
                    Puntos_AD.Add(new PointF(A.X, A.Y + i * stepY));

                   
                    Puntos_DC.Add(new PointF(D.X + i * stepX, D.Y));

                    Puntos_CB.Add(new PointF(C.X, C.Y - i * stepY));
                }

                // Bucle de 0 a N-1
                for (int i = 0; i < N; i++)
                {
                    
                    g.DrawLine(penGreen, Puntos_BA[N - i], Puntos_AD[i + 1]);

                  
                    g.DrawLine(penRed, Puntos_AD[N - i], Puntos_DC[i + 1]);

          
                    g.DrawLine(penGreen, Puntos_DC[N - i], Puntos_CB[i + 1]);

                    
                    g.DrawLine(penBlue, Puntos_CB[N - i], Puntos_BA[i + 1]);
                }
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Asumo los nombres de los controles
            ptbGrafica.Refresh();
            txtCantidadLinea.Clear();
        }
    }
}