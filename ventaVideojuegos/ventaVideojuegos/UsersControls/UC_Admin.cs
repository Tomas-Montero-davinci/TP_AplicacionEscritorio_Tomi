using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Controlers;
using ventaVideojuegos.Modelo;


namespace ventaVideojuegos.UsersControls
{
    public partial class UC_Admin : UserControl
    {

        private static Producto filtro = new Producto();
        private List<Producto> Productos_Completo = new List<Producto>();
        private List<Producto> Productos_Filtrado = new List<Producto>();
        private List<Producto> Productos_Paginados = new List<Producto>();


        private static int current = 0;
        private static int paginador = 10;
        private static int total = 0;
        private static int last_pag = 0;
        private static int current_pag = 1;



        public UC_Admin()
        {
            InitializeComponent();
            ControladorCategorias.IniciarRepositorio();
            ControladorConsola.IniciarRepositorio();
            ControladorProductos.IniciarRepositorio();
            ControladorVentas.IniciarRepositorio();
            ControladorClientes.IniciarRepositorio();
            controladorUsuarios.IniciarRepositorio();
            ControladorVentaUnificada.IniciarRepositorio();

            Productos_Completo = ControladorProductos.Productos;
            Productos_Filtrado = ControladorProductos.Productos;

            total = Productos_Completo.Count();


            paginar(Productos_Completo);


            last_pag = total / paginador;

            llenarCombos();
            visualizarCatDB();
            visualizarConDB();
            visualizarCteDB();
            visualizarUsuDB();

        }


