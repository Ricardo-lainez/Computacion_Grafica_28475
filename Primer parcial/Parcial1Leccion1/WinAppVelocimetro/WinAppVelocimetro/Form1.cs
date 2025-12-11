using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VelocimetroGrafico
{
    public partial class Form1 : Form
    {
        // VARIABLES DE ESTADO
        private float velocidadActual = 0f; // Variable que mueve la aguja
        private float velocidadObjetivo = 0f; // Para animación suave
        private Timer timerAnimacion;

        // VARIABLES DE DISEÑO (Configurables)
        private int centroX, centroY;
        private int radio = 180; // Radio del velocímetro
        private const int VELOCIDAD_MAXIMA = 180; // km/h
        private const int MARCA_PRINCIPAL = 20; // Cada 20 km/h
        private const int MARCA_SECUNDARIA = 10; // Cada 10 km/h

        // COLORES DEL DISEÑO
        private Color colorFondo = Color.FromArgb(20, 20, 25);
        private Color colorBordeExterno = Color.FromArgb(100, 100, 110);
        private Color colorBordeInterno = Color.FromArgb(60, 60, 70);
        private Color colorMarcaPrincipal = Color.FromArgb(220, 220, 230);
        private Color colorMarcaSecundaria = Color.FromArgb(100, 100, 120);
        private Color colorTexto = Color.FromArgb(240, 240, 250);
        private Color colorAguja = Color.FromArgb(220, 50, 50);
        private Color colorAgujaBase = Color.FromArgb(180, 40, 40);
        private Color colorDisplay = Color.FromArgb(0, 255, 200);
        private Color colorZonaVerde = Color.FromArgb(80, 200, 120);
        private Color colorZonaAmarilla = Color.FromArgb(255, 200, 50);
        private Color colorZonaRoja = Color.FromArgb(255, 80, 80);

        public Form1()
        {
            InitializeComponent();
            ConfigurarVentana();
            ConfigurarTrackBar();
            ConfigurarAnimacion();
        }

        private void ConfigurarVentana()
        {
            // Configuración de la ventana principal
            this.Text = "Velocímetro Digital-Analógico | Computación Gráfica";
            this.Size = new Size(600, 650);
            this.BackColor = colorFondo;
            this.DoubleBuffered = true; // Evita parpadeo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configurar el evento de redibujado
            this.Paint += new PaintEventHandler(DibujarVelocimetro);
        }

        private void ConfigurarTrackBar()
        {
            if (trackBarVelocidad != null)
            {
                trackBarVelocidad.Minimum = 0;
                trackBarVelocidad.Maximum = VELOCIDAD_MAXIMA;
                trackBarVelocidad.Value = 0;
                trackBarVelocidad.TickFrequency = MARCA_PRINCIPAL;
                trackBarVelocidad.Width = 400;
                trackBarVelocidad.Height = 45;
                
                // Centrar el TrackBar en la parte inferior
                trackBarVelocidad.Location = new Point(
                    (this.ClientSize.Width - trackBarVelocidad.Width) / 2,
                    this.ClientSize.Height - 80
                );

                trackBarVelocidad.Scroll += (s, e) => {
                    velocidadObjetivo = trackBarVelocidad.Value;
                };
            }
        }

        private void ConfigurarAnimacion()
        {
            // Timer para animación suave de la aguja
            timerAnimacion = new Timer();
            timerAnimacion.Interval = 20; // 50 FPS
            timerAnimacion.Tick += (s, e) => {
                // Interpolación suave hacia la velocidad objetivo
                float diferencia = velocidadObjetivo - velocidadActual;
                if (Math.Abs(diferencia) > 0.5f)
                {
                    velocidadActual += diferencia * 0.1f;
                    this.Invalidate();
                }
                else
                {
                    velocidadActual = velocidadObjetivo;
                }
            };
            timerAnimacion.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configuraciones adicionales al cargar
        }

        // Método principal de dibujo
        private void DibujarVelocimetro(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Calcular el centro
            centroX = this.ClientSize.Width / 2;
            centroY = (this.ClientSize.Height - 100) / 2 + 30;

            // 1. Dibujar fondo circular degradado
            DibujarFondoCircular(g);

            // 2. Dibujar zonas de color (verde, amarillo, rojo)
            DibujarZonasDeColor(g);

            // 3. Dibujar círculos concéntricos
            DibujarCirculosConcéntricos(g);

            // 4. Dibujar la escala y marcas
            DibujarEscalaYMarcas(g);

            // 5. Dibujar números de velocidad
            DibujarNumerosVelocidad(g);

            // 6. Dibujar etiqueta "km/h" en el centro superior
            DibujarEtiqueta(g);

            // 7. Dibujar display digital
            DibujarDisplayDigital(g);

            // 8. Dibujar la aguja
            DibujarAguja(g);

            // 9. Dibujar tapón central
            DibujarTaponCentral(g);

            // 10. Dibujar título
            DibujarTitulo(g);
        }

        private void DibujarFondoCircular(Graphics g)
        {
            // Gradiente radial para el fondo
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(centroX - radio - 20, centroY - radio - 20, (radio + 20) * 2, (radio + 20) * 2);
            
            PathGradientBrush gradiente = new PathGradientBrush(path);
            gradiente.CenterColor = Color.FromArgb(40, 40, 50);
            gradiente.SurroundColors = new Color[] { Color.FromArgb(15, 15, 20) };
            
            g.FillEllipse(gradiente, centroX - radio - 20, centroY - radio - 20, (radio + 20) * 2, (radio + 20) * 2);
        }

        private void DibujarZonasDeColor(Graphics g)
        {
            // Zona Verde: 0-100 km/h
            DibujarArcoZona(g, 0, 100, colorZonaVerde);
            
            // Zona Amarilla: 100-140 km/h
            DibujarArcoZona(g, 100, 140, colorZonaAmarilla);
            
            // Zona Roja: 140-180 km/h
            DibujarArcoZona(g, 140, 180, colorZonaRoja);
        }

        private void DibujarArcoZona(Graphics g, int velocidadInicio, int velocidadFin, Color color)
        {
            // Convertir velocidades a ángulos (180 grados para 180 km/h)
            float anguloInicio = 180 + velocidadInicio;
            float anguloBarrido = velocidadFin - velocidadInicio;
            
            int radioZona = radio - 15;
            int grosorZona = 8;
            
            using (Pen penZona = new Pen(color, grosorZona))
            {
                g.DrawArc(penZona, 
                    centroX - radioZona, 
                    centroY - radioZona, 
                    radioZona * 2, 
                    radioZona * 2, 
                    anguloInicio, 
                    anguloBarrido);
            }
        }

        private void DibujarCirculosConcéntricos(Graphics g)
        {
            // Círculo exterior (borde principal)
            using (Pen penExterior = new Pen(colorBordeExterno, 6))
            {
                g.DrawEllipse(penExterior, centroX - radio, centroY - radio, radio * 2, radio * 2);
            }

            // Círculo medio
            int radioMedio = radio - 30;
            using (Pen penMedio = new Pen(colorBordeInterno, 2))
            {
                g.DrawEllipse(penMedio, centroX - radioMedio, centroY - radioMedio, radioMedio * 2, radioMedio * 2);
            }

            // Círculo interior
            int radioInterior = radio - 60;
            using (Pen penInterior = new Pen(colorBordeInterno, 1))
            {
                g.DrawEllipse(penInterior, centroX - radioInterior, centroY - radioInterior, radioInterior * 2, radioInterior * 2);
            }
        }

        private void DibujarEscalaYMarcas(Graphics g)
        {
            // Dibujar marcas desde 0 hasta 180 km/h
            for (int velocidad = 0; velocidad <= VELOCIDAD_MAXIMA; velocidad++)
            {
                // Convertir velocidad a ángulo (empezar desde la izquierda)
                double anguloRad = (180 + velocidad) * Math.PI / 180.0;

                // Coordenadas del punto exterior
                float xOuter = centroX + (float)(radio * Math.Cos(anguloRad));
                float yOuter = centroY + (float)(radio * Math.Sin(anguloRad));

                if (velocidad % MARCA_PRINCIPAL == 0) // Marca principal cada 20 km/h
                {
                    float xInner = centroX + (float)((radio - 25) * Math.Cos(anguloRad));
                    float yInner = centroY + (float)((radio - 25) * Math.Sin(anguloRad));

                    using (Pen penMarca = new Pen(colorMarcaPrincipal, 3))
                    {
                        g.DrawLine(penMarca, xInner, yInner, xOuter, yOuter);
                    }
                }
                else if (velocidad % MARCA_SECUNDARIA == 0) // Marca secundaria cada 10 km/h
                {
                    float xInner = centroX + (float)((radio - 15) * Math.Cos(anguloRad));
                    float yInner = centroY + (float)((radio - 15) * Math.Sin(anguloRad));

                    using (Pen penMarca = new Pen(colorMarcaSecundaria, 2))
                    {
                        g.DrawLine(penMarca, xInner, yInner, xOuter, yOuter);
                    }
                }
                else if (velocidad % 5 == 0) // Marcas muy pequeñas cada 5 km/h
                {
                    float xInner = centroX + (float)((radio - 8) * Math.Cos(anguloRad));
                    float yInner = centroY + (float)((radio - 8) * Math.Sin(anguloRad));

                    using (Pen penMarca = new Pen(colorMarcaSecundaria, 1))
                    {
                        g.DrawLine(penMarca, xInner, yInner, xOuter, yOuter);
                    }
                }
            }
        }

        private void DibujarNumerosVelocidad(Graphics g)
        {
            // Dibujar números cada 20 km/h
            Font fuenteNumero = new Font("Segoe UI", 11, FontStyle.Bold);
            
            for (int velocidad = 0; velocidad <= VELOCIDAD_MAXIMA; velocidad += MARCA_PRINCIPAL)
            {
                double anguloRad = (180 + velocidad) * Math.PI / 180.0;
                
                // Posición del número (más adentro que las marcas)
                float xTexto = centroX + (float)((radio - 48) * Math.Cos(anguloRad));
                float yTexto = centroY + (float)((radio - 48) * Math.Sin(anguloRad));

                string numero = velocidad.ToString();
                SizeF tamano = g.MeasureString(numero, fuenteNumero);

                // Centrar el texto
                g.DrawString(numero, fuenteNumero, new SolidBrush(colorTexto), 
                    xTexto - (tamano.Width / 2), 
                    yTexto - (tamano.Height / 2));
            }
        }

        private void DibujarEtiqueta(Graphics g)
        {
            // Etiqueta "km/h" en la parte superior del círculo
            Font fuenteEtiqueta = new Font("Segoe UI", 10, FontStyle.Italic);
            string etiqueta = "km/h";
            SizeF tamano = g.MeasureString(etiqueta, fuenteEtiqueta);
            
            g.DrawString(etiqueta, fuenteEtiqueta, new SolidBrush(colorTexto),
                centroX - (tamano.Width / 2),
                centroY - radio + 35);
        }

        private void DibujarDisplayDigital(Graphics g)
        {
            // Display digital en la parte inferior del velocímetro
            Font fuenteDigital = new Font("Consolas", 32, FontStyle.Bold);
            string textoVelocidad = velocidadActual.ToString("0");
            SizeF tamanoTexto = g.MeasureString(textoVelocidad, fuenteDigital);

            // Rectángulo de fondo para el display
            int anchoDisplay = 150;
            int altoDisplay = 55;
            RectangleF rectDisplay = new RectangleF(
                centroX - (anchoDisplay / 2),
                centroY + 70,
                anchoDisplay,
                altoDisplay
            );

            // Fondo con gradiente
            using (LinearGradientBrush gradiente = new LinearGradientBrush(
                rectDisplay,
                Color.FromArgb(10, 10, 15),
                Color.FromArgb(30, 30, 40),
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(gradiente, rectDisplay);
            }

            // Borde del display
            using (Pen penBorde = new Pen(colorBordeExterno, 2))
            {
                g.DrawRectangle(penBorde, 
                    rectDisplay.X, rectDisplay.Y, 
                    rectDisplay.Width, rectDisplay.Height);
            }

            // Número digital con efecto de brillo
            using (SolidBrush brocha = new SolidBrush(colorDisplay))
            {
                g.DrawString(textoVelocidad, fuenteDigital, brocha,
                    centroX - (tamanoTexto.Width / 2),
                    centroY + 75);
            }

            // Etiqueta "km/h" pequeña al lado
            Font fuentePequeña = new Font("Segoe UI", 9, FontStyle.Regular);
            g.DrawString("km/h", fuentePequeña, new SolidBrush(colorTexto),
                centroX + (tamanoTexto.Width / 2) + 5,
                centroY + 95);
        }

        private void DibujarAguja(Graphics g)
        {
            // Guardar el estado actual de los gráficos
            GraphicsState estado = g.Save();

            // Calcular el ángulo de la aguja
            double anguloRad = (180 + velocidadActual) * Math.PI / 180.0;

            // Longitud de la aguja
            int longitudAguja = radio - 40;
            int longitudCola = 25; // Cola de la aguja

            // Punto de la punta
            float xPunta = centroX + (float)(longitudAguja * Math.Cos(anguloRad));
            float yPunta = centroY + (float)(longitudAguja * Math.Sin(anguloRad));

            // Punto de la cola (dirección opuesta)
            float xCola = centroX - (float)(longitudCola * Math.Cos(anguloRad));
            float yCola = centroY - (float)(longitudCola * Math.Sin(anguloRad));

            // Calcular puntos laterales para el grosor
            double anguloPerp1 = anguloRad + (Math.PI / 2);
            double anguloPerp2 = anguloRad - (Math.PI / 2);
            int anchoAguja = 5;
            int anchoBase = 10;

            // Puntos de la punta
            float xP1 = xPunta + (float)(2 * Math.Cos(anguloPerp1));
            float yP1 = yPunta + (float)(2 * Math.Sin(anguloPerp1));
            float xP2 = xPunta + (float)(2 * Math.Cos(anguloPerp2));
            float yP2 = yPunta + (float)(2 * Math.Sin(anguloPerp2));

            // Puntos del centro
            float xC1 = centroX + (float)(anchoAguja * Math.Cos(anguloPerp1));
            float yC1 = centroY + (float)(anchoAguja * Math.Sin(anguloPerp1));
            float xC2 = centroX + (float)(anchoAguja * Math.Cos(anguloPerp2));
            float yC2 = centroY + (float)(anchoAguja * Math.Sin(anguloPerp2));

            // Puntos de la cola
            float xCo1 = xCola + (float)(anchoBase * Math.Cos(anguloPerp1));
            float yCo1 = yCola + (float)(anchoBase * Math.Sin(anguloPerp1));
            float xCo2 = xCola + (float)(anchoBase * Math.Cos(anguloPerp2));
            float yCo2 = yCola + (float)(anchoBase * Math.Sin(anguloPerp2));

            // Definir el polígono de la aguja
            PointF[] puntosAguja = {
                new PointF(xPunta, yPunta),  // Punta
                new PointF(xP1, yP1),
                new PointF(xC1, yC1),
                new PointF(xCo1, yCo1),      // Cola
                new PointF(xCo2, yCo2),
                new PointF(xC2, yC2),
                new PointF(xP2, yP2)
            };

            // Dibujar sombra de la aguja
            GraphicsPath pathSombra = new GraphicsPath();
            PointF[] puntosSombra = (PointF[])puntosAguja.Clone();
            for (int i = 0; i < puntosSombra.Length; i++)
            {
                puntosSombra[i].X += 3;
                puntosSombra[i].Y += 3;
            }
            pathSombra.AddPolygon(puntosSombra);
            using (SolidBrush brochaSombra = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            {
                g.FillPath(brochaSombra, pathSombra);
            }

            // Dibujar la aguja con gradiente
            GraphicsPath pathAguja = new GraphicsPath();
            pathAguja.AddPolygon(puntosAguja);
            
            using (PathGradientBrush gradienteAguja = new PathGradientBrush(pathAguja))
            {
                gradienteAguja.CenterColor = colorAguja;
                gradienteAguja.SurroundColors = new Color[] { colorAgujaBase };
                g.FillPath(gradienteAguja, pathAguja);
            }

            // Borde de la aguja
            using (Pen penBorde = new Pen(Color.FromArgb(100, 0, 0), 1))
            {
                g.DrawPolygon(penBorde, puntosAguja);
            }

            // Restaurar el estado
            g.Restore(estado);
        }

        private void DibujarTaponCentral(Graphics g)
        {
            int radioTapon = 12;

            // Sombra del tapón
            using (SolidBrush brochaSombra = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
            {
                g.FillEllipse(brochaSombra, 
                    centroX - radioTapon + 2, 
                    centroY - radioTapon + 2, 
                    radioTapon * 2, 
                    radioTapon * 2);
            }

            // Tapón con gradiente radial
            GraphicsPath pathTapon = new GraphicsPath();
            pathTapon.AddEllipse(
                centroX - radioTapon, 
                centroY - radioTapon, 
                radioTapon * 2, 
                radioTapon * 2);
            
            using (PathGradientBrush gradiente = new PathGradientBrush(pathTapon))
            {
                gradiente.CenterColor = Color.FromArgb(180, 50, 50);
                gradiente.SurroundColors = new Color[] { Color.FromArgb(80, 20, 20) };
                g.FillPath(gradiente, pathTapon);
            }

            // Borde del tapón
            using (Pen penBorde = new Pen(Color.FromArgb(50, 50, 50), 2))
            {
                g.DrawEllipse(penBorde, 
                    centroX - radioTapon, 
                    centroY - radioTapon, 
                    radioTapon * 2, 
                    radioTapon * 2);
            }

            // Círculo interior brillante
            int radioInterior = 6;
            using (SolidBrush brochaInterior = new SolidBrush(Color.FromArgb(255, 100, 100)))
            {
                g.FillEllipse(brochaInterior, 
                    centroX - radioInterior, 
                    centroY - radioInterior, 
                    radioInterior * 2, 
                    radioInterior * 2);
            }
        }

        private void DibujarTitulo(Graphics g)
        {
            // Título en la parte superior de la ventana
            Font fuenteTitulo = new Font("Segoe UI", 14, FontStyle.Bold);
            string titulo = "VELOCÍMETRO DIGITAL-ANALÓGICO";
            SizeF tamano = g.MeasureString(titulo, fuenteTitulo);
            
            g.DrawString(titulo, fuenteTitulo, new SolidBrush(colorTexto),
                centroX - (tamano.Width / 2),
                20);

            // Subtítulo
            Font fuenteSubtitulo = new Font("Segoe UI", 9, FontStyle.Italic);
            string subtitulo = "Computación Gráfica - Primitivas Geométricas";
            SizeF tamanoSub = g.MeasureString(subtitulo, fuenteSubtitulo);
            
            g.DrawString(subtitulo, fuenteSubtitulo, new SolidBrush(colorMarcaSecundaria),
                centroX - (tamanoSub.Width / 2),
                45);
        }
    }
}