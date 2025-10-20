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
    public partial class Trapecio : Form
    {
        public Trapecio()
        {
            InitializeComponent();
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double baseMenorTrapecio = double.Parse(txtBaseMenorTrapecio.Text);
                double baseMayorTrapecio = double.Parse(txtBaseMayorTrapecio.Text);
                double alturaTrapecio = double.Parse(txtAlturaTrapecio.Text);

                if(baseMenorTrapecio<=0 || baseMayorTrapecio<=0 || alturaTrapecio <= 0)
                {
                    MessageBox.Show("la base menor, mayor o la altura deben ser mayores que 0");
                }
                else
                {
                    MessageBox.Show("el area del trapecio es: " + (alturaTrapecio * ((baseMenorTrapecio + baseMayorTrapecio) / 2)));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresar un numero valido");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double baseMenorTrapecio = double.Parse(txtBaseMenorTrapecio.Text);
                double baseMayorTrapecio = double.Parse(txtBaseMayorTrapecio.Text);
                double alturaTrapecio = double.Parse(txtAlturaTrapecio.Text);

                double lado = calculoLado(baseMenorTrapecio, baseMayorTrapecio, alturaTrapecio);

                if (baseMenorTrapecio<=0 || baseMayorTrapecio<=0 || alturaTrapecio<=0 || lado <= 0)
                {
                    MessageBox.Show("la base menor, mayor, altura o el lado deben ser mayor a 0");
                }
                else
                {
                    double resultado;
                    resultado = 2*lado + baseMenorTrapecio + baseMayorTrapecio;
                    MessageBox.Show("El perimetro del trapecio es: " + resultado);
                }                
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }

        private double calculoLado(double baseMenor, double baseMayor, double altura)
        {
            double catetoBase = (baseMayor - baseMenor)/2;
            double lado = Math.Sqrt((Math.Pow(altura, 2) + Math.Pow(catetoBase, 2)));
            return lado;
        }

        private void btnCalcularAreaRE_Click(object sender, EventArgs e)
        {
            try
            {
                double baseMenorTrapecioRE = double.Parse(txtBaseMenorTrapecioRE.Text);
                double baseMayorTrapecioRE = double.Parse(txtBaseMayorTrapecioRE.Text);
                double alturaTrapecioRE = double.Parse(txtAlturaTrapecioRE.Text);
                double ladoIzqTrapecioRE = double.Parse(txtLadoIzqTrapecioRE.Text);
                double ladoDerTrapecioRE = double.Parse(txtLadoDerTrapecioRE.Text);
                double resultado;

                resultado = alturaTrapecioRE * ((baseMayorTrapecioRE + baseMenorTrapecioRE) / 2);

                if (baseMayorTrapecioRE<=0 || baseMenorTrapecioRE<=0
                    || alturaTrapecioRE<=0 || ladoDerTrapecioRE<=0 || ladoIzqTrapecioRE<=0)
                {
                    MessageBox.Show("los datos del trapecio deben ser mayores a 0");
                }
                else
                {
                    MessageBox.Show("El area del trapecio es: " + resultado);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }

        private void btnCalcularPerimetroRE_Click(object sender, EventArgs e)
        {
            try
            {
                double baseMenorTrapecioRE = double.Parse(txtBaseMenorTrapecioRE.Text);
                double baseMayorTrapecioRE = double.Parse(txtBaseMayorTrapecioRE.Text);
                double ladoIzqTrapecioRE = double.Parse(txtLadoIzqTrapecioRE.Text);
                double ladoDerTrapecioRE = double.Parse(txtLadoDerTrapecioRE.Text);
                double resultado;

                resultado = baseMayorTrapecioRE + baseMenorTrapecioRE +
                            ladoDerTrapecioRE + ladoIzqTrapecioRE;

                if (baseMayorTrapecioRE <= 0 || baseMenorTrapecioRE <= 0
                    || ladoDerTrapecioRE <= 0 || ladoIzqTrapecioRE <= 0)
                {
                    MessageBox.Show("los datos del trapecio deben ser mayor que 0");
                }
                else
                {
                    MessageBox.Show("El perimetro del trapecio es: " + resultado);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese numeros validos");
            }
        }
    }
}
