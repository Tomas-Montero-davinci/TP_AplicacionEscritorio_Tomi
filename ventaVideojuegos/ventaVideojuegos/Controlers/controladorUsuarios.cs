using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos.Controlers
{
    public class controladorUsuarios
    {

        public static List<Usuario> Usuarios { get; set; }
        public static int lastId = 0;

        public static void IniciarRepositorio()
        {
            Usuarios = new List<Usuario>();

            if (!File.Exists("usuarios.txt"))
            {
                //creacion de archivo usuarios en caso de que no exista
                StreamWriter archivo = new StreamWriter("usuarios.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("usuarios.txt");
                while (!archivo.EndOfStream)
                {
                    string usuario = archivo.ReadLine();
                    string[] datos = usuario.Split(',');
                    Usuario user = new Usuario()
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1],
                        Contrasena = datos[2],
                        EsAdmin = bool.Parse(datos[3])
                    };

                    lastId = int.Parse(datos[0]);
                    Usuarios.Add(user);

                }
                archivo.Close();
            }

        }

        public static void AñadirUsuario(Usuario user)
        {
            Usuarios.Add(user);
            lastId++;
            GuardarEnMemoria(user);
        }

        public static void GuardarEnMemoria(Usuario user)
        {
            StreamWriter archivo = new StreamWriter("usuarios.txt", true);
            archivo.WriteLine(user.Id + "," + user.Nombre + "," + user.Contrasena + "," + user.EsAdmin);
            archivo.Close();
        }

        public static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("usuarios.txt");

            foreach (Usuario user in Usuarios)
            {
                archivo.WriteLine(user.Id + "," + user.Nombre + "," + user.Contrasena + "," + user.EsAdmin);
                archivo.Close();
            }
        }

        public static ListaUsuarios ListaUsuario
        {

            get
            {
                if (_lista == null)
                {
                    _lista = new ListaUsuarios();

                    if (!File.Exists("usuarios.txt"))
                    {
                        //creacion de archivo usuarios en caso de que no exista
                        StreamWriter archivo = new StreamWriter("usuarios.txt");
                        archivo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("usuarios.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombre = archivo.ReadLine();
                            string contrasena = archivo.ReadLine();
                            string esAdmin = archivo.ReadLine();

                            Usuario user = new Usuario()
                            {
                                Id = int.Parse(id),
                                Nombre = nombre,
                                Contrasena = contrasena,
                                EsAdmin = bool.Parse(esAdmin)
                            };
                            _lista.GuardarEnInstancia(user);
                        }
                        archivo.Close();
                    }
                }
                return _lista;
            }
        }
        private static ListaUsuarios _lista;
    }
}
