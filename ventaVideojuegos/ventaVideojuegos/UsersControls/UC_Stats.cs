using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Controlers;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos.UsersControls
{
    public partial class UC_Stats : UserControl
    {
        public UC_Stats()
        {
            InitializeComponent();
            ControladorVentas.IniciarRepositorio();
            ControladorClientes.IniciarRepositorio();
            ControladorProductos.IniciarRepositorio();
            controladorUsuarios.IniciarRepositorio();


            limpiarResultados();
            calcularProductos();
            calcularMayorStock();
            calcularMasVendido();

            calcularCantidadVentas();
            calcularRecaudacion();

            

        }

        private void limpiarResultados()
        {
            txtMasStock.Text = "";
            txtMasVendido.Text = "";
            txtProdCatalogo.Text = "";
            lblcantStockMax.Text = "";
            lblcantVentasMax.Text = "";



            txtCantVentas.Text = "";
            txtTotalRecaudado.Text = "";

            
        }

        private void calcularProductos()
        {
            int cantidadProds = 0;

            foreach (Producto prod in ControladorProductos.Productos)
            {
                if(prod.Vista == true)
                {
                    cantidadProds++;
                }
            }

            txtProdCatalogo.Text = cantidadProds.ToString();
        }

        private void calcularMayorStock()
        {
            int mayor = 0;
            string nombreProd = "";

            foreach (Producto prod in ControladorProductos.Productos)
            {
                if (prod.Vista == true)
                {
                    if(prod.Stock > mayor)
                    {
                        mayor = prod.Stock;
                        nombreProd = prod.Nombre;
                    }   
                }
            }

            txtMasStock.Text = nombreProd;
            lblcantStockMax.Text = "(" + mayor.ToString() + ")";
        }

        private void calcularMasVendido()
        {
            
            string nombreProd = "";
            int cantVentas ;
            int vtaTotales = 0;
            int vtasMax = 0;

            foreach (Producto prod in ControladorProductos.Productos)
            {

                    foreach (Venta vta in ControladorVentas.Ventas)
                    {
                        if (prod.Nombre == vta.nombreProducto)
                        {
                            cantVentas = vta.cantidadProducto;
                            vtaTotales = vtaTotales + cantVentas;

                            if(vtasMax < vtaTotales)
                            {
                                vtasMax = vtaTotales;
                                nombreProd = prod.Nombre;
                                vtaTotales = 0;
                                
                            }
                            else
                            {
                                vtaTotales = 0;
                            }

                        }
                    }
            }

            txtMasVendido.Text = nombreProd;
            lblcantVentasMax.Text = "(" + vtasMax + ")";
        }

        private void calcularRecaudacion()
        {
            int totalRecaudado = 0;

            foreach (Venta vta in ControladorVentas.Ventas)
            {
                totalRecaudado = totalRecaudado + vta.valorTotal;
            }

            txtTotalRecaudado.Text = totalRecaudado.ToString();

        }

        private void calcularCantidadVentas()
        {
            int idVenta = 0;
            int cantidadVentas = 0;

            foreach (Venta vta in ControladorVentas.Ventas)
            {
                if(vta.Id <= idVenta)
                {

                }
                else
                {
                    cantidadVentas++;
                    idVenta = vta.Id;
                }
            }

            txtCantVentas.Text = cantidadVentas.ToString();
        }

    }
}