        private void VisualizarProductos(List<Producto> listaProductos)
        {
            dataGridView1.Rows.Clear();

            try
            {

                foreach (Producto prod in listaProductos)
                {
                    if (prod.Categoria.Vista == true)

                    {
                        int rowIndex = dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Cells[0].Value = prod.Id.ToString();
                        Bitmap img;
                        img = new Bitmap(Environment.CurrentDirectory + @"\Imgs\" + prod.Imagen);
                        dataGridView1.Rows[rowIndex].Cells[1].Value = img;
                        dataGridView1.Rows[rowIndex].Cells[2].Value = prod.Nombre.ToString();
                        dataGridView1.Rows[rowIndex].Cells[3].Value = prod.Precio.ToString();
                        dataGridView1.Rows[rowIndex].Cells[4].Value = prod.Stock.ToString();
                        dataGridView1.Rows[rowIndex].Cells[5].Value = prod.Categoria.Nombre.ToString();
                        dataGridView1.Rows[rowIndex].Cells[6].Value = prod.Consola.Nombre.ToString();
                        dataGridView1.Rows[rowIndex].Cells[7].Value = prod.Conexion.ToString();
                        dataGridView1.Rows[rowIndex].Cells[8].Value = prod.ModoJuego.ToString();
                        dataGridView1.Rows[rowIndex].Cells[9].Value = prod.Vista.ToString();

                    }

                    else
                    {

                        int rowIndex = dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Cells[0].Value = prod.Id.ToString();
                        dataGridView1.Rows[rowIndex].Cells[1].Value = prod.ModoJuego.ToString();
                        Bitmap img;
                        img = new Bitmap(Environment.CurrentDirectory + @"\Imgs\" + prod.Imagen);
                        dataGridView1.Rows[rowIndex].Cells[2].Value = img;
                        dataGridView1.Rows[rowIndex].Cells[3].Value = prod.Nombre.ToString();
                        dataGridView1.Rows[rowIndex].Cells[4].Value = prod.Precio.ToString();
                        dataGridView1.Rows[rowIndex].Cells[5].Value = prod.Stock.ToString();
                        dataGridView1.Rows[rowIndex].Cells[6].Value = "Categoria no existente";
                        dataGridView1.Rows[rowIndex].Cells[7].Value = prod.Consola.Nombre.ToString();
                        dataGridView1.Rows[rowIndex].Cells[8].Value = prod.Conexion.ToString();
                        dataGridView1.Rows[rowIndex].Cells[9].Value = prod.Vista.ToString();
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("EL ERROR FUE: " + e);
            }
        }

        private void visualizarConDB()
        {
            dataGridViewCon2.DataSource = llenar_grid_consolas();

        }

        //Aca se genera la consulta SQL que llama los registros
        public DataTable llenar_grid_consolas()
        {
            ventaVideojuegos.Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "Use tienda; select * from Consola;";
            SqlCommand cmd = new SqlCommand(consulta, ventaVideojuegos.Conexion.Conectar());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            return dt;
        }

        private void llenarBoxCategorias(List<Categoria> listaCategorias)
        {
            foreach (Categoria cat in listaCategorias)
            {
                if (cat.Vista == true)
                {
                    boxCategorias.Items.Add(cat.Nombre);
                }
            }
        }

        private void llenarBoxConsolas(List<Consola> listaConsolas)
        {
            foreach (Consola con in listaConsolas)
            {
                if (con.Vista == true)
                {
                    boxConsolas.Items.Add(con.Nombre);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                filtro.Vista = bool.Parse(comboBox1.Text);
                filtrar();
            }
        }

        private void llenarCombos()
        {
            List<Categoria> listCat = new List<Categoria>();
            listCat = ControladorCategorias.Categorias.Where(x => x.Id != 0).ToList();
            llenarBoxCategorias(listCat);

            List<Consola> listCon = new List<Consola>();
            listCon = ControladorConsola.Consolas.Where(x => x.Id != 0).ToList();
            llenarBoxConsolas(listCon);


            llenarBoxPaginacion();
            llenarBoxEstado();
        }

        private void llenarBoxEstado()
        {
            comboBox1.Items.Add("True");
            comboBox1.Items.Add("False");
        }

        private void vaciarCombos()
        {
            boxCategorias.Items.Clear();
            boxConsolas.Items.Clear();
        }

        private void llenarBoxPaginacion()
        {
            boxPaginacion.Items.Add("10");
            boxPaginacion.Items.Add("20");
            boxPaginacion.Items.Add("30");
            boxPaginacion.Items.Add("40");
            boxPaginacion.Items.Add("50");
            boxPaginacion.SelectedItem = "10";
        }

        private void paginar(List<Producto> prodMostrar)
        {
            Productos_Paginados = prodMostrar.Skip(current).Take(paginador).ToList();
            VisualizarProductos(Productos_Paginados);
            label_paginacion.Text = "Mostrando " + (current + 1) + " - " + (current + paginador) + "de " + total;


            if (current_pag == 1)
            {
                btn_FirstPage.Hide();
                btn_prev_page.Hide();

            }
            else
            {
                btn_FirstPage.Show();
                btn_FirstPage.Text = "1";
                btn_prev_page.Show();
                btn_prev_page.Text = (current_pag - 1).ToString();
            }

            if (current_pag == last_pag)
            {
                //btn_last_page.Hide();
                btn_next_page.Hide();
            }
            else
            {
                //btn_last_page.Show();
                btn_next_page.Show();
            }

            if (btn_FirstPage.Text == btn_prev_page.Text)
            {
                btn_FirstPage.Hide();
            }

            /*if (btn_last_page.Text == btn_next_page.Text)
            {
                btn_last_page.Hide();
            }*/

            btn_next_page.Text = (current_pag + 1).ToString();
            btn_prev_page.Text = (current_pag - 1).ToString();
            btn_actual_page.Text = (current_pag).ToString();

        }

        private void btn_FirstPage_Click(object sender, EventArgs e)
        {
            current = 0;
            current_pag = 1;
            paginar(Productos_Filtrado);
            btn_actual_page.Text = current_pag.ToString();
        }

        private void btn_prev_page_Click(object sender, EventArgs e)
        {

            current = current - paginador;
            current_pag = (current_pag - 1);
            btn_actual_page.Text = current_pag.ToString();

            paginar(Productos_Filtrado);
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            current = current + paginador;
            current_pag = (current_pag + 1);
            btn_actual_page.Text = current_pag.ToString();
            paginar(Productos_Filtrado);
        }

        private void btn_last_page_Click(object sender, EventArgs e)
        {
            current = last_pag + paginador;
            current_pag = last_pag;
            btn_actual_page.Text = current_pag.ToString();
            paginar(Productos_Filtrado);
        }

        private void boxPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            paginador = int.Parse(boxPaginacion.SelectedItem.ToString());
            current = 0;
            last_pag = (total / paginador) + 1;
            paginar(Productos_Filtrado);
        }

        private void boxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxCategorias.SelectedItem != null)
            {
                Categoria seleccionado = ControladorCategorias.GetCategoriaByName(boxCategorias.SelectedItem.ToString());
                filtro.Categoria = seleccionado;
                lblCat.Text = seleccionado.Nombre;
                filtrar();
            }
        }

        private void boxConsolas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxConsolas.SelectedItem != null)
            {
                Consola seleccionado = ControladorConsola.GetConsolaByName(boxConsolas.SelectedItem.ToString());
                filtro.Consola = seleccionado;
                lblCon.Text = seleccionado.Nombre;
                filtrar();
            }
        }

