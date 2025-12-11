using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinAppAlgoritmos
{
    // Esta clase contiene PURE LOGIC. No dibuja nada, solo calcula.
    public static class AlgoritmosRecorte
    {
        // ==========================================
        // PARTE 1: ALGORITMOS DE RECORTE DE LÍNEA
        // ==========================================

        #region Constantes Cohen-Sutherland
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000
        #endregion

        // Variante 1: Cohen-Sutherland (Estándar, códigos de región)
        public static bool CohenSutherland(ref Point p1, ref Point p2, Rectangle win)
        {
            int code1 = ComputeOutCode(p1.X, p1.Y, win);
            int code2 = ComputeOutCode(p2.X, p2.Y, win);
            bool accept = false;

            while (true)
            {
                if ((code1 | code2) == 0) { accept = true; break; } // Ambos dentro
                else if ((code1 & code2) != 0) { break; } // Ambos fuera en la misma zona
                else
                {
                    int codeOut = (code1 != 0) ? code1 : code2;
                    double x = 0, y = 0;

                    // Fórmulas de intersección
                    // Nota: En WinForms Y crece hacia abajo. Bottom > Top.
                    if ((codeOut & TOP) != 0)
                    { // Arriba (Y menor)
                        x = p1.X + (p2.X - p1.X) * (win.Top - p1.Y) / (double)(p2.Y - p1.Y);
                        y = win.Top;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    { // Abajo (Y mayor)
                        x = p1.X + (p2.X - p1.X) * (win.Bottom - p1.Y) / (double)(p2.Y - p1.Y);
                        y = win.Bottom;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    { // Derecha
                        y = p1.Y + (p2.Y - p1.Y) * (win.Right - p1.X) / (double)(p2.X - p1.X);
                        x = win.Right;
                    }
                    else if ((codeOut & LEFT) != 0)
                    { // Izquierda
                        y = p1.Y + (p2.Y - p1.Y) * (win.Left - p1.X) / (double)(p2.X - p1.X);
                        x = win.Left;
                    }

                    if (codeOut == code1) { p1 = new Point((int)x, (int)y); code1 = ComputeOutCode(p1.X, p1.Y, win); }
                    else { p2 = new Point((int)x, (int)y); code2 = ComputeOutCode(p2.X, p2.Y, win); }
                }
            }
            return accept;
        }

        private static int ComputeOutCode(double x, double y, Rectangle win)
        {
            int code = INSIDE;
            if (x < win.Left) code |= LEFT;
            else if (x > win.Right) code |= RIGHT;
            if (y < win.Top) code |= TOP; // Recordar: Top es menor Y
            else if (y > win.Bottom) code |= BOTTOM;
            return code;
        }

        // Variante 2: Liang-Barsky (Paramétrico, más eficiente)
        public static bool LiangBarsky(ref Point p1, ref Point p2, Rectangle win)
        {
            float t0 = 0.0f, t1 = 1.0f;
            float dx = p2.X - p1.X, dy = p2.Y - p1.Y;

            if (ClipTest(-dx, p1.X - win.Left, ref t0, ref t1) &&  // Izquierda
                ClipTest(dx, win.Right - p1.X, ref t0, ref t1) &&  // Derecha
                ClipTest(-dy, p1.Y - win.Top, ref t0, ref t1) &&   // Arriba
                ClipTest(dy, win.Bottom - p1.Y, ref t0, ref t1))   // Abajo
            {
                if (t1 < 1.0)
                {
                    p2.X = (int)(p1.X + t1 * dx);
                    p2.Y = (int)(p1.Y + t1 * dy);
                }
                if (t0 > 0.0)
                {
                    p1.X = (int)(p1.X + t0 * dx);
                    p1.Y = (int)(p1.Y + t0 * dy);
                }
                return true;
            }
            return false;
        }

        private static bool ClipTest(float p, float q, ref float t0, ref float t1)
        {
            float r = q / p;
            if (p < 0.0)
            {
                if (r > t1) return false;
                if (r > t0) t0 = r;
            }
            else if (p > 0.0)
            {
                if (r < t0) return false;
                if (r < t1) t1 = r;
            }
            else if (q < 0.0) return false;
            return true;
        }

        // Variante 3: Punto Medio (Aproximación recursiva)
        // Simplificado para demostración visual
        public static bool PuntoMedio(ref Point p1, ref Point p2, Rectangle win)
        {
            // Verificación trivial rápida
            if (win.Contains(p1) && win.Contains(p2)) return true;

            // Si está muy lejos, rechazar usando Cohen
            int c1 = ComputeOutCode(p1.X, p1.Y, win);
            int c2 = ComputeOutCode(p2.X, p2.Y, win);
            if ((c1 & c2) != 0) return false;

            // Estrategia: Acercar los puntos P1 y P2 al borde mediante bisección
            // Nota: Para la entrega académica, esta es una implementación híbrida robusta.
            p1 = AcercarPunto(p1, p2, win);
            p2 = AcercarPunto(p2, p1, win);

            // Verificación final
            return win.Contains(p1) || win.Contains(p2) || ((ComputeOutCode(p1.X, p1.Y, win) | ComputeOutCode(p2.X, p2.Y, win)) == 0);
        }

        private static Point AcercarPunto(Point target, Point other, Rectangle win)
        {
            if (win.Contains(target)) return target;
            Point pCerca = target;
            Point pLejos = other;

            // Bisección simple por 10 iteraciones
            for (int i = 0; i < 10; i++)
            {
                Point mid = new Point((pCerca.X + pLejos.X) / 2, (pCerca.Y + pLejos.Y) / 2);
                if (ComputeOutCode(mid.X, mid.Y, win) != 0) pCerca = mid; // Sigue fuera
                else pLejos = mid; // Ya entró
            }
            return pLejos; // Devolvemos el punto que entró
        }


        // ==========================================
        // PARTE 2: ALGORITMOS DE RECORTE DE POLÍGONO
        // ==========================================

        // Variante 1: Sutherland-Hodgman (Clásico)
        public static List<Point> SutherlandHodgmanPoly(List<Point> poly, Rectangle win)
        {
            List<Point> output = new List<Point>(poly);
            // Procesar los 4 bordes en orden
            output = ClipPolyAxis(output, win.Left, (p) => p.X, (p) => p.Y, (val, lim) => val >= lim, true); // Izq
            output = ClipPolyAxis(output, win.Right, (p) => p.X, (p) => p.Y, (val, lim) => val <= lim, true); // Der
            output = ClipPolyAxis(output, win.Top, (p) => p.Y, (p) => p.X, (val, lim) => val >= lim, false); // Top
            output = ClipPolyAxis(output, win.Bottom, (p) => p.Y, (p) => p.X, (val, lim) => val <= lim, false); // Bottom
            return output;
        }

        // Helper genérico para Sutherland-Hodgman
        private static List<Point> ClipPolyAxis(List<Point> input, double limit, Func<Point, double> getP, Func<Point, double> getS, Func<double, double, bool> isInside, bool vertical)
        {
            List<Point> outList = new List<Point>();
            if (input.Count == 0) return outList;
            Point S = input[input.Count - 1];
            foreach (Point E in input)
            {
                bool Ein = isInside(getP(E), limit);
                bool Sin = isInside(getP(S), limit);
                if (Ein)
                {
                    if (!Sin) outList.Add(IntersectPoly(S, E, limit, vertical));
                    outList.Add(E);
                }
                else if (Sin)
                {
                    outList.Add(IntersectPoly(S, E, limit, vertical));
                }
                S = E;
            }
            return outList;
        }

        private static Point IntersectPoly(Point p1, Point p2, double k, bool vertical)
        {
            double m = (p2.X != p1.X) ? (double)(p2.Y - p1.Y) / (p2.X - p1.X) : 100000;
            if (vertical) return new Point((int)k, (int)(p1.Y + m * (k - p1.X)));
            else return new Point((int)(p1.X + (k - p1.Y) / m), (int)k);
        }

        // Variante 2: Recorte por Aristas (Wireframe / Lines)
        // Trata el polígono como líneas individuales usando Liang-Barsky
        public static List<Point[]> RecortePorAristas(List<Point> poly, Rectangle win)
        {
            List<Point[]> lineas = new List<Point[]>();
            if (poly.Count < 2) return lineas;
            for (int i = 0; i < poly.Count; i++)
            {
                Point p1 = poly[i];
                Point p2 = poly[(i + 1) % poly.Count];
                if (LiangBarsky(ref p1, ref p2, win)) // Reutilizamos Liang-Barsky
                    lineas.Add(new Point[] { p1, p2 });
            }
            return lineas;
        }

        // Variante 3: Validación por Caja Envolvente (Bounding Box Check)
        // Optimización: Retorna 1 (Todo dentro), -1 (Todo fuera), 0 (Parcial)
        public static int CheckBoundingBox(List<Point> poly, Rectangle win)
        {
            if (poly.Count == 0) return -1;
            int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;
            foreach (Point p in poly)
            {
                if (p.X < minX) minX = p.X; if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y; if (p.Y > maxY) maxY = p.Y;
            }
            Rectangle polyRect = new Rectangle(minX, minY, maxX - minX, maxY - minY);

            if (win.Contains(polyRect)) return 1; // Totalmente dentro (Trivial Accept)
            if (!win.IntersectsWith(polyRect)) return -1; // Totalmente fuera (Trivial Reject)
            return 0; // Parcial (Requiere algoritmo pesado)
        }
    }
}