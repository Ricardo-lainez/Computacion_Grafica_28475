using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Poligonos : Form
    {
        public Poligonos()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double cantidadDeLados = double.Parse(txtCantidadDeLados.Text);
                double longitudDeLado = double.Parse(txtLongitudDeLado.Text);
                double resultado, apotema, perimetro, angulo, radianes;

                if (cantidadDeLados <= 4 || longitudDeLado <= 0)
                {
                    MessageBox.Show("El poligono debe ser mayor a 5 lados o su longitud mayor que 0");
                }
                else
                {
                    perimetro = calcularPerimetro(cantidadDeLados, longitudDeLado);
                    angulo = 360 / (2 * cantidadDeLados);
                    radianes = gradosARadianes(angulo);
                    apotema = longitudDeLado / (2 * Math.Tan(radianes));
                    resultado = (perimetro * apotema)/2;
                    MessageBox.Show("El area del poligono es: " + resultado);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese numeros validos");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double cantidadDeLados = double.Parse(txtCantidadDeLados.Text);
                double longitudDeLado = double.Parse(txtLongitudDeLado.Text);
                double resultado;

                if (cantidadDeLados<=4 || longitudDeLado<=0)
                {
                    MessageBox.Show("El poligono debe ser mayor a 5 lados o su longitud mayor que 0");
                }
                else
                {
                    resultado = calcularPerimetro(cantidadDeLados, longitudDeLado);
                    MessageBox.Show("el valor del perimetro es: " + resultado);
                }
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese numeros validos");
            }
        }

        private double calcularPerimetro(double cantidad, double longitud)
        {
            return cantidad * longitud;
        }
        private double gradosARadianes(double angulo)
        {
            double radianes = angulo * (2 * Math.PI / (360));
            return radianes;
        }
    }
}
