using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public partial class FormConsola : Form
    {

        public Consola consolaNueva;
        public FormConsola()
        {
            InitializeComponent();
            limpiarErrores();
            llenarBoxEstado();
            txtID.Text = (ControladorConsola.lastId + 1).ToString();
            boxEstado.Text = "True";
        }

        public FormConsola(Consola con)
        {
            InitializeComponent();
            limpiarErrores();
            llenarBoxEstado();
            txtID.Text = con.Id.ToString();
            txtNombre.Text = con.Nombre.ToString();
            boxEstado.Text = con.Vista.ToString();
        }

        private void limpiarErrores()
        {
            errNombre.Text = "";
            errNombre.Hide();
        }

        private void GuardarConsola()
        {
            Consola con = new Consola()
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                Vista = bool.Parse(boxEstado.Text)

            };

            ListaConsola lista = ControladorConsola.ListaConsola;
            lista.GuardarEnInstancia(con);
            lista.GuardarEnMemoria(con);

        }

        private bool ValidarConsola(out bool errorMsg)
        {

            errorMsg = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorMsg = false;
                string error = "Debe ingresar el nombre";
                errNombre.Text = error;
                errNombre.Show();

            }
            return errorMsg;
        }


        private void Aceptar_Click_1(object sender, EventArgs e)
        {
            bool consolaValidada = ValidarConsola(out bool errorMsg);

            if (consolaValidada)
            {
                consolaNueva = new Consola()
                {
                    Id = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Vista = bool.Parse(boxEstado.Text)
                    
                };

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    this.DialogResult = DialogResult.Cancel;
            }

        }

        private void llenarBoxEstado()
        {
            boxEstado.Items.Add("True");
            boxEstado.Items.Add("False");

        }
    }
}
