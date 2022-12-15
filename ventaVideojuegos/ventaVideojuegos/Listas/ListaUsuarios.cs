using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ListaUsuarios
    {

        List<Usuario> lista = new List<Usuario>();

        public void GuardarEnInstancia(Usuario user)
        {
            lista.Add(user);
        }

        public void GuardarEnMemoria(Usuario user)
        {
            StreamWriter archivo = new StreamWriter("usuarios.txt");
            archivo.WriteLine(user.Id);
            archivo.WriteLine(user.Nombre);
            archivo.WriteLine(user.Contrasena);
            archivo.WriteLine(user.EsAdmin);
            archivo.Close();
        }

        public List<Usuario> consultar()
        {
            return lista;
        }
    }
}
