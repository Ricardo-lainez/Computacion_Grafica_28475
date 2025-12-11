using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Importante para SmoothingMode y DashStyle
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1_Lainez_Ricardo
{
    public partial class frmConjuntaGraficaU1 : Form
    {
        //CONSTANTES DE LA SIMULACIÓN
        private const float GRAVEDAD = 9.81f;
        private const float PASO_TIEMPO = 0.2f;
        private const int ALTURA_SUELO = 50;


        //ESTADO DE LA SIMULACIÓN
        private Timer temporizadorAnimacion = new Timer();
        private PointF posicionBase;
        private PointF posicionObjetivo;
        private PointF posicionMisil;
        private List<PointF> rutaTrayectoria = new List<PointF>();

        // PARÁMETROS DE LANZAMIENTO
        private float velocidadInicial = 0f;
        private float anguloLanzamientoDeg = 0f;
        private float tiempoSimulacion = 0f;
        private bool estaSimulando = false;
        private bool arrastrandoObjetivo = false;


        public frmConjuntaGraficaU1()
        {
            InitializeComponent();
            InicializarSimulacion();
        }

        private void InicializarSimulacion()
        {
            // Habilita Double Buffering en el PictureBox para evitar parpadeos
            this.ptbGrafica.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(this.ptbGrafica, true, null);

            //configuracion del suelo
            float sueloY = this.ptbGrafica.ClientSize.Height - ALTURA_SUELO;
            posicionBase = new PointF(50, sueloY);
            posicionObjetivo = new PointF(this.ptbGrafica.ClientSize.Width - 100, sueloY);
            posicionMisil = posicionBase;

            // Configurar el temporizador de animación
            temporizadorAnimacion.Interval = 20;
            temporizadorAnimacion.Tick += TemporizadorAnimacion_Tick;

            // Conectar los eventos del PictureBox
            this.ptbGrafica.Paint += PtbGrafica_Paint;
            this.ptbGrafica.MouseDown += PtbGrafica_MouseDown;
            this.ptbGrafica.MouseUp += PtbGrafica_MouseUp;
            this.ptbGrafica.MouseMove += PtbGrafica_MouseMove;

            // Re-calcular posiciones si el formulario (y el PictureBox) cambia de tamaño
            this.ptbGrafica.Resize += (s, e) => ResetearPosiciones();

            btnResetear.Enabled = false;
        }

        private void ResetearPosiciones()
        {
            if (estaSimulando) return;

            float sueloY = this.ptbGrafica.ClientSize.Height - ALTURA_SUELO;
            posicionBase = new PointF(50, sueloY);

            // Mantiene la X del objetivo, pero ajusta su Y al nuevo suelo
            posicionObjetivo = new PointF(posicionObjetivo.X, sueloY);

            // Asegurarse de que el objetivo no se salga de la pantalla
            if (posicionObjetivo.X > ptbGrafica.ClientSize.Width - 50)
            {
                posicionObjetivo.X = ptbGrafica.ClientSize.Width - 100;
            }

            posicionMisil = posicionBase;
            ptbGrafica.Invalidate();
        }


        // BUCLE PRINCIPAL DE LA SIMULACIÓN
        private void TemporizadorAnimacion_Tick(object sender, EventArgs e)
        {
            // 1. Avanzar el tiempo de la simulación
            tiempoSimulacion += PASO_TIEMPO;
            //2. angulo a radianes
            double anguloRad = (Math.PI / 180.0) * anguloLanzamientoDeg;

            float vX = (float)(velocidadInicial * Math.Cos(anguloRad));
            float vY = (float)(velocidadInicial * Math.Sin(anguloRad));

            // x(t) = V_x * t
            float physicsX = vX * tiempoSimulacion;
            // y(t) = V_y * t - (1/2) * g * t^2
            float physicsY = (vY * tiempoSimulacion) - (0.5f * GRAVEDAD * tiempoSimulacion * tiempoSimulacion);

            // 3. Mapear la posición física a las coordenadas GDI+
            // GDI+ X: Aumenta hacia la derecha
            posicionMisil.X = posicionBase.X + physicsX;
            // GDI+ Y: Aumenta hacia abajo
            posicionMisil.Y = posicionBase.Y - physicsY;

            // 4. Añadir a la trayectoria
            rutaTrayectoria.Add(posicionMisil);

            // 5. Comprobar colisiones
            RectangleF misilBounds = GetMisilBounds(posicionMisil);
            RectangleF objetivoBounds = GetObjetivoBounds();
            float sueloY = this.ptbGrafica.ClientSize.Height - ALTURA_SUELO;

            if (misilBounds.IntersectsWith(objetivoBounds))
            {

                DetenerSimulacion("¡IMPACTO! Objetivo destruido.");
            }
            else if (posicionMisil.Y > sueloY)
            {
                DetenerSimulacion("FALLO. El misil impactó el suelo.");
            }

            // 6. Forzar al PictureBox a redibujarse
            ptbGrafica.Invalidate();
        }


        // MANEJO DE EVENTOS DE CONTROLES
        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (estaSimulando) return;

            // 1. Validar entradas
            if (!float.TryParse(txtAngulo.Text, out anguloLanzamientoDeg) ||
                !float.TryParse(txtVelocidad.Text, out velocidadInicial))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para ángulo y velocidad.",
                    "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (anguloLanzamientoDeg <= 0 || anguloLanzamientoDeg >= 90 || velocidadInicial <= 0)
            {
                MessageBox.Show("El ángulo debe estar entre 0 y 90 grados.\nLa velocidad debe ser mayor a 0.",
                    "Valores Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Iniciar simulaciom
            tiempoSimulacion = 0f;
            posicionMisil = posicionBase;
            rutaTrayectoria.Clear();
            rutaTrayectoria.Add(posicionMisil);

            estaSimulando = true;
            btnSimular.Enabled = false;
            btnResetear.Enabled = true;

            temporizadorAnimacion.Start();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            DetenerSimulacion(null); 
            txtAngulo.Text = "";
            txtVelocidad.Text = "";
            rutaTrayectoria.Clear();
            posicionMisil = posicionBase;
            ptbGrafica.Invalidate();
        }

        private void DetenerSimulacion(string mensaje)
        {
            temporizadorAnimacion.Stop();
            estaSimulando = false;
            btnSimular.Enabled = true;
            btnResetear.Enabled = false;

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Simulación Terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //MANEJO DE EVENTOS DEL MOUS

        private void PtbGrafica_MouseDown(object sender, MouseEventArgs e)
        {
            if (estaSimulando) return;

            if (GetObjetivoBounds().Contains(e.Location))
            {
                arrastrandoObjetivo = true;
            }
        }

        private void PtbGrafica_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrandoObjetivo = false;
        }

        private void PtbGrafica_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrandoObjetivo)
            {
                float sueloY = this.ptbGrafica.ClientSize.Height - ALTURA_SUELO;

                // Mover la posición X del objetivo, pero mantener la Y fija en el suelo
                // Limitar el movimiento para que no se salga de la pantalla
                posicionObjetivo.X = Math.Max(100, Math.Min(e.X, ptbGrafica.ClientSize.Width - 50));
                posicionObjetivo.Y = sueloY;

                ptbGrafica.Invalidate();
            }
        }


        // MÉTODOS DE DIBUJO (GDI+)
        private void PtbGrafica_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Color.DarkOrange);

            DibujarSuelo(g);
            DibujarBase(g);
            DibujarObjetivo(g);
            DibujarTrayectoria(g);
            if (estaSimulando)
            {
                DibujarMisil(g, posicionMisil);
            }
        }

        private void DibujarSuelo(Graphics g)
        {
            float sueloY = this.ptbGrafica.ClientSize.Height - ALTURA_SUELO;
            using (Brush sueloBrush = new SolidBrush(Color.FromArgb(87, 68, 50)))
            {
                g.FillRectangle(sueloBrush, 0, sueloY, this.ptbGrafica.ClientSize.Width, ALTURA_SUELO);
            }
        }

        private void DibujarBase(Graphics g)
        {
            // Un simple búnker gris
            RectangleF baseRect = new RectangleF(posicionBase.X - 20, posicionBase.Y - 30, 40, 30);
            using (Brush baseBrush = new SolidBrush(Color.DimGray))
            {
                g.FillRectangle(baseBrush, baseRect);
            }
            // Cañón (un rectángulo)
            g.FillRectangle(Brushes.Gray, posicionBase.X - 3, posicionBase.Y - 45, 6, 15);
        }

        private void DibujarObjetivo(Graphics g)
        {
            // Un simple edifici rojo
            RectangleF objetivoRect = GetObjetivoBounds();
            using (Brush objetivoBrush = new SolidBrush(Color.DarkRed))
            {
                g.FillRectangle(objetivoBrush, objetivoRect);
                // Torreta
                g.FillRectangle(Brushes.Firebrick, objetivoRect.X + 10, objetivoRect.Y - 10, 20, 10);
            }
        }

        private void DibujarMisil(Graphics g, PointF loc)
        {
            // Un crculo negro simple para el misil
            RectangleF misilRect = GetMisilBounds(loc);
            // "Fuego" del motor (un triángulo amarillo)
            PointF[] fuego = {
                new PointF(loc.X, loc.Y + 10),
                new PointF(loc.X - 4, loc.Y + 4),
                new PointF(loc.X + 4, loc.Y + 4)
            };
            g.FillPolygon(Brushes.OrangeRed, fuego);
            g.FillEllipse(Brushes.Black, misilRect);
        }

        private void DibujarTrayectoria(Graphics g)
        {
            if (rutaTrayectoria.Count > 1)
            {
                // Usamos un lápiz amarillo pálido punteado
                using (Pen trailPen = new Pen(Color.FromArgb(220, 200, 100), 2))
                {
                    trailPen.DashStyle = DashStyle.Dot;
                    g.DrawLines(trailPen, rutaTrayectoria.ToArray());
                }
            }
        }


        // MÉTODOS DE COLISIÓN
        private RectangleF GetObjetivoBounds()
        {
            return new RectangleF(posicionObjetivo.X - 20, posicionObjetivo.Y - 30, 40, 30);
        }

        private RectangleF GetMisilBounds(PointF loc)
        {
            // Círculo de 10x10 centrado en 'loc'
            return new RectangleF(loc.X - 5, loc.Y - 5, 10, 10);
        }
    }
}