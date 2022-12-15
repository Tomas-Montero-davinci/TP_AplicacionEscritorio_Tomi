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
    public partial class FormCategoria : Form
    {

        public Categoria categoriaNueva;
        public FormCategoria()
        {
            InitializeComponent();
            limpiarErrores();
            llenarBoxEstado();
            txtID.Text = (ControladorCategorias.lastId + 1).ToString();
            boxEstado.Text = "True";
        }

        public FormCategoria(Categoria cat)
        {
            InitializeComponent();
            llenarBoxEstado();
            limpiarErrores();
            txtID.Text = cat.Id.ToString();
            txtNombre.Text = cat.Nombre.ToString();
            boxEstado.Text = cat.Vista.ToString();
        }

        private void limpiarErrores()
        {
            errNombre.Text = "";
            errNombre.Hide();
        }
        private void GuardarCategoria()
        {
            Categoria cat = new Categoria()
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                Vista = bool.Parse(boxEstado.Text),

            };

            ListaCategoria lista = ControladorCategorias.ListaCategoria;
            lista.GuardarEnInstancia(cat);
            lista.GuardarEnMemoria(cat);

        }


        private bool ValidarCategoria(out bool errorMsg)
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

        private void Aceptar_Click(object sender, EventArgs e)
        {
            bool categoriaValidada = ValidarCategoria(out bool errorMsg);

            if (categoriaValidada)
            {
                categoriaNueva = new Categoria()
                {
                    Id = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Vista = bool.Parse(boxEstado.Text)
                   
                };

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // this.DialogResult = DialogResult.Cancel;
            }
        }

        private void llenarBoxEstado()
        {
            boxEstado.Items.Add("True");
            boxEstado.Items.Add("False");

        }

        private void boxConsola_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
