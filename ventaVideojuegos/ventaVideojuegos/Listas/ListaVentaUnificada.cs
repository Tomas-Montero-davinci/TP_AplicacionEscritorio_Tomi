using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos.Listas
{
    public class ListaVentaUnificada
    {

        List<VentaUnificada> listaVtaUnificada = new List<VentaUnificada>();

        public void GuardarEnInstancia(VentaUnificada vtaU)
        {
            listaVtaUnificada.Add(vtaU);
        }

        public void GuardarEnMemoria(VentaUnificada vtaU)
        {
            StreamWriter archivo = new StreamWriter("ventaUnificada.txt");
            archivo.WriteLine(vtaU.Id);
            archivo.WriteLine(vtaU.nombreCliente);
            archivo.WriteLine(vtaU.nombreEmpleado);
            archivo.WriteLine(vtaU.valorTotal);
            archivo.WriteLine(vtaU.DateTime);
            archivo.Close();
        }

        public List<VentaUnificada> Consultar()
        {
            return listaVtaUnificada;
        }
    }
}

