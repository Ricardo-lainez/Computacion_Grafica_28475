using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinAppCurvas
{
    // --- INTERFAZ ACTUALIZADA ---
    public interface IEstrategiaCurva
    {
        string Nombre { get; }
        string Descripcion { get; }
        int MinimoPuntosRequeridos { get; }

        // Calcula la curva completa (estática)
        List<PointF> CalcularCurvaCompleta(List<PointF> puntosControl, int pasos);

        // Calcula los datos para un instante 't' (0.0 a 1.0) para la animación
        // Retorna una lista de listas de puntos (niveles de recursión)
        List<List<PointF>> CalcularPasoAnimacion(List<PointF> puntosControl, float t);

        bool ValidarEntrada(List<PointF> puntosControl);
    }

    // --- IMPLEMENTACIÓN BÉZIER (Con Animación De Casteljau) ---
    public class CurvaBezier : IEstrategiaCurva
    {
        public string Nombre => "Curva de Bézier (De Casteljau)";
        public string Descripcion => "Curva paramétrica suave. La animación muestra el algoritmo recursivo de De Casteljau (líneas verdes) construyendo el punto final.";
        public int MinimoPuntosRequeridos => 2;

        public bool ValidarEntrada(List<PointF> puntosControl) => puntosControl != null && puntosControl.Count >= MinimoPuntosRequeridos;

        public List<PointF> CalcularCurvaCompleta(List<PointF> puntosControl, int pasos)
        {
            List<PointF> curva = new List<PointF>();
            if (!ValidarEntrada(puntosControl)) return curva;

            for (int i = 0; i <= pasos; i++)
            {
                float t = i / (float)pasos;
                // Obtenemos el último punto de la recursión (el punto en la curva)
                var niveles = CalcularPasoAnimacion(puntosControl, t);
                if (niveles.Count > 0)
                    curva.Add(niveles[niveles.Count - 1][0]);
            }
            return curva;
        }

        // Algoritmo De Casteljau completo (devuelve todos los niveles para visualizar las líneas)
        public List<List<PointF>> CalcularPasoAnimacion(List<PointF> puntosControl, float t)
        {
            List<List<PointF>> niveles = new List<List<PointF>>();
            niveles.Add(new List<PointF>(puntosControl)); // Nivel 0: Puntos de control

            List<PointF> nivelActual = puntosControl;

            while (nivelActual.Count > 1)
            {
                List<PointF> siguienteNivel = new List<PointF>();
                for (int i = 0; i < nivelActual.Count - 1; i++)
                {
                    float x = (1 - t) * nivelActual[i].X + t * nivelActual[i + 1].X;
                    float y = (1 - t) * nivelActual[i].Y + t * nivelActual[i + 1].Y;
                    siguienteNivel.Add(new PointF(x, y));
                }
                niveles.Add(siguienteNivel);
                nivelActual = siguienteNivel;
            }
            return niveles;
        }
    }

    // --- IMPLEMENTACIÓN B-SPLINE (Animación de recorrido) ---
    public class CurvaBSpline : IEstrategiaCurva
    {
        public string Nombre => "B-Spline Cúbica Uniforme";
        public string Descripcion => "Curva por tramos con continuidad C2. La animación recorre la curva calculada matemáticamente.";
        public int MinimoPuntosRequeridos => 4;

        public bool ValidarEntrada(List<PointF> puntosControl) => puntosControl != null && puntosControl.Count >= MinimoPuntosRequeridos;

        public List<PointF> CalcularCurvaCompleta(List<PointF> puntosControl, int pasos)
        {
            List<PointF> curva = new List<PointF>();
            if (!ValidarEntrada(puntosControl)) return curva;

            int segmentos = puntosControl.Count - 3;
            float pasoPorSegmento = 1.0f / 20.0f; // Resolución

            for (int i = 0; i < segmentos; i++)
            {
                for (float t = 0; t <= 1; t += pasoPorSegmento)
                {
                    curva.Add(CalcularPuntoMatricial(puntosControl, i, t));
                }
            }
            return curva;
        }

        public List<List<PointF>> CalcularPasoAnimacion(List<PointF> puntosControl, float tGlobal)
        {
            // Para B-Spline, la animación simplemente devuelve el punto en la curva.
            // No hay "líneas de construcción" intuitivas como en De Casteljau.
            List<List<PointF>> resultado = new List<List<PointF>>();
            if (!ValidarEntrada(puntosControl)) return resultado;

            int numSegmentos = puntosControl.Count - 3;

            // Mapear t global (0..1) al segmento específico y t local
            float tExpandido = tGlobal * numSegmentos;
            int segmentoIndex = (int)tExpandido;
            if (segmentoIndex >= numSegmentos) segmentoIndex = numSegmentos - 1; // Clamping final
            float tLocal = tExpandido - segmentoIndex;

            PointF punto = CalcularPuntoMatricial(puntosControl, segmentoIndex, tLocal);

            // Devolvemos una lista con un solo punto (el viajero)
            resultado.Add(new List<PointF> { punto });
            return resultado;
        }

        private PointF CalcularPuntoMatricial(List<PointF> pts, int i, float t)
        {
            float t2 = t * t;
            float t3 = t * t * t;

            // Coeficientes precalculados
            float b0 = (1 - t) * (1 - t) * (1 - t) / 6.0f;
            float b1 = (3 * t3 - 6 * t2 + 4) / 6.0f;
            float b2 = (-3 * t3 + 3 * t2 + 3 * t + 1) / 6.0f;
            float b3 = t3 / 6.0f;

            float x = b0 * pts[i].X + b1 * pts[i + 1].X + b2 * pts[i + 2].X + b3 * pts[i + 3].X;
            float y = b0 * pts[i].Y + b1 * pts[i + 1].Y + b2 * pts[i + 2].Y + b3 * pts[i + 3].Y;

            return new PointF(x, y);
        }
    }
}