using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using ventaVideojuegos;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public partial class Login : Form
    {


        public static string usuario = "";
        public static string pw = "";
        public static string esAdm;
        public Login()
        {

            InitializeComponent();
            limpiarErrores();

        }


        private void limpiarErrores()
        {
            errLogin.Text = "";
            errLogin.Hide();
        }

        private bool ValidarUsuario(out bool errorMsg)
        {
            errorMsg = true;

            if (string.IsNullOrEmpty(txtUsuarioLogin.Text) && string.IsNullOrEmpty(txtContrasenaLogin.Text))
            {
                string error = "Debe ingresar usuario y contraseña";
                errLogin.Text = error;
                errLogin.Show();
                errorMsg = false;
            }
            else if (string.IsNullOrEmpty(txtUsuarioLogin.Text))
            {
                string error = "Debe ingresar el usuario";
                errLogin.Text = error;
                errLogin.Show();
                errorMsg = false;
            }
            else if (string.IsNullOrEmpty(txtContrasenaLogin.Text))
            {
                string error = "Debe ingresar la contraseña";
                errLogin.Text = error;
                errLogin.Show();
                errorMsg = false;
            }
            else
            {
                errLogin.Hide();
            }



            return errorMsg;
        }

        private void bttnAcceder_Click(object sender, EventArgs e)
        {

            bool exists;
            bool usuarioValidado = ValidarUsuario(out bool errorMsg);

            if (usuarioValidado)
            {
                bool valido = false;

                //con esto buscamos el usuario
                Conexion.Conectar();
                string query = "use tienda; select * from Usuario where Nombre = @nombre and Contrasena = @contrasena ;";
                SqlCommand cmd = new SqlCommand(query, Conexion.Conectar());
                cmd.Parameters.AddWithValue("@nombre", txtUsuarioLogin.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasenaLogin.Text);

                try
                {
                    var result = cmd.ExecuteScalar();
                    exists = result != null ? (int)result > 0 : false;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la query: " + ex.Message);
                }

                if (exists)
                {
                    usuario = txtUsuarioLogin.Text;
                    pw = txtContrasenaLogin.Text;

                    esAdm = esAdmin();
                    valido = true;
                }


                if (valido)
                {
                    usuario = txtUsuarioLogin.Text;

                    this.Hide();
                    Form1 form = new Form1();
                    form.Show();

                }
                else
                {
                    string error = "Credenciales invalidas";
                    errLogin.Text = error;
                    errLogin.Show();
                }

            }
        }

        public string esAdmin()
        {
            Conexion.Conectar();
            string query = "use tienda; select EsAdmin from Usuario where Nombre = @nombre and Contrasena = @contrasena ;";
            SqlCommand cmd = new SqlCommand(query, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@nombre", txtUsuarioLogin.Text);
            cmd.Parameters.AddWithValue("@contrasena", txtContrasenaLogin.Text);

            return cmd.ExecuteScalar().ToString();
             
        }


    } 

    }
