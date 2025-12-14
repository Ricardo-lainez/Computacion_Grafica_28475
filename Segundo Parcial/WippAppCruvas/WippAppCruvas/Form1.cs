using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppCurvas
{
    public partial class Form1 : Form
    {
        // Estado de la aplicación
        private List<PointF> puntosControl;
        private IEstrategiaCurva estrategiaActual;
        private int indiceArrastre = -1;
        private const int RADIO_NODO = 6;

        // Variables de Animación
        private bool animando = false;
        private float tActual = 0f;
        private bool ida = true; // Para hacer efecto ping-pong (0->1 y 1->0)

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            puntosControl = new List<PointF>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                rbBezier.Checked = true;
                ConfigurarEstrategia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar: " + ex.Message);
            }
        }

        private void rbAlgoritmo_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ConfigurarEstrategia();
                DetenerAnimacion();
                ptbLienzo.Invalidate();
            }
        }

        private void ConfigurarEstrategia()
        {
            if (rbBezier.Checked) estrategiaActual = new CurvaBezier();
            else if (rbBSpline.Checked) estrategiaActual = new CurvaBSpline();

            lblDescripcionTecnica.Text = estrategiaActual.Descripcion;
            ActualizarEstadoPuntos();
        }

        // --- Lógica de Interacción Mouse ---
        private void ptbLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            if (animando) return; // Bloquear edición si anima

            try
            {
                for (int i = 0; i < puntosControl.Count; i++)
                {
                    if (Distancia(e.Location, puntosControl[i]) <= RADIO_NODO)
                    {
                        indiceArrastre = i;
                        return;
                    }
                }

                if (e.X >= 0 && e.X <= ptbLienzo.Width && e.Y >= 0 && e.Y <= ptbLienzo.Height)
                {
                    puntosControl.Add(e.Location);
                    ActualizarEstadoPuntos();
                    ptbLienzo.Invalidate();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void ptbLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (indiceArrastre != -1)
            {
                float x = Math.Max(0, Math.Min(ptbLienzo.Width, e.X));
                float y = Math.Max(0, Math.Min(ptbLienzo.Height, e.Y));
                puntosControl[indiceArrastre] = new PointF(x, y);
                ptbLienzo.Invalidate();
            }
        }

        private void ptbLienzo_MouseUp(object sender, MouseEventArgs e) => indiceArrastre = -1;

        // --- Lógica de Animación ---
        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (!estrategiaActual.ValidarEntrada(puntosControl))
            {
                MessageBox.Show($"Necesitas al menos {estrategiaActual.MinimoPuntosRequeridos} puntos.");
                return;
            }

            animando = !animando;
            if (animando)
            {
                tActual = 0f;
                ida = true;
                tmrAnimacion.Start();
                btnAnimar.Text = "Detener Animación";
            }
            else
            {
                DetenerAnimacion();
            }
        }

        private void DetenerAnimacion()
        {
            animando = false;
            tmrAnimacion.Stop();
            btnAnimar.Text = "Iniciar Animación";
            ptbLienzo.Invalidate();
        }

        private void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            float velocidad = 0.01f;
            if (ida)
            {
                tActual += velocidad;
                if (tActual >= 1f) { tActual = 1f; ida = false; }
            }
            else
            {
                tActual -= velocidad;
                if (tActual <= 0f) { tActual = 0f; ida = true; }
            }
            ptbLienzo.Invalidate();
        }

        // --- Renderizado Principal ---
        private void ptbLienzo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Dibujar Polígono de Control (Líneas grises)
            if (puntosControl.Count > 1)
            {
                using (Pen penControl = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dash })
                {
                    e.Graphics.DrawLines(penControl, ConvertirArray(puntosControl));
                }
            }

            if (estrategiaActual.ValidarEntrada(puntosControl))
            {
                // 2. Dibujar la Curva Completa (Azul)
                List<PointF> curva = estrategiaActual.CalcularCurvaCompleta(puntosControl, 100);
                if (curva.Count > 1)
                {
                    using (Pen penCurva = new Pen(Color.Blue, 2))
                        e.Graphics.DrawLines(penCurva, ConvertirArray(curva));
                }

                // 3. Dibujar Animación (Si está activa)
                if (animando)
                {
                    // Pedimos a la estrategia los datos del instante 'tActual'
                    List<List<PointF>> niveles = estrategiaActual.CalcularPasoAnimacion(puntosControl, tActual);

                    if (niveles.Count > 0)
                    {
                        // A. Dibujar Líneas de construcción (Solo si el usuario quiere y si hay niveles intermedios)
                        if (chkVerLineas.Checked && niveles.Count > 1)
                        {
                            for (int i = 1; i < niveles.Count - 1; i++) // Omitimos el último que es el punto
                            {
                                using (Pen penCons = new Pen(Color.FromArgb(100, 0, 255, 0), 1))
                                    e.Graphics.DrawLines(penCons, ConvertirArray(niveles[i]));

                                foreach (var p in niveles[i]) // Pequeños puntos verdes
                                    e.Graphics.FillEllipse(Brushes.LightGreen, p.X - 2, p.Y - 2, 4, 4);
                            }
                        }

                        // B. Dibujar el Punto Viajero (Último elemento del último nivel)
                        PointF puntoFinal = niveles[niveles.Count - 1][0];
                        e.Graphics.FillEllipse(Brushes.Black, puntoFinal.X - 5, puntoFinal.Y - 5, 10, 10);
                    }
                }
            }

            // 4. Dibujar Nodos (Puntos Rojos)
            foreach (var punto in puntosControl)
            {
                e.Graphics.FillEllipse(Brushes.Red, punto.X - RADIO_NODO, punto.Y - RADIO_NODO, RADIO_NODO * 2, RADIO_NODO * 2);
                e.Graphics.DrawEllipse(Pens.DarkRed, punto.X - RADIO_NODO, punto.Y - RADIO_NODO, RADIO_NODO * 2, RADIO_NODO * 2);
            }
        }

        // --- Helpers ---
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntosControl.Clear();
            DetenerAnimacion();
            ActualizarEstadoPuntos();
            ptbLienzo.Invalidate();
        }

        private void ActualizarEstadoPuntos()
        {
            lblEstado.Text = $"Modo: {estrategiaActual.Nombre} | Puntos: {puntosControl.Count} (Min: {estrategiaActual.MinimoPuntosRequeridos})";
            lblEstado.ForeColor = (puntosControl.Count < estrategiaActual.MinimoPuntosRequeridos) ? Color.Red : Color.Black;
        }

        private double Distancia(PointF p1, PointF p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        private PointF[] ConvertirArray(List<PointF> lista) => lista.ToArray();
    }
}