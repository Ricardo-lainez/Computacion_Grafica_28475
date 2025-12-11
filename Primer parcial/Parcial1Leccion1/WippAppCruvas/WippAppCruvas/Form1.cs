using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppCurvas
{
    public partial class Form1 : Form
    {
        private List<PointF> puntosControl = new List<PointF>();
        private int arrastrandoIndice = -1; // -1 significa que no se arrastra nada
        private const int RADIO_PUNTO = 5;

        // Variables de Animación
        private float tAnimacion = 0f;
        private bool animando = false;
        private bool animacionIda = true; // true = 0 a 1, false = 1 a 0

        public Form1()
        {
            InitializeComponent();
            // Optimización para evitar parpadeo
            this.DoubleBuffered = true;
        }

        // --- Lógica de Interacción Mouse ---

        private void ptbLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            if (animando) return; // Bloquear edición durante animación

            // 1. Verificar si clicamos sobre un punto existente para arrastrar
            for (int i = 0; i < puntosControl.Count; i++)
            {
                if (Distancia(e.Location, puntosControl[i]) < RADIO_PUNTO * 2)
                {
                    arrastrandoIndice = i;
                    return;
                }
            }

            // 2. Si no arrastramos, verificamos si podemos agregar nuevos puntos
            if (PermiteAgregarPuntos())
            {
                puntosControl.Add(e.Location);
                ActualizarInfo();
                ptbLienzo.Invalidate(); // Forzar redibujado
            }
        }

        private void ptbLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrandoIndice != -1)
            {
                // Mover el punto seleccionado
                puntosControl[arrastrandoIndice] = e.Location;
                ptbLienzo.Invalidate();
            }
        }

        private void ptbLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrandoIndice = -1;
        }

        // --- Lógica de Dibujado (Paint) ---

        private void ptbLienzo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            // Dibujar rejilla suave de fondo
            DibujarRejilla(e.Graphics);

            if (puntosControl.Count == 0) return;

            // 1. Dibujar Polígono de Control (Líneas grises que unen puntos)
            if (puntosControl.Count > 1)
            {
                e.Graphics.DrawLines(Pens.LightGray, PointFArrayToPointArray(puntosControl.ToArray()));
            }

            // 2. Dibujar la Curva completa (estática)
            if (DebeDibujarCurva())
            {
                if (rbBSpline.Checked)
                    DibujarBSpline(e.Graphics);
                else
                    DibujarBezier(e.Graphics);
            }

            // 3. Dibujar Animación (Punto viajero y líneas de construcción)
            if (animando || chkVerConstruccion.Checked)
            {
                if (animando || (!animando && puntosControl.Count > 1)) // Mostrar estático si pausado
                {
                    float t = animando ? tAnimacion : 0.5f; // Si no anima, mostrar mitad para demo, o nada
                    if (animando) DibujarAnimacionDeCasteljau(e.Graphics, t);
                }
            }

            // 4. Dibujar Puntos de Control (Círculos Rojos)
            for (int i = 0; i < puntosControl.Count; i++)
            {
                RectangleF rect = new RectangleF(
                    puntosControl[i].X - RADIO_PUNTO,
                    puntosControl[i].Y - RADIO_PUNTO,
                    RADIO_PUNTO * 2, RADIO_PUNTO * 2);

                e.Graphics.FillEllipse(Brushes.Red, rect);
                e.Graphics.DrawEllipse(Pens.DarkRed, rect);
                e.Graphics.DrawString($"P{i}", SystemFonts.CaptionFont, Brushes.Black, puntosControl[i].X + 5, puntosControl[i].Y - 10);
            }
        }

        private void DibujarBezier(Graphics g)
        {
            if (puntosControl.Count < 2) return;

            List<PointF> curva = new List<PointF>();
            int pasos = 100; // Resolución de la curva

            for (int i = 0; i <= pasos; i++)
            {
                float t = i / (float)pasos;
                // Obtenemos el punto final de la recursión (última lista, índice 0)
                List<List<PointF>> resultado = CurvasMath.DeCasteljau(puntosControl, t);
                if (resultado.Count > 0)
                    curva.Add(resultado[resultado.Count - 1][0]);
            }

            if (curva.Count > 1)
            {
                using (Pen penCurva = new Pen(Color.Blue, 2))
                {
                    g.DrawLines(penCurva, PointFArrayToPointArray(curva.ToArray()));
                }
            }
        }

        private void DibujarBSpline(Graphics g)
        {
            if (puntosControl.Count < 4) return;

            using (Pen penSpline = new Pen(Color.Green, 2))
            {
                // B-Spline Uniforme Cúbica necesita grupos de 4 puntos
                // Se dibuja por segmentos entre P1 y P2, P2 y P3, etc.
                for (int i = 0; i <= puntosControl.Count - 4; i++)
                {
                    List<PointF> segmento = new List<PointF>();
                    for (float t = 0; t <= 1; t += 0.05f)
                    {
                        segmento.Add(CurvasMath.CalcularBSpline(
                            puntosControl[i],
                            puntosControl[i + 1],
                            puntosControl[i + 2],
                            puntosControl[i + 3], t));
                    }
                    if (segmento.Count > 1)
                        g.DrawLines(penSpline, PointFArrayToPointArray(segmento.ToArray()));
                }
            }
        }

        private void DibujarAnimacionDeCasteljau(Graphics g, float t)
        {
            if (rbBSpline.Checked) return; // De Casteljau es específico de Bézier
            if (puntosControl.Count < 2) return;

            // Obtener todos los puntos intermedios
            List<List<PointF>> niveles = CurvasMath.DeCasteljau(puntosControl, t);

            // Dibujar las líneas de construcción (verde claro a oscuro)
            if (chkVerConstruccion.Checked)
            {
                for (int i = 1; i < niveles.Count - 1; i++) // Ignoramos el nivel 0 (puntos control) y último (punto final)
                {
                    List<PointF> nivel = niveles[i];
                    using (Pen pConstruccion = new Pen(Color.FromArgb(100, 0, 255, 0), 1))
                    {
                        g.DrawLines(pConstruccion, PointFArrayToPointArray(nivel.ToArray()));
                    }
                    // Dibujar puntitos en las uniones
                    foreach (var p in nivel)
                        g.FillEllipse(Brushes.Green, p.X - 2, p.Y - 2, 4, 4);
                }
            }

            // Dibujar el punto final viajando sobre la curva
            PointF puntoFinal = niveles[niveles.Count - 1][0];
            g.FillEllipse(Brushes.Black, puntoFinal.X - 4, puntoFinal.Y - 4, 8, 8);
        }

        private void DibujarRejilla(Graphics g)
        {
            using (Pen p = new Pen(Color.FromArgb(240, 240, 240)))
            {
                for (int x = 0; x < ptbLienzo.Width; x += 20) g.DrawLine(p, x, 0, x, ptbLienzo.Height);
                for (int y = 0; y < ptbLienzo.Height; y += 20) g.DrawLine(p, 0, y, ptbLienzo.Width, y);
            }
        }

        // --- Utilidades y Helpers ---

        private bool PermiteAgregarPuntos()
        {
            if (rbBezierLineal.Checked && puntosControl.Count >= 2) return false;
            if (rbBezierCuadratica.Checked && puntosControl.Count >= 3) return false;
            if (rbBezierCubica.Checked && puntosControl.Count >= 4) return false;
            return true; // Bézier N y B-Spline no tienen límite
        }

        private bool DebeDibujarCurva()
        {
            if (rbBezierLineal.Checked && puntosControl.Count == 2) return true;
            if (rbBezierCuadratica.Checked && puntosControl.Count == 3) return true;
            if (rbBezierCubica.Checked && puntosControl.Count == 4) return true;
            if (rbBezierN.Checked && puntosControl.Count >= 2) return true;
            if (rbBSpline.Checked && puntosControl.Count >= 4) return true;
            return false;
        }

        private double Distancia(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        private Point[] PointFArrayToPointArray(PointF[] pfArray)
        {
            Point[] pArray = new Point[pfArray.Length];
            for (int i = 0; i < pfArray.Length; i++) pArray[i] = new Point((int)pfArray[i].X, (int)pfArray[i].Y);
            return pArray;
        }

        private void ActualizarInfo()
        {
            lblInfo.Text = $"Puntos: {puntosControl.Count}";
        }

        // --- Eventos de Controles ---

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntosControl.Clear();
            tAnimacion = 0;
            animando = false;
            tmrAnimacion.Stop();
            btnAnimar.Text = "Iniciar Animación";
            ActualizarInfo();
            ptbLienzo.Invalidate();
        }

        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            // Reiniciar al cambiar de algoritmo para evitar inconsistencias
            puntosControl.Clear();
            ptbLienzo.Invalidate();
            ActualizarInfo();
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (!DebeDibujarCurva())
            {
                MessageBox.Show("Dibuja la cantidad mínima de puntos requerida primero.");
                return;
            }

            animando = !animando;
            if (animando)
            {
                tAnimacion = 0;
                tmrAnimacion.Start();
                btnAnimar.Text = "Detener";
            }
            else
            {
                tmrAnimacion.Stop();
                btnAnimar.Text = "Animar";
                ptbLienzo.Invalidate(); // Limpiar rastros de animación
            }
        }

        private void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            if (animacionIda)
            {
                tAnimacion += 0.01f;
                if (tAnimacion >= 1f) { tAnimacion = 1f; animacionIda = false; }
            }
            else
            {
                tAnimacion -= 0.01f;
                if (tAnimacion <= 0f) { tAnimacion = 0f; animacionIda = true; }
            }
            ptbLienzo.Invalidate();
        }

        private void chkVerConstruccion_CheckedChanged(object sender, EventArgs e)
        {
            ptbLienzo.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}