using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class VentaUnificada
    {
        public int Id { get; set; }
        public string nombreCliente { get; set; }
        public string nombreEmpleado { get; set; }
        public int valorTotal { get; set; }
        public DateTime DateTime { get; set; }

    }
}

