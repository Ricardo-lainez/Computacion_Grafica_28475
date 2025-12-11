using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class SutherlandHodgman : Form
    {
        private List<Point> vertices = new List<Point>();
        private Rectangle ventana = new Rectangle(200, 150, 300, 200);

        private RadioButton rbSutherland, rbAristas, rbBox;
        private Button btnReset;

        public SutherlandHodgman()
        {
            InitializeComponent();
            SetupUI();
            this.DoubleBuffered = true;
            this.MouseClick += (s, e) => {
                if (e.Button == MouseButtons.Right)
                {
                    ventana.Location = new Point(e.X - ventana.Width / 2, e.Y - ventana.Height / 2);
                }
                else
                {
                    vertices.Add(e.Location);
                }
                Invalidate();
            };
            this.Paint += OnPaint;
        }

        private void SetupUI()
        {
            Panel p = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.WhiteSmoke };
            rbSutherland = new RadioButton { Text = "Sutherland-Hodgman (Relleno)", Top = 15, Left = 10, Checked = true, AutoSize = true };
            rbAristas = new RadioButton { Text = "Solo Aristas (Wireframe)", Top = 15, Left = 200, AutoSize = true };
            rbBox = new RadioButton { Text = "Validación Bounding Box", Top = 15, Left = 380, AutoSize = true };
            btnReset = new Button { Text = "Nuevo Polígono", Top = 10, Left = 550 };
            btnReset.Click += (s, e) => { vertices.Clear(); Invalidate(); };

            p.Controls.Add(rbSutherland); p.Controls.Add(rbAristas);
            p.Controls.Add(rbBox); p.Controls.Add(btnReset);
            this.Controls.Add(p);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dibujar ventana
            g.DrawRectangle(new Pen(Color.Red, 2), ventana);

            if (vertices.Count < 2) return;

            // Dibujar original
            g.DrawPolygon(new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot }, vertices.ToArray());

            // Algoritmos
            if (rbSutherland.Checked) // Variante 1
            {
                List<Point> clipped = AlgoritmosRecorte.SutherlandHodgmanPoly(vertices, ventana);
                if (clipped.Count > 2)
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(100, 0, 0, 255)), clipped.ToArray());
                    g.DrawPolygon(new Pen(Color.Blue, 2), clipped.ToArray());
                }
            }
            else if (rbAristas.Checked) // Variante 2
            {
                List<Point[]> lines = AlgoritmosRecorte.RecortePorAristas(vertices, ventana);
                Pen p = new Pen(Color.Green, 2);
                foreach (var line in lines) g.DrawLine(p, line[0], line[1]);
            }
            else if (rbBox.Checked) // Variante 3
            {
                int status = AlgoritmosRecorte.CheckBoundingBox(vertices, ventana);
                string msg = status == 1 ? "ACEPTADO (Totalmente Dentro)" :
                             status == -1 ? "RECHAZADO (Totalmente Fuera)" : "PARCIAL (Requiere Recorte)";
                Color c = status == 1 ? Color.Green : status == -1 ? Color.Red : Color.Orange;

                g.DrawString(msg, new Font("Arial", 14, FontStyle.Bold), new SolidBrush(c), 10, 60);

                // Si es parcial, dibujamos el recorte para que no se vea vacío
                if (status == 0)
                {
                    List<Point> clipped = AlgoritmosRecorte.SutherlandHodgmanPoly(vertices, ventana);
                    if (clipped.Count > 2) g.DrawPolygon(Pens.Orange, clipped.ToArray());
                }
            }
        }
    }
}