        private void filtrar()
        {

            if (filtro.Nombre != null)
            {
                Productos_Filtrado = Productos_Completo.Where(x => x.Nombre.ToLower().Contains(filtro.Nombre)).ToList();
                vaciarCombos();
                llenarCombos();

            }

            if (filtro.Categoria != null)
            {
                Productos_Filtrado = Productos_Filtrado.Where(x => x.Categoria == filtro.Categoria).ToList();

            }



            if (filtro.Consola != null)
            {
                Productos_Filtrado = Productos_Filtrado.Where(x => x.Consola == filtro.Consola).ToList();

            }

            if (filtro.Vista != false)
            {
                Productos_Filtrado = Productos_Filtrado.Where(x => x.Vista == filtro.Vista).ToList();
            }

            total = Productos_Filtrado.Count();
            last_pag = (total / paginador) + 1;
            current = 0;
            current_pag = 1;

            paginar(Productos_Filtrado);

        }

        private void filtroNombre_TextChanged(object sender, EventArgs e)
        {
            string nombreFiltrar = filtroNombre.Text.ToString().ToLower();

            if (string.IsNullOrEmpty(filtroNombre.Text))
            {
                filtro.Nombre = null;
            }
            else
            {
                filtro.Nombre = nombreFiltrar;
                filtrar();
            }
        }

        private void buttonNuevoConDB_Click(object sender, EventArgs e)
        {

            FormConsola conForm = new FormConsola();
            DialogResult dialogResult = conForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ControladorConsola.AñadirConsolaDB(conForm.consolaNueva);
                MessageBox.Show("Se agrego correctamente");

                visualizarConDB();

                vaciarCombos();
                llenarCombos();
            }

        }


        private void dataGridViewCon2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCon2.Columns[e.ColumnIndex].Name == "Eliminar_Con")
            {
                if (MessageBox.Show("Seguro que desea eliminar el registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ControladorConsola.EliminarConsolaDB(int.Parse(dataGridViewCon2.Rows[e.RowIndex].Cells[2].Value.ToString()));
                visualizarConDB();
            }

            if (dataGridViewCon2.Columns[e.ColumnIndex].Name == "Editar_Con")
            {
                //MessageBox.Show(dataGridViewCon2.Rows[e.RowIndex].Cells[2].Value.ToString());

                //lo que tiraba error que solicitabamos la ubicacion de la celda y traia eso, nos faltaba agregarle Value para el valor

                //guarda el id que trae como valor de la celda
                int idConEditar = int.Parse(dataGridViewCon2.Rows[e.RowIndex].Cells[2].Value.ToString());

                //string nombreConEditar = dataGridViewCon.SelectedRows[0].Cells[1].Value.ToString();

                //traer los datos de esta consola desde la base de datos
                Consola conEditar = ControladorConsola.GetOne(idConEditar);

                //se pasa la consola x parametro
                FormConsola formConsola = new FormConsola(conEditar);
                DialogResult dialogResult = formConsola.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    //actualiza consolas DB
                    ControladorConsola.ActualizarConsolaDB(idConEditar, formConsola.consolaNueva);

                    vaciarCombos();
                    llenarCombos();

                }
                //visualizar consolas DB
                visualizarConDB();
            }

        }


        private void buttonNuevoConDB_Click_1(object sender, EventArgs e)
        {

            FormConsola conForm = new FormConsola();
            DialogResult dialogResult = conForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ControladorConsola.AñadirConsolaDB(conForm.consolaNueva);
                MessageBox.Show("Se agrego correctamente");

                visualizarConDB();

                vaciarCombos();
                llenarCombos();
            }

        }


        // CategoriaDB

        private void visualizarCatDB()
        {
            dataGridViewCat2.DataSource = llenar_grid_categorias();
        }

        public DataTable llenar_grid_categorias()
        {
            ventaVideojuegos.Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "Use tienda; select * from Categoria;";
            SqlCommand cmd = new SqlCommand(consulta, ventaVideojuegos.Conexion.Conectar());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            return dt;
        }

        private void dataGridViewCat2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCat2.Columns[e.ColumnIndex].Name == "Eliminar_Cat")
            {
                if (MessageBox.Show("Seguro que desea eliminar el registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ControladorCategorias.EliminarCategoriaDB(int.Parse(dataGridViewCat2.Rows[e.RowIndex].Cells[2].Value.ToString()));
                visualizarCatDB();
            }


            if (dataGridViewCat2.Columns[e.ColumnIndex].Name == "Editar_Cat")
            {
                int idCatEditar = int.Parse(dataGridViewCat2.Rows[e.RowIndex].Cells[2].Value.ToString());

                Categoria catEditar = ControladorCategorias.GetOne(idCatEditar);

                FormCategoria formCategoria = new FormCategoria(catEditar);
                DialogResult dialogResult = formCategoria.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    ControladorCategorias.ActualizarCategoriaDB(idCatEditar, formCategoria.categoriaNueva);

                    vaciarCombos();
                    llenarCombos();

                }
                visualizarCatDB();
                visualizarConDB();
            }
        }

        //ClienteDB

        private void visualizarCteDB()
        {
            dataGridViewCte2.DataSource = llenar_grid_clientes();
        }

        public DataTable llenar_grid_clientes()
        {
            ventaVideojuegos.Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "Use tienda; select * from Cliente;";
            SqlCommand cmd = new SqlCommand(consulta, ventaVideojuegos.Conexion.Conectar());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            return dt;
        }

        private void dataGridViewCte2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewCte2.Columns[e.ColumnIndex].Name == "Eliminar_Cte")
            {
                if (MessageBox.Show("Seguro que desea eliminar el registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ControladorClientes.EliminarClienteDB(int.Parse(dataGridViewCte2.Rows[e.RowIndex].Cells[2].Value.ToString()));
                visualizarCteDB();
            }


            if (dataGridViewCte2.Columns[e.ColumnIndex].Name == "Editar_Cte")
            {
                int idCteEditar = int.Parse(dataGridViewCte2.Rows[e.RowIndex].Cells[2].Value.ToString());

                Cliente cteEditar = ControladorClientes.GetOne(idCteEditar);

                FormCliente formCliente = new FormCliente(cteEditar);
                DialogResult dialogResult = formCliente.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    ControladorClientes.ActualizarClienteDB(idCteEditar, formCliente.clienteNuevo);
                }
                visualizarCteDB();
            }
        }

        //UsuarioDB

        private void visualizarUsuDB()
        {
            dataGridViewUsu2.DataSource = llenar_grid_usuarios();
        }

        //Aca se genera la consulta SQL que llama los registros
        public DataTable llenar_grid_usuarios()
        {
            ventaVideojuegos.Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "Use tienda; select * from Usuario;";
            SqlCommand cmd = new SqlCommand(consulta, ventaVideojuegos.Conexion.Conectar());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            return dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idProdEliminar = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ControladorProductos.EliminarProducto(int.Parse(idProdEliminar));
                paginar(Productos_Completo);
            }
            else
            {
                MessageBox.Show("Debes seleccionar un producto para Eliminar", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idProdEditar = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                Producto auxiliar = ControladorProductos.GetProductoById(int.Parse(idProdEditar));

                string nombreProdEditar = auxiliar.Nombre;
                int precioProdEditar = auxiliar.Precio;
                int stockProdEditar = auxiliar.Stock;
                string categoriaProdEditar = auxiliar.Categoria.Nombre;
                string consolaProdEditar = auxiliar.Consola.Nombre;
                string conexionProdEditar = auxiliar.Conexion;
                string modoJuegoProdEditar = auxiliar.ModoJuego;
                bool VistaProdEditar = auxiliar.Vista;
                string imgProdEditar = auxiliar.Imagen;

                Producto prodEditar = new Producto()
                {
                    Id = int.Parse(idProdEditar),
                    Nombre = nombreProdEditar,
                    Precio = precioProdEditar,
                    Stock = stockProdEditar,
                    Categoria = ControladorCategorias.GetCategoriaByName(categoriaProdEditar),
                    Consola = ControladorConsola.GetConsolaByName(consolaProdEditar),
                    Conexion = conexionProdEditar,
                    ModoJuego = modoJuegoProdEditar,
                    Imagen = imgProdEditar,
                    Vista = VistaProdEditar
                };

                FormProducto formProducto = new FormProducto(prodEditar);
                DialogResult dialogResult = formProducto.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    ControladorProductos.ActualizarProductos(int.Parse(idProdEditar), formProducto.productoNuevo);

                    //VisualizarConsolas();
                    paginar(Productos_Completo);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un producto para Editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            FormProducto productForm = new FormProducto();
            DialogResult dialogResult = productForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ControladorProductos.AñandirProducto(productForm.productoNuevo);
            }
            paginar(Productos_Completo);
        }

        private void btnVaciarFiltros_Click_1(object sender, EventArgs e)
        {
            boxCategorias.SelectedItem = null;
            boxConsolas.SelectedItem = null;
            filtroNombre.Text = null;
            comboBox1.Text = null;

            filtro.Nombre = null;
            filtro.Categoria = null;
            filtro.Consola = null;

            lblCon.Text = "Consola";
            lblCat.Text = "Categoria";

            Productos_Filtrado = Productos_Completo;

            paginar(Productos_Completo);
            //btn_last_page.Show();
            btn_next_page.Show();
        }

        private void buttonNuevoCatDB_Click(object sender, EventArgs e)
        {
            FormCategoria catForm = new FormCategoria();
            DialogResult dialogResult = catForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ControladorCategorias.AñadirCategoriaDB(catForm.categoriaNueva);
                MessageBox.Show("Se agrego correctamente");


                visualizarCatDB();
                visualizarConDB();

                vaciarCombos();
                llenarCombos();
            }
        }

        private void buttonNuevoCteDB_Click_1(object sender, EventArgs e)
        {
            FormCliente cteForm = new FormCliente();
            DialogResult dialogResult = cteForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ControladorClientes.AñadirClienteDB(cteForm.clienteNuevo);
                MessageBox.Show("Se agrego correctamente");
            }
            visualizarCteDB();
        }
    }
}