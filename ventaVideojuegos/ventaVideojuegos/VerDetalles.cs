using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Controlers;
using ventaVideojuegos.Modelo;
using ventaVideojuegos.UsersControls;

namespace ventaVideojuegos
{
    public partial class VerDetalles : Form
    {
       
        public VerDetalles(int idVenta)
        {
            
            InitializeComponent();
            lblVenta.Text = lblVenta.Text + " " + idVenta;
            verProductosVendidos(idVenta);
        }

        
        public void verProductosVendidos(int idVenta)
        {
          

            foreach(Venta vta in ControladorVentas.Ventas)
            {
                if(idVenta == vta.Id)
                {

                    int rowIndex = dataGridViewV.Rows.Add();
                    dataGridViewV.Rows[rowIndex].Cells[0].Value = vta.nombreProducto.ToString();
                    dataGridViewV.Rows[rowIndex].Cells[1].Value = vta.precioProducto.ToString();
                    dataGridViewV.Rows[rowIndex].Cells[2].Value = vta.cantidadProducto.ToString();
                    dataGridViewV.Rows[rowIndex].Cells[3].Value = vta.valorTotal.ToString();
                }
            }
        }

        private void btnCerrarDetails_Click(object sender, EventArgs e)
        {
            
            dataGridViewV.Rows.Clear();
            this.Close();

        }

    }
}
