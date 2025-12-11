using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinAppTriangleSt
{
    /// <summary>
    /// Mantiene el estado de las transformaciones (rotación, escala, traslación)
    /// de una figura y las aplica a un objeto Graphics.
    /// </summary>
    public class FigureTransformer
    {
        // --- PROPIEDADES DE ESTADO ---

        /// <summary>
        /// El punto central (pivote) sobre el cual rotar y escalar.
        /// </summary>
        public PointF Pivot { get; set; } = PointF.Empty;

        /// <summary>
        /// La rotación actual en grados.
        /// </summary>
        public float Rotation { get; private set; } = 0f;

        /// <summary>
        /// El factor de escala actual (1.0 = 100%).
        /// </summary>
        public float Scale { get; private set; } = 1.0f;

        /// <summary>
        /// El desplazamiento (X, Y) desde el pivote.
        /// </summary>
        public PointF Translation { get; private set; } = PointF.Empty;


        // --- MÉTODOS DE ACCIÓN ---

        /// <summary>
        /// Añade grados a la rotación actual.
        /// </summary>
        /// <param name="degrees">Grados a añadir (puede ser negativo).</param>
        public void Rotate(float degrees)
        {
            Rotation += degrees;
        }

        /// <summary>
        /// Añade un desplazamiento a la traslación actual.
        /// </summary>
        /// <param name="dx">Cambio en X.</param>
        /// <param name="dy">Cambio en Y.</param>
        public void Translate(float dx, float dy)
        {
            Translation = new PointF(Translation.X + dx, Translation.Y + dy);
        }

        /// <summary>
        /// Establece la escala a un valor absoluto.
        /// Incluye una protección para evitar valores de 0 o negativos.
        /// </summary>
        /// <param name="newScale">El nuevo factor de escala (ej: 1.5 = 150%).</param>
        public void SetScale(float newScale)
        {
            // Protección contra el error 'Parámetro no válido'
            if (newScale < 0.01f)
            {
                Scale = 0.01f;
            }
            else
            {
                Scale = newScale;
            }
        }

        /// <summary>
        /// Multiplica la escala actual por un factor (para la rueda del ratón).
        /// </summary>
        /// <param name="factor">Factor por el cual multiplicar (ej: 1.1).</param>
        public void AdjustScale(float factor)
        {
            // Llama a SetScale para que la lógica de protección se aplique aquí también
            SetScale(Scale * factor);
        }

        /// <summary>
        /// Resetea todas las transformaciones a sus valores por defecto.
        /// </summary>
        public void Reset()
        {
            Rotation = 0f;
            Scale = 1.0f;
            Translation = PointF.Empty;
        }

        /// <summary>
        /// Aplica todas las transformaciones almacenadas a un objeto Graphics.
        /// </summary>
        /// <param name="g">El lienzo de gráficos donde se va a dibujar.</param>
        public void ApplyTransforms(Graphics g)
        {
            // El orden es crucial:
            // 1. Mover al pivote + traslación
            g.TranslateTransform(Pivot.X + Translation.X, Pivot.Y + Translation.Y);
            // 2. Rotar sobre ese nuevo punto
            g.RotateTransform(Rotation);
            // 3. Escalar sobre ese nuevo punto
            g.ScaleTransform(Scale, Scale);
        }
    }
}