using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class Venta
    {
        public int Id { get; set; }
        public string nombreCliente { get; set; }   
        public string nombreEmpleado { get; set; }  
        public string nombreProducto { get; set; }
        public int precioProducto { get; set; }
        public int cantidadProducto { get; set; }
        public int valorTotal { get; set; }
        public DateTime DateTime { get; set; }
    }
}
