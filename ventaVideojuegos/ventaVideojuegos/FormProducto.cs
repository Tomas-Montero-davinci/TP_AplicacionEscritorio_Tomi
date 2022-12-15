using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public partial class FormProducto : Form
    {
        public Producto productoNuevo;
        public string filePath = string.Empty;
        public string fileName = string.Empty;
        public FormProducto()
        {
            InitializeComponent();
            limpiarErrores();
            txtId.Text = (ControladorProductos.lastId + 1).ToString();
            llenarBoxCategoria();
            llenarBoxConsola();
            llenarBoxEstado();
            boxEstado.Text = "True";
       
        }

        public FormProducto(Producto prod)
        {
            InitializeComponent();
            llenarBoxCategoria();
            llenarBoxConsola();
            limpiarErrores();
            txtId.Text = prod.Id.ToString();
            txtNombre.Text = prod.Nombre.ToString();
            txtPrecio.Text = prod.Precio.ToString();
            txtStock.Text = prod.Stock.ToString();
            boxCategoria.Text = prod.Categoria.Nombre.ToString();
            txtConexion.Text = prod.Conexion.ToString();
            boxConsola.SelectedItem = prod.Consola.Nombre.ToString();
            txtModoJuego.Text = prod.ModoJuego.ToString();
            boxEstado.Text = prod.Vista.ToString();
            txtImagen.Text = prod.Imagen.ToString();
            pictureBoxImagen.Load(Environment.CurrentDirectory + @"\Imgs\" + prod.Imagen);


        }



        private void llenarBoxCategoria()
        {
            foreach (Categoria cat in ControladorCategorias.Categorias)
            {
                if (cat.Vista == true)
                {
                    boxCategoria.Items.Add(cat.Nombre);
                }
            }
        }

        private void llenarBoxConsola()
        {

            foreach (Consola con in ControladorConsola.Consolas)
            {
                if (con.Vista == true)
                {
                    boxConsola.Items.Add(con.Nombre);
                }
            }
        }


        private void limpiarErrores()
        {
            errNombre.Text = "";
            errPrecio.Text = "";
            errStock.Text = "";
            errConsola.Text = "";
            errCategoria.Text = "";
            errConexion.Text = "";
            errImg.Text = "";
            errFormatoImg.Text = "";
            errMDJ.Text = "";

            errNombre.Hide();
            errPrecio.Hide();
            errStock.Hide();
            errConsola.Hide();
            errCategoria.Hide();
            errConexion.Hide();
            errImg.Hide();
            errFormatoImg.Hide();
            errMDJ.Hide();

        }

        private bool ValidarProducto(out bool errorMsg)
        {
            errorMsg = true;

            if (string.IsNullOrEmpty(txtNombre.Text))
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
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                string error = "Debe ingresar el precio";
                errPrecio.Text = error;
                errPrecio.Show();
                errorMsg = false;
            }
            else
            {
                errPrecio.Hide();
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                string error = "Debe ingresar el stock";
                errStock.Text = error;
                errStock.Show();
                errorMsg = false;
            }
            else
            {
                errStock.Hide();
            }
            if (boxCategoria.SelectedItem == null)
            {
                string error = "Debe seleccionar la categoria";
                errCategoria.Text = error;
                errCategoria.Show();
                errorMsg = false;
            }
            else
            {
                errCategoria.Hide();
            }   
            if (boxConsola.SelectedItem == null)
            {
                string error = "Debe seleccionar la consola";
                errConsola.Text = error;
                errConsola.Show();
                errorMsg = false;
            }
            else
            {
                errConsola.Hide();
            }
            if (string.IsNullOrEmpty(txtModoJuego.Text))
            {
                string error = "Debe ingresar el Modo de juego";
                errMDJ.Text = error;
                errMDJ.Show();
                errorMsg = false;
            }
            else
            {
                errMDJ.Hide();
            }   
            if (string.IsNullOrEmpty(txtConexion.Text))
            {
                string error = "Debe ingresar la conexion";
                errConexion.Text = error;
                errConexion.Show();
                errorMsg = false;
            }
            else
            {
                errConexion.Hide();
            } 
            if (string.IsNullOrEmpty(txtImagen.Text))
            {
                string error = "Debe ingresar una imagen";
                errImg.Text = error;
                errImg.Show();
                errorMsg = false;
            }
            else
            {
                errImg.Hide();
            }
            if (txtImagen.Text.Contains("png") == false)
            {
                string error = "Formato de imagen erroneo";
                errFormatoImg.Text = error;
                errFormatoImg.Show();
                errorMsg = false;
            }
            else
            {
                errFormatoImg.Hide();
            }
             
            return errorMsg;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool productoValidado = ValidarProducto(out bool errorMsg);

            if (productoValidado)
            {
                productoNuevo = new Producto()
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Precio = int.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    Categoria = ControladorCategorias.GetCategoriaByName(boxCategoria.SelectedItem.ToString()),
                    Consola = ControladorConsola.GetConsolaByName(boxConsola.SelectedItem.ToString()),
                    Conexion = txtConexion.Text,
                    ModoJuego = txtModoJuego.Text,
                    Imagen = txtImagen.Text,
                    Vista = bool.Parse(boxEstado.Text)
                };

                this.DialogResult = DialogResult.OK;
            }
        }

        private void llenarBoxEstado()
        {
            boxEstado.Items.Add("True");
            boxEstado.Items.Add("False");

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        public string getRuta()
        {
            return filePath;
        }

        public string getNombreRuta()
        {
            return fileName;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

            var fileContent = string.Empty;
            //var filePath = string.Empty;
            var fileName = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    fileName = openFileDialog.SafeFileName;
                    txtImagen.Text = fileName;
                    pictureBoxImagen.Load(filePath);

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void boxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}