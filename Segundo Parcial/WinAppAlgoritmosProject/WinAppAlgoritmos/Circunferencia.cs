using System;
using System.Windows.Forms;
using Algoritmos; // Agregar para acceder a las clases de relleno

namespace WinAppAlgoritmos
{
    public partial class Circunferencia : Form
    {
        private CCircunferencia ObjCircunferencia = new CCircunferencia();
        
        // Instancias de las clases de relleno
        private CFloodFill objFloodFill = new CFloodFill();
        private CBoundaryFill objBoundaryFill = new CBoundaryFill();
        private CScanLineFill objScanLineFill = new CScanLineFill();

        public Circunferencia()
        {
            InitializeComponent();
            if (ptbGrafica != null)
                ptbGrafica.BackColor = System.Drawing.Color.White;

            ConfigurarValidaciones();
            
            // Suscribir el evento MouseClick del PictureBox
            ptbGrafica.MouseClick += PtbGrafica_MouseClick;
        }

        private void PtbGrafica_MouseClick(object sender, MouseEventArgs e)
        {
            // Delegar el evento a Flood Fill si está esperando un clic
            if (objFloodFill.EstaEsperandoClick())
            {
                objFloodFill.OnPictureBoxClick(sender, e, ptbGrafica);
            }
            // Delegar el evento a Boundary Fill si está esperando un clic
            else if (objBoundaryFill.EstaEsperandoClick())
            {
                objBoundaryFill.OnPictureBoxClick(sender, e, ptbGrafica);
            }
            // Delegar el evento a Scan Line Fill si está esperando un clic
            else if (objScanLineFill.EstaEsperandoClick())
            {
                objScanLineFill.OnPictureBoxClick(sender, e, ptbGrafica);
            }
        }

        private void ConfigurarValidaciones()
        {
            txtRadio.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Circunferencia_Load(object sender, EventArgs e)
        {
            ObjCircunferencia.InitializeData(txtRadio, ptbGrafica);

            int maxRadius = Math.Min((ptbGrafica.Width / 5) / 2, (ptbGrafica.Height / 5) / 2) - 1;
            this.Text = $"Circunferencia - Radio máximo: {maxRadius}";
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (ObjCircunferencia.ReadData(txtRadio, ptbGrafica))
            {
                ObjCircunferencia.CalculateCircle(ptbGrafica);
                ObjCircunferencia.DrawComplete(ptbGrafica);
            }
        }

        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            // Activar modo de selección de punto para Flood Fill
            objFloodFill.ActivarSeleccionPunto(ptbGrafica);
        }

        private void btnBoundaryFill_Click(object sender, EventArgs e)
        {
            // Activar modo de selección de punto para Boundary Fill
            objBoundaryFill.ActivarSeleccionPunto(ptbGrafica);
        }

        private void btnScanLineFill_Click(object sender, EventArgs e)
        {
            // Activar modo de selección de punto para Scan Line Fill
            objScanLineFill.ActivarSeleccionPunto(ptbGrafica);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancelar cualquier selección pendiente al cerrar el formulario
            objFloodFill.CancelarSeleccion(ptbGrafica);
            objBoundaryFill.CancelarSeleccion(ptbGrafica);
            objScanLineFill.CancelarSeleccion(ptbGrafica);
            base.OnFormClosing(e);
        }
    }
}
