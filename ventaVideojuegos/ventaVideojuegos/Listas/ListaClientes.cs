using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ListaClientes
    {

        List<Cliente> lista = new List<Cliente>();

        public void GuardarEnInstancia(Cliente cte)
        {
            lista.Add(cte);
        }

        public void GuardarEnMemoria(Cliente cte)
        {
            StreamWriter archivo = new StreamWriter("clientes.txt");
            archivo.WriteLine(cte.Id);
            archivo.WriteLine(cte.Nombre);
            archivo.WriteLine(cte.Apellido);
            archivo.WriteLine(cte.NUsuario);
            archivo.WriteLine(cte.Email);
           // archivo.WriteLine(cte.Contrasena);
            archivo.WriteLine(cte.Vista);
            archivo.Close();
        }

        public List<Cliente> consular()
        {
            return lista;
        }

    }
}
