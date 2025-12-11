using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinAppCurvas
{
    public static class CurvasMath
    {
        // Interpolación Lineal (Lerp)
        public static PointF Lerp(PointF p0, PointF p1, float t)
        {
            return new PointF(
                p0.X + (p1.X - p0.X) * t,
                p0.Y + (p1.Y - p0.Y) * t
            );
        }

        // Algoritmo de De Casteljau (General para N puntos)
        // Retorna no solo el punto final, sino los puntos intermedios para la animación de construcción
        public static List<List<PointF>> DeCasteljau(List<PointF> puntosControl, float t)
        {
            List<List<PointF>> niveles = new List<List<PointF>>();
            niveles.Add(new List<PointF>(puntosControl));

            if (puntosControl.Count < 2) return niveles;

            // Procesamos niveles hasta llegar a un solo punto
            List<PointF> nivelActual = puntosControl;
            while (nivelActual.Count > 1)
            {
                List<PointF> siguienteNivel = new List<PointF>();
                for (int i = 0; i < nivelActual.Count - 1; i++)
                {
                    siguienteNivel.Add(Lerp(nivelActual[i], nivelActual[i + 1], t));
                }
                niveles.Add(siguienteNivel);
                nivelActual = siguienteNivel;
            }
            return niveles;
        }

        // B-Spline Uniforme Cúbica (Calcula un punto en el segmento)
        // Requiere al menos 4 puntos.
        public static PointF CalcularBSpline(PointF p0, PointF p1, PointF p2, PointF p3, float t)
        {
            // Funciones base para B-Spline Cúbica
            float b0 = (1 - t) * (1 - t) * (1 - t) / 6;
            float b1 = (3 * t * t * t - 6 * t * t + 4) / 6;
            float b2 = (-3 * t * t * t + 3 * t * t + 3 * t + 1) / 6;
            float b3 = t * t * t / 6;

            float x = b0 * p0.X + b1 * p1.X + b2 * p2.X + b3 * p3.X;
            float y = b0 * p0.Y + b1 * p1.Y + b2 * p2.Y + b3 * p3.Y;

            return new PointF(x, y);
        }
    }
}