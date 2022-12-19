using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            if (!File.Exists("clientes.txt"))
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

        //Funcion que añade categorias a la DB
        public static void AñadirClienteDB(Cliente cte)
        {

            Conexion.Conectar();
            string consulta = "Use tienda; insert into Cliente (Nombre,Apellido,NombreUsuario,Email,Visible) values (@nombre,@apellido,@nombreUsuario,@email,@visible);";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@nombre", cte.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cte.Nombre);
            cmd.Parameters.AddWithValue("@nombreUsuario", cte.Nombre);
            cmd.Parameters.AddWithValue("@email", cte.Nombre);
            cmd.Parameters.AddWithValue("@visible", cte.Vista);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }

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


        // actualiza la consola en la DB mediante una consulta update
        public static void ActualizarClienteDB(int idcategoria, Cliente cte)
        {
            Conexion.Conectar();
            string consulta = "Use tienda; update Cliente set Nombre = @nombre,Apellido=@apellido,NombreUsuario=@nombreUsuario,Email=@email, Visible=@visible where IdCliente = @id;";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", idcategoria);
            cmd.Parameters.AddWithValue("@nombre", cte.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cte.Apellido);
            cmd.Parameters.AddWithValue("@nombreUsuario", cte.NUsuario);
            cmd.Parameters.AddWithValue("@email", cte.Email);
            cmd.Parameters.AddWithValue("@visible", cte.Vista);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }

        public static void EliminarCliente(int id)
        {
            Cliente cte = Clientes.FirstOrDefault(c => c.Id == id);
            cte.Vista = false;
            ActualizarCliente(id, cte);
        }

        //eliminar categoria en la DB cambia la vista de 1 a 0
        public static void EliminarClienteDB(int Id)
        {

            Conexion.Conectar();
            string consulta = "Use tienda; update Cliente set Visible='0' where IdCliente = @id;";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", Id);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }

        }

        // trae el cliente solicitado mediante un id desde la base de datos
        public static Cliente GetOne(int Id)
        {
            Conexion.Conectar();
            string query = "use tienda; select * from Cliente where IdCliente = @id";
            SqlCommand cmd = new SqlCommand(query, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", Id);

            try
            {
                Cliente cte = new Cliente();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cte.Id = reader.GetInt32(0);
                    cte.Nombre = reader.GetString(1);
                    cte.Apellido = reader.GetString(2);
                    cte.NUsuario = reader.GetString(3);
                    cte.Email = reader.GetString(4);
                    cte.Vista = reader.GetBoolean(5);
                }
                reader.Close();

                return cte;
            }

            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }

        public static void GuardarEnMemoria(Cliente cte)
        {
            StreamWriter archivo = new StreamWriter("clientes.txt", true);
            archivo.WriteLine(cte.Id + "," + cte.Nombre + "," + cte.Apellido + "," + cte.NUsuario + "," + cte.Email + /*","  + cte.Contrasena + */  "," + cte.Vista);
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

                    if (!File.Exists("clientes.txt"))
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
