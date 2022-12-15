using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos.Controlers
{
    public class ControladorClientes
    {

        public static List<Cliente> Clientes { get; set; }
        public static int lastId = 0;

        public static void IniciarRepositorio()
        {
            Clientes = new List<Cliente>();

            if(!File.Exists("clientes.txt"))
            {
                StreamWriter archivo = new StreamWriter("clientes.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("clientes.txt");
                while (!archivo.EndOfStream)
                {
                    string cliente = archivo.ReadLine();
                    string[] datos = cliente.Split(',');
                    Cliente cte = new Cliente()
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1],
                        Apellido = datos[2],
                        NUsuario = datos[3],
                        Email = datos[4],
                       // Contrasena = datos[5],
                        Vista = bool.Parse(datos[5])
                    };

                    lastId = int.Parse(datos[0]);
                    Clientes.Add(cte);
                }
                archivo.Close();
            }
        }

        public static void AñadirCliente(Cliente cte)
        {
            Clientes.Add(cte);
            lastId++;
            GuardarEnMemoria(cte);
        }

        public static void ActualizarCliente(int id, Cliente cte)
        {
            int index = Clientes.FindIndex(e => e.Id.Equals(id));
            if (index != -1)
            {
                Clientes[index] = cte;
            }
            GuardarEnMemoriaLista();
        }

        public static void EliminarCliente(int id)
        {
            Cliente cte = Clientes.FirstOrDefault(c => c.Id == id);
            cte.Vista = false;
            ActualizarCliente(id, cte);
        }

        public static void GuardarEnMemoria(Cliente cte)
        {
            StreamWriter archivo = new StreamWriter("clientes.txt", true);
            archivo.WriteLine(cte.Id + "," + cte.Nombre + "," + cte.Apellido + "," + cte.NUsuario + "," +cte.Email + /*","  + cte.Contrasena + */  "," + cte.Vista);
            archivo.Close();
        }

        public static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("clientes.txt");

            foreach (Cliente cte in Clientes)
            {
                archivo.WriteLine(cte.Id + "," + cte.Nombre + "," + cte.Apellido + "," + cte.NUsuario + "," + cte.Email + "," /* + cte.Contrasena + "," */  + cte.Vista);
                archivo.Close();
            }
        }

        public static ListaClientes ListaCliente
        {
            get
            {
                if (_lista == null)
                {
                    _lista = new ListaClientes();
                    
                    if(!File.Exists("clientes.txt"))
                    {
                        StreamWriter archivo = new StreamWriter("clientes.txt");
                        archivo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("clientes.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombre = archivo.ReadLine();
                            string apellido = archivo.ReadLine();
                            string nusuario = archivo.ReadLine();
                            string email = archivo.ReadLine();
                           // string contrasena = archivo.ReadLine();
                            string vista = archivo.ReadLine();

                            Cliente cte = new Cliente()
                            {
                                Id = int.Parse(id),
                                Nombre = nombre,
                                Apellido = apellido,
                                NUsuario = nusuario,
                                Email = email,
                             //   Contrasena = contrasena,
                                Vista = bool.Parse(vista)
                            };
                            _lista.GuardarEnInstancia(cte);
                        }
                        archivo.Close();
                    }
                }
                return _lista;
            }
        }
        private static ListaClientes _lista;



    }
}
