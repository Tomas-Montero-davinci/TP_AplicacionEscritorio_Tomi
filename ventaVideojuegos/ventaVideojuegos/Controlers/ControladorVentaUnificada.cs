using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Listas;
using ventaVideojuegos.Modelo;


namespace ventaVideojuegos.Controlers
{
    public class ControladorVentaUnificada
    {

        public static List<VentaUnificada> VentasUnificadas { get; set; }

        public static void IniciarRepositorio()
        {
            VentasUnificadas = new List<VentaUnificada>();

            if (!File.Exists("ventaUnificada.txt"))
            {
                StreamWriter archivo = new StreamWriter("ventaUnificada.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("ventaUnificada.txt");
                while (!archivo.EndOfStream)
                {
                    string ventaU = archivo.ReadLine();
                    string[] datos = ventaU.Split(',');
                    VentaUnificada vtaU = new VentaUnificada()
                    {
                        Id = int.Parse(datos[0]),
                        nombreCliente = datos[1],
                        nombreEmpleado = datos[2],
                        valorTotal = int.Parse(datos[3]),
                        DateTime = DateTime.Parse(datos[4])
                    };
                    VentasUnificadas.Add(vtaU);

                }
                archivo.Close();
            }

        }

        public static void AñadirVentaUnificada(VentaUnificada vtaU)
        {
            VentasUnificadas.Add(vtaU);
            GuardarEnMemoria(vtaU);
        }

        private static void GuardarEnMemoria(VentaUnificada vtaU)
        {
            StreamWriter archivo = new StreamWriter("ventaUnificada.txt", true);
            archivo.WriteLine(vtaU.Id + "," + vtaU.nombreEmpleado + "," + vtaU.nombreCliente +  "," + vtaU.valorTotal + "," + vtaU.DateTime);
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("ventaUnificada.txt");
            foreach (VentaUnificada vtaU in VentasUnificadas)
            {
                archivo.WriteLine(vtaU.Id + "," + vtaU.nombreEmpleado + "," + vtaU.nombreCliente + "," + vtaU.valorTotal + "," + vtaU.DateTime);
            }
            archivo.Close();
        }


        public static List<VentaUnificada> GetVentaUnificadaById(int id)
        {
            List<VentaUnificada> listaVentasDeUnId = VentasUnificadas.FindAll(x => x.Id == id);
            return listaVentasDeUnId;
        }



        public static ListaVentaUnificada ListaVentaUnificada
        {
            get
            {
                if (_listaVtaU == null)
                {
                    _listaVtaU = new ListaVentaUnificada();

                    if (!File.Exists("ventaUnificada.txt"))
                    {
                        StreamWriter archivoNuevo = new StreamWriter("ventaUnificada.txt");
                        archivoNuevo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("ventaUnificada.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombrecliente = archivo.ReadLine();
                            string nombreempleado = archivo.ReadLine();
                            string valortotal = archivo.ReadLine();
                            string datetime = archivo.ReadLine();


                            VentaUnificada vtaU = new VentaUnificada()
                            {
                                Id = int.Parse(id),
                                nombreCliente = nombrecliente,
                                nombreEmpleado = nombreempleado,
                                valorTotal = int.Parse(valortotal),
                                DateTime = DateTime.Parse(datetime),


                            };

                            _listaVtaU.GuardarEnInstancia(vtaU);
                        }
                        archivo.Close();
                    }

                }
                return _listaVtaU;
            }
        }

        private static ListaVentaUnificada _listaVtaU;


    }
}
