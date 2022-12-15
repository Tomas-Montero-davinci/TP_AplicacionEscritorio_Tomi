using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ListaVenta
    {

        List<Venta> listaVta = new List<Venta>();

        public void GuardarEnInstancia(Venta vta)
        {
            listaVta.Add(vta);
        }

        public void GuardarEnMemoria(Venta vta)
        {
            StreamWriter archivo = new StreamWriter("ventas.txt");
            archivo.WriteLine(vta.Id);
            archivo.WriteLine(vta.nombreCliente);
            archivo.WriteLine(vta.nombreEmpleado);
            archivo.WriteLine(vta.nombreProducto);
            archivo.WriteLine(vta.precioProducto);
            archivo.WriteLine(vta.cantidadProducto);
            archivo.WriteLine(vta.valorTotal);
            archivo.WriteLine(vta.DateTime);
            archivo.Close();
        }

        public List<Venta> Consultar()
        {
            return listaVta;
        }
    }
}
