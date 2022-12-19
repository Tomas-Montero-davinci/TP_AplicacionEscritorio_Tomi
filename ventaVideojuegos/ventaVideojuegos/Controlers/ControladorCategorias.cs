using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ControladorCategorias
    {
        public static List<Categoria> Categorias { get; set; }
        public static int lastId = 0;


        public static void IniciarRepositorio()
        {
            Categorias = new List<Categoria>();

            if (!File.Exists("categorias.txt"))
            {
                StreamWriter archivo = new StreamWriter("categorias.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("categorias.txt");
                while (!archivo.EndOfStream)
                {
                    string categoria = archivo.ReadLine();
                    string[] datos = categoria.Split(',');
                    Categoria cat = new Categoria()
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1],
                        Vista = bool.Parse(datos[2])
                    };
                    Categorias.Add(cat);
                    lastId = int.Parse(datos[0]);


                }
                archivo.Close();
            }

        }
        

        public static void AñadirCategoria(Categoria cat)
        {
            Categorias.Add(cat);
            lastId++;
            GuardarEnMemoria(cat);
        }

        //Funcion que añade categorias a la DB
        public static void AñadirCategoriaDB(Categoria cat)
        {

            Conexion.Conectar();
            string consulta = "Use tienda; insert into Categoria (Nombre,Visible) values (@nombre,@visible)";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@nombre", cat.Nombre);
            cmd.Parameters.AddWithValue("@visible", cat.Vista);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }

        }


        public static Categoria GetCategoriaByName(string name)
        {
            Categoria cat = Categorias.FirstOrDefault(x => x.Nombre == name);
            return cat;
        }

        public static Categoria GetCategoriaById(int id)
        {
            Categoria cat = Categorias.FirstOrDefault(x => x.Id == id);
            return cat;
        }

        public static void EliminarCategoria(int id)
        {
            Categoria cat = Categorias.FirstOrDefault(c => c.Id == id);
            cat.Vista = false;
            ActualizarCategoria(id, cat);

        }

        //eliminar categoria en la DB cambia la vista de 1 a 0
        public static void EliminarCategoriaDB(int Id)
        {

            Conexion.Conectar();
            string consulta = "Use tienda; update Categoria set Visible='0' where IdCategoria = @id;";
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

        // trae la categoria solicitada mediante un id desde la base de datos
        public static Categoria GetOne(int Id)
        {
            Conexion.Conectar();
            string query = "use tienda; select * from Categoria where IdCategoria = @id";
            SqlCommand cmd = new SqlCommand(query, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", Id);

            try
            {
                Categoria cat = new Categoria();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cat.Id = reader.GetInt32(0);
                    cat.Nombre = reader.GetString(1);
                    cat.Vista = reader.GetBoolean(2);
                }
                reader.Close();

                return cat;
            }

            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }


        public static void ActualizarCategoria(int id, Categoria cat)
        {
            int index = Categorias.FindIndex(e => e.Id.Equals(id));
            if (index != -1)
            {
                Categorias[index] = cat;
            }
            GuardarEnMemoriaLista();
        }

        // actualiza la consola en la DB mediante una consulta update
        public static void ActualizarCategoriaDB(int idcategoria, Categoria cat)
        {
            Conexion.Conectar();
            string consulta = "Use tienda; update Categoria set Nombre = @nombre, Visible=@visible where IdCategoria = @id;";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", idcategoria);
            cmd.Parameters.AddWithValue("@nombre", cat.Nombre);
            cmd.Parameters.AddWithValue("@visible", cat.Vista);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }

        private static void GuardarEnMemoria(Categoria cat)
        {
            StreamWriter archivo = new StreamWriter("categorias.txt", true);
            archivo.WriteLine(cat.Id + "," + cat.Nombre + "," + cat.Vista);
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("categorias.txt");
            foreach (Categoria cat in Categorias)
            {
                archivo.WriteLine(cat.Id + "," + cat.Nombre + "," + cat.Vista);
            }
            archivo.Close();
        }

        public static ListaCategoria ListaCategoria
        {
            get
            {
                if (_listaCat == null)
                {
                    _listaCat = new ListaCategoria();

                    if (!File.Exists("categorias.txt"))
                    {
                        StreamWriter archivoNuevo = new StreamWriter("categorias.txt");
                        archivoNuevo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("categorias.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombre = archivo.ReadLine();
                            string vista = archivo.ReadLine();


                            Categoria cat = new Categoria()
                            {
                                Id = int.Parse(id),
                                Nombre = nombre,
                                Vista = bool.Parse(vista)
                            };

                            _listaCat.GuardarEnInstancia(cat);
                        }
                        archivo.Close();
                    }

                }
                return _listaCat;
            }
        }

        private static ListaCategoria _listaCat;
    }
}
