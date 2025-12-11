using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppAlgoritmos
{
    public partial class AlgoritmoRecorteSH : Form
    {
        // --- CONFIGURACIÓN ---
        private const int PIXEL_SIZE = 10; // Tamaño de cada cuadrito
        // ---------------------

        private Bitmap bmp;
        private Graphics g;

        // Listas de puntos lógicos (coordenadas de la cuadrícula)
        private List<Point> listaPoligono = new List<Point>();
        private List<Point> listaVentana = new List<Point>();

        private enum Modo { Ninguno, DibujandoPoligono, DibujandoVentana }
        private Modo modoActual = Modo.Ninguno;

        public AlgoritmoRecorteSH()
        {
            InitializeComponent();
            // ESTO ES CLAVE: Asegura que el lienzo se inicie apenas se muestra la ventana
            this.Shown += (s, e) => InicializarCanvas();
        }

        // --- GESTIÓN DEL LIENZO (CANVAS) ---
        private void InicializarCanvas()
        {
            // Protección: Si el canvas no mide nada, no intentamos crear el gráfico
            if (canvas.Width <= 0 || canvas.Height <= 0) return;

            // Creamos un nuevo Bitmap del tamaño del PictureBox
            bmp = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bmp);

            // Limpiamos y dibujamos la grilla
            g.Clear(Color.White);
            DibujarGrid();

            // Asignamos la imagen al control para que se vea
            canvas.Image = bmp;
        }

        private void VerificarGraficos()
        {
            // Si por alguna razón g es nulo, lo intentamos crear de nuevo
            if (g == null) InicializarCanvas();
        }

        private void DibujarGrid()
        {
            if (g == null) return;
            using (Pen pen = new Pen(Color.LightGray))
            {
                for (int x = 0; x <= canvas.Width; x += PIXEL_SIZE)
                    g.DrawLine(pen, x, 0, x, canvas.Height);
                for (int y = 0; y <= canvas.Height; y += PIXEL_SIZE)
                    g.DrawLine(pen, 0, y, canvas.Width, y);
            }
        }

        // --- BOTONES ---

        private void btnPoligono_Click(object sender, EventArgs e)
        {
            VerificarGraficos(); // Asegura que el lienzo exista
            modoActual = Modo.DibujandoPoligono;
            lblEstado.Text = "Modo: Dibuja el Polígono (clic en la grilla)";
        }

        private void btnVentana_Click(object sender, EventArgs e)
        {
            VerificarGraficos();
            modoActual = Modo.DibujandoVentana;
            listaVentana.Clear();
            RedibujarTodo(); // Limpia marcas anteriores de ventana
            lblEstado.Text = "Modo: Define Ventana (2 clics: esq. sup. y esq. inf.)";
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (listaPoligono.Count < 3)
            {
                MessageBox.Show("¡Dibuja primero un polígono!");
                return;
            }
            if (listaVentana.Count < 2)
            {
                MessageBox.Show("¡Define primero la ventana de recorte!");
                return;
            }

            // Calcular los límites de la ventana
            int xMin = Math.Min(listaVentana[0].X, listaVentana[1].X);
            int xMax = Math.Max(listaVentana[0].X, listaVentana[1].X);
            int yMin = Math.Min(listaVentana[0].Y, listaVentana[1].Y);
            int yMax = Math.Max(listaVentana[0].Y, listaVentana[1].Y);

            Rectangle rectVentana = new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);

            // Aplicar el algoritmo
            List<Point> resultado = SutherlandHodgman(listaPoligono, rectVentana);

            // Mostrar el resultado
            listaPoligono = resultado;
            RedibujarTodo();
            lblEstado.Text = "Recorte aplicado.";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listaPoligono.Clear();
            listaVentana.Clear();
            modoActual = Modo.Ninguno;
            InicializarCanvas(); // Reinicia el lienzo totalmente
            lblEstado.Text = "Lienzo limpio.";
        }

        // --- MOUSE Y DIBUJO ---

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            VerificarGraficos(); // PROTECCIÓN ANTI-CRASH
            if (g == null) return; // Si sigue siendo nulo, salimos

            // Convertir clic de pantalla a coordenada de grilla
            int gx = e.X / PIXEL_SIZE;
            int gy = e.Y / PIXEL_SIZE;
            Point pLogico = new Point(gx, gy);

            if (modoActual == Modo.DibujandoPoligono)
            {
                listaPoligono.Add(pLogico);
                // Dibujar el punto inmediatamente
                PintarPixel(gx, gy, Color.Blue);

                // Si hay un punto anterior, conectar con línea
                if (listaPoligono.Count > 1)
                {
                    Point anterior = listaPoligono[listaPoligono.Count - 2];
                    DibujarLineaBresenham(anterior.X, anterior.Y, gx, gy, Color.Blue);
                }
                canvas.Refresh();
            }
            else if (modoActual == Modo.DibujandoVentana)
            {
                if (listaVentana.Count < 2)
                {
                    listaVentana.Add(pLogico);
                    PintarPixel(gx, gy, Color.Red);

                    if (listaVentana.Count == 2)
                    {
                        DibujarRectanguloVentana();
                    }
                    canvas.Refresh();
                }
            }
        }

        // --- ALGORITMO SUTHERLAND-HODGMAN ---

        private List<Point> SutherlandHodgman(List<Point> entrada, Rectangle clip)
        {
            List<Point> salida = new List<Point>(entrada);

            // 1. Izquierda
            salida = RecortarLado(salida, clip.X, 0, (p, val) => p.X >= val);
            // 2. Derecha (clip.Right)
            salida = RecortarLado(salida, clip.Right, 0, (p, val) => p.X <= val);
            // 3. Arriba
            salida = RecortarLado(salida, clip.Y, 1, (p, val) => p.Y >= val);
            // 4. Abajo (clip.Bottom)
            salida = RecortarLado(salida, clip.Bottom, 1, (p, val) => p.Y <= val);

            return salida;
        }

        private List<Point> RecortarLado(List<Point> entrada, int valorBorde, int eje, Func<Point, int, bool> estaDentro)
        {
            List<Point> nuevaLista = new List<Point>();
            if (entrada.Count == 0) return nuevaLista;

            Point S = entrada[entrada.Count - 1]; // Último punto (para cerrar el ciclo)

            foreach (Point P in entrada)
            {
                bool pDentro = estaDentro(P, valorBorde);
                bool sDentro = estaDentro(S, valorBorde);

                if (pDentro)
                {
                    if (!sDentro) nuevaLista.Add(CalcularInterseccion(S, P, valorBorde, eje));
                    nuevaLista.Add(P);
                }
                else if (sDentro)
                {
                    nuevaLista.Add(CalcularInterseccion(S, P, valorBorde, eje));
                }
                S = P;
            }
            return nuevaLista;
        }

        private Point CalcularInterseccion(Point p1, Point p2, int valorBorde, int eje)
        {
            int x = 0, y = 0;
            float m = 0;

            if (p2.X != p1.X) m = (float)(p2.Y - p1.Y) / (p2.X - p1.X);

            if (eje == 0) // Vertical (X constante)
            {
                x = valorBorde;
                y = (int)(p1.Y + m * (valorBorde - p1.X));
            }
            else // Horizontal (Y constante)
            {
                y = valorBorde;
                x = (m != 0) ? (int)(p1.X + (valorBorde - p1.Y) / m) : p1.X;
            }
            return new Point(x, y);
        }

        // --- GRAFICACIÓN VISUAL ---

        private void RedibujarTodo()
        {
            VerificarGraficos(); // PROTECCIÓN: Asegura que g no sea null
            if (g == null) return;

            g.Clear(Color.White);
            DibujarGrid();

            // Dibujar Ventana Roja
            if (listaVentana.Count == 2) DibujarRectanguloVentana();

            // Dibujar Polígono Azul
            if (listaPoligono.Count > 0)
            {
                for (int i = 0; i < listaPoligono.Count - 1; i++)
                    DibujarLineaBresenham(listaPoligono[i].X, listaPoligono[i].Y,
                                          listaPoligono[i + 1].X, listaPoligono[i + 1].Y, Color.Blue);

                // Cerrar polígono
                if (listaPoligono.Count > 2)
                {
                    Point ini = listaPoligono[0];
                    Point fin = listaPoligono[listaPoligono.Count - 1];
                    DibujarLineaBresenham(fin.X, fin.Y, ini.X, ini.Y, Color.Blue);
                }
            }
            canvas.Refresh();
        }

        private void DibujarRectanguloVentana()
        {
            int x1 = listaVentana[0].X; int y1 = listaVentana[0].Y;
            int x2 = listaVentana[1].X; int y2 = listaVentana[1].Y;

            int minX = Math.Min(x1, x2); int maxX = Math.Max(x1, x2);
            int minY = Math.Min(y1, y2); int maxY = Math.Max(y1, y2);

            // Dibuja el rectángulo con líneas de pixeles rojos
            DibujarLineaBresenham(minX, minY, maxX, minY, Color.Red);
            DibujarLineaBresenham(minX, maxY, maxX, maxY, Color.Red);
            DibujarLineaBresenham(minX, minY, minX, maxY, Color.Red);
            DibujarLineaBresenham(maxX, minY, maxX, maxY, Color.Red);
        }

        private void DibujarLineaBresenham(int x0, int y0, int x1, int y1, Color color)
        {
            int dx = Math.Abs(x1 - x0); int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1; int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                PintarPixel(x0, y0, color);
                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x0 += sx; }
                if (e2 < dx) { err += dx; y0 += sy; }
            }
        }

        private void PintarPixel(int x, int y, Color color)
        {
            if (g == null) return;
            if (x < 0 || y < 0) return;
            if (x * PIXEL_SIZE >= bmp.Width || y * PIXEL_SIZE >= bmp.Height) return;

            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x * PIXEL_SIZE + 1, y * PIXEL_SIZE + 1, PIXEL_SIZE - 1, PIXEL_SIZE - 1);
            }
        }
    }
}