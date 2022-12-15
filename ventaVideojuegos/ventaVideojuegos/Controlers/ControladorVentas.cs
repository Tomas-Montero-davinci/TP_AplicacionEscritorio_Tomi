using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos.Controlers
{
    public class ControladorVentas
    {
        public static List<Venta> Ventas{ get; set; }
        public static int lastId = 0;

        public static void IniciarRepositorio()
        {
            Ventas = new List<Venta>();

            if (!File.Exists("ventas.txt"))
            {
                StreamWriter archivo = new StreamWriter("ventas.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("ventas.txt");
                while (!archivo.EndOfStream)
                {
                    string venta = archivo.ReadLine();
                    string[] datos = venta.Split(',');
                    Venta vta = new Venta()
                    {
                        Id = int.Parse(datos[0]),
                        nombreCliente = datos[1],
                        nombreEmpleado = datos[2],
                        nombreProducto = datos[3],
                        precioProducto = int.Parse(datos[4]),
                        cantidadProducto = int.Parse(datos[5]),
                        valorTotal = int.Parse(datos[6]),
                        DateTime = DateTime.Parse(datos[7])
                    };
                    Ventas.Add(vta);
                    lastId= int.Parse(datos[0]);

                }
                archivo.Close();
            }

        }

        public static void AñadirVenta(Venta vta)
        {
            Ventas.Add(vta);
            lastId++;
            GuardarEnMemoria(vta);
        }

        private static void GuardarEnMemoria(Venta vta)
        {
            StreamWriter archivo = new StreamWriter("ventas.txt", true);
            archivo.WriteLine(vta.Id + "," + vta.nombreEmpleado + "," + vta.nombreCliente + "," + vta.nombreProducto + "," + vta.precioProducto + "," + vta.cantidadProducto + "," + vta.valorTotal + "," + vta.DateTime);
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("ventas.txt");
            foreach (Venta vta in Ventas)
            {
                archivo.WriteLine(vta.Id + "," + vta.nombreEmpleado + "," + vta.nombreCliente + "," + vta.nombreProducto + "," + vta.precioProducto + "," + vta.cantidadProducto  + "," + vta.valorTotal + "," + vta.DateTime);
            }
            archivo.Close();
        }

        //metodo que busca la venta x id
        public static List<Venta> GetVentaById(int id)
        {
            List<Venta> listaVentasDeUnId = Ventas.FindAll(x => x.Id == id);
            return listaVentasDeUnId;
        }

        

        public static ListaVenta ListaVenta
        {
            get
            {
                if (_listaVta == null)
                {
                    _listaVta = new ListaVenta();

                    if (!File.Exists("ventas.txt"))
                    {
                        StreamWriter archivoNuevo = new StreamWriter("ventas.txt");
                        archivoNuevo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("ventas.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombrecliente = archivo.ReadLine();
                            string nombreempleado = archivo.ReadLine();
                            string nombreproducto = archivo.ReadLine();
                            string precioproducto = archivo.ReadLine();
                            string cantidadproducto = archivo.ReadLine();
                            string valortotal = archivo.ReadLine();
                            string datetime = archivo.ReadLine();


                            Venta vta = new Venta()
                            {
                                Id = int.Parse(id),
                                nombreCliente = nombrecliente,
                                nombreEmpleado = nombreempleado,
                                nombreProducto = nombreproducto,
                                precioProducto = int.Parse(precioproducto),
                                cantidadProducto = int.Parse(cantidadproducto),
                                valorTotal = int.Parse(valortotal),
                                DateTime = DateTime.Parse(datetime),


                            };

                            _listaVta.GuardarEnInstancia(vta);
                        }
                        archivo.Close();
                    }

                }
                return _listaVta;
            }
        }

        private static ListaVenta _listaVta;


    }
}
