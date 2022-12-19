using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public partial class VerFactura : Form
    {
        public VerFactura(int idVenta)
        {
            InitializeComponent();
            picBox.Load(Environment.CurrentDirectory + @"\Facturas\" + "Factura_" + idVenta + ".jpg");
        }
    }
}
