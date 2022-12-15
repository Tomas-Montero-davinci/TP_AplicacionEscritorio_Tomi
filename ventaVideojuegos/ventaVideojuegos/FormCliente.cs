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

namespace ventaVideojuegos
{
    public partial class FormCliente : Form
    {
        public Cliente clienteNuevo;

        public FormCliente()
        {
            InitializeComponent();
            limpiarErrores();
            llenarBoxEstado();
            txtId.Text = (ControladorClientes.lastId + 1).ToString();
            boxEstado.Text = "True";
        }

        public FormCliente(Cliente cte)
        {
            InitializeComponent();
            limpiarErrores();
            llenarBoxEstado();
            txtId.Text = cte.Id.ToString();
            txtNombre.Text = cte.Nombre.ToString();
            txtApellido.Text = cte.Apellido.ToString();
            txtUsuario.Text = cte.NUsuario.ToString();
            txtEmail.Text = cte.Email.ToString();
            boxEstado.Text = cte.Vista.ToString();
        }

        private void GuardarCliente()
        {
            Cliente cte = new Cliente()
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                NUsuario = txtUsuario.Text,
                Email = txtEmail.Text,
                Vista = bool.Parse(boxEstado.Text)
            };

            ListaClientes lista = ControladorClientes.ListaCliente;
            lista.GuardarEnInstancia(cte);
            lista.GuardarEnMemoria(cte);

        }

        private void limpiarErrores()
        {
            errNombre.Text = "";
            errApellido.Text = "";
            errEmail.Text = "";
            errUsuario.Text = "";

            errNombre.Hide();
            errApellido.Hide();
            errEmail.Hide();
            errUsuario.Hide();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool clienteValidado = ValidarCliente(out bool errorMsg);
            
            if(clienteValidado)
            {
                clienteNuevo = new Cliente()
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    NUsuario = txtUsuario.Text,
                    Email = txtEmail.Text,
                    Vista = bool.Parse(boxEstado.Text)
                };
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //
                //
            }
        }

        private bool ValidarCliente(out bool errorMsg)
        {
            errorMsg = true;

            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                string error = "Debe ingresar el nombre";
                errNombre.Text = error;
                errNombre.Show();
                errorMsg = false;
            }
            else
            {
                errNombre.Hide();
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                string error = "Debe ingresar el apellido";
                errApellido.Text = error;
                errApellido.Show();
                errorMsg = false;
            }
            else
            {
                errApellido.Hide();
            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                string error = "Debe ingresar el usuario";
                errUsuario.Text = error;
                errUsuario.Show();
                errorMsg = false;
            }
            else
            {
                errUsuario.Hide();
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                string error = "Debe ingresar el email";
                errEmail.Text = error;
                errEmail.Show();
                errorMsg = false;
            }
            else
            {
                errEmail.Hide();
            }

            return errorMsg;
        }

        private void llenarBoxEstado()
        {
            boxEstado.Items.Add("True");
            boxEstado.Items.Add("False");

        }
    }
}
