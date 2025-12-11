using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class CohenSutherland : Form
    {
        private Point pStart, pEnd;
        private bool drawing = false;
        private Rectangle ventanaRecorte = new Rectangle(150, 100, 300, 200);

        // Controles UI
        private RadioButton rbCohen, rbLiang, rbMid;
        private Button btnClean;
        private Label lblInstrucciones;

        public CohenSutherland()
        {
            InitializeComponent();
            ConfigurarInterfaz();
            this.DoubleBuffered = true; // Evita parpadeo
            this.MouseClick += AlHacerClickMouse;
            this.Paint += AlPintar;
            this.MouseMove += AlMoverMouse; // Opcional: para mover la ventana
        }

        private void ConfigurarInterfaz()
        {
            // Panel superior para opciones
            Panel panelOpciones = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.LightGray };

            rbCohen = new RadioButton { Text = "Cohen-Sutherland", Location = new Point(10, 15), Checked = true, AutoSize = true };
            rbLiang = new RadioButton { Text = "Liang-Barsky", Location = new Point(150, 15), AutoSize = true };
            rbMid = new RadioButton { Text = "Punto Medio", Location = new Point(270, 15), AutoSize = true };

            btnClean = new Button { Text = "Limpiar", Location = new Point(400, 10), Height = 30 };
            btnClean.Click += (s, e) => { pStart = Point.Empty; pEnd = Point.Empty; Invalidate(); };

            lblInstrucciones = new Label { Text = "Click Izq: Puntos Línea | Click Der: Mover Ventana", Location = new Point(500, 18), AutoSize = true };

            panelOpciones.Controls.Add(rbCohen);
            panelOpciones.Controls.Add(rbLiang);
            panelOpciones.Controls.Add(rbMid);
            panelOpciones.Controls.Add(btnClean);
            panelOpciones.Controls.Add(lblInstrucciones);

            this.Controls.Add(panelOpciones);
        }

        private void AlHacerClickMouse(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Mover ventana al click
                ventanaRecorte.Location = new Point(e.X - ventanaRecorte.Width / 2, e.Y - ventanaRecorte.Height / 2);
            }
            else
            {
                if (!drawing)
                {
                    pStart = e.Location;
                    pEnd = e.Location; // Temporal para ver el punto
                    drawing = true;
                }
                else
                {
                    pEnd = e.Location;
                    drawing = false;
                }
            }
            Invalidate();
        }

        private void AlMoverMouse(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                pEnd = e.Location;
                Invalidate();
            }
        }

        private void AlPintar(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 1. Dibujar Ventana de Recorte
            g.DrawRectangle(new Pen(Color.Red, 2), ventanaRecorte);

            // 2. Si no hay línea válida, salir
            if (pStart == Point.Empty) return;

            // 3. Dibujar línea original (gris tenue) para comparar
            using (Pen penGris = new Pen(Color.LightGray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                g.DrawLine(penGris, pStart, pEnd);
            }

            // 4. Calcular Recorte según algoritmo seleccionado
            Point p1 = pStart;
            Point p2 = pEnd;
            bool visible = false;

            if (rbCohen.Checked)
                visible = AlgoritmosRecorte.CohenSutherland(ref p1, ref p2, ventanaRecorte);
            else if (rbLiang.Checked)
                visible = AlgoritmosRecorte.LiangBarsky(ref p1, ref p2, ventanaRecorte);
            else if (rbMid.Checked)
                visible = AlgoritmosRecorte.PuntoMedio(ref p1, ref p2, ventanaRecorte);

            // 5. Dibujar resultado
            if (visible)
            {
                using (Pen penResult = new Pen(Color.Blue, 3))
                {
                    g.DrawLine(penResult, p1, p2);
                }
            }
        }
    }
}