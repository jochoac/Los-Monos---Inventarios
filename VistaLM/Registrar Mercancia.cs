using Logica;
using System;
using System.Windows.Forms;

namespace VistaLM
{
    public partial class Registrar_Mercancia : Form
    {
        public Registrar_Mercancia()
        {
            InitializeComponent();
        }

        Mercancia mer = new Mercancia();
        public string user;

        private void Registrar_Mercancia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu m = new Menu();
            m.user = user;
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
            {
                DialogResult result = MessageBox.Show("Desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    mer.Codigo = txtCodigo.Text;
                    mer.Eliminar_producto();
                }
                
            }
            if (txtNombre.Text == "" || txtMarca.Text == "" || numCantidad.Value < 0 || txtTipo.Text == "")
                MessageBox.Show("Por favor llena todos los datos correspondientes");
            else
            {
                
                mer.Nombre = txtNombre.Text;

                mer.Existencia = (long)numCantidad.Value;
                mer.Marca = txtMarca.Text.ToUpper() ;
                mer.Tipo = txtTipo.Text.ToUpper();
                mer.Precio = (long)numericUpDown1.Value;
                Logica.Historial historial = new Logica.Historial();
                historial.Nombre_usu = user;
                historial.Fecha = DateTime.Now.ToShortDateString();
                historial.Hora = DateTime.Now.ToShortTimeString();
                if (radioButton1.Checked)
                {
                    if (checkBox1.Checked == true)
                        mer.Codigo = mer.generarCodigo(mer.obtener_ultcodigo(txtTipo.Text.ToUpper()), txtTipo.Text.ToUpper());
                    else
                    {
                        if (txtCodigo.Text == "")
                        {
                            MessageBox.Show("Por favor llena todos los datos correspondientes");
                            goto end;
                        }
                        else
                            mer.Codigo = txtCodigo.Text;

                    }
                    if (mer.Ingresar_producto(user) == true)
                    {
                        historial.Descripcion = "Registro nuevo producto " + mer.Nombre + "; Cantidad inicial: " +mer.Existencia;
                        historial.Cant_anterior = 0;
                        historial.Cant_actual = mer.Existencia;
                        historial.Registrar_historial_productos();
                        MessageBox.Show("Se ha ingresado el producto correctamente");
                        dataGrid.DataSource = mer.consultar_mercancia(user);
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error al ingresar el producto, revisa tus datos");
                }
                else if (radioButton2.Checked)
                {
                    mer.Codigo = txtCodigo.Text;
                    if (mer.Actualizar_producto(user) == true)
                    {
                        historial.Descripcion = "Actualizar datos producto " + mer.Nombre;
                        historial.Cant_anterior = mer.obtener_existencia();
                        historial.Cant_actual = mer.Existencia;
                        historial.Registrar_historial_productos();
                        MessageBox.Show("Se ha actualizado el producto correctamente");
                        dataGrid.DataSource = mer.consultar_mercancia(user);
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error al actualizar el producto, revisa tus datos");
                }
            }
        end://:v
            limpiar();
        }
        Usuario usu = new Usuario();
        private void Registrar_Mercancia_Load(object sender, EventArgs e)
        {
            usu.Nombre_usu = user;
            string a = usu.obtener_cargo();
            if (a == "SU")
            {
                numericUpDown1.Visible = true;
                label8.Visible = true;
                radioButton3.Visible = true;
            }
            dataGrid.DataSource = mer.consultar_mercancia(user);
            txtCodigo.Focus();
        }

        public void limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            numCantidad.Value=0;
            txtTipo.Clear();
            numericUpDown1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.productos(e);
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.Nombres(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                txtCodigo.ReadOnly = true;
            else
                txtCodigo.ReadOnly = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        bool test;
        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            test = true;
            if (radioButton2.Checked || radioButton3.Checked)
            {
                txtCodigo.Text = dataGrid.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
                txtMarca.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
                numCantidad.Value = long.Parse(dataGrid.CurrentRow.Cells[3].Value.ToString());
                txtTipo.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
                usu.Nombre_usu = user;
                string a = usu.obtener_cargo();
                if (a == "SU")
                {
                    numericUpDown1.Value = long.Parse(dataGrid.CurrentRow.Cells[5].Value.ToString());
                }
            }
            test = false;
        }
        Reportes re = new Reportes();
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if(!test)
            {
                usu.Nombre_usu = user;
                dataGrid.DataSource = re.busca("Mercancia_" + usu.obtener_cargo(), txtCodigo.Text);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!test)
            {
                usu.Nombre_usu = user;
                dataGrid.DataSource = re.busca("Mercancia_" + usu.obtener_cargo(), txtNombre.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            restaurar r = new restaurar();
            r.user = user;
            r.ShowDialog();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.productos(e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {



        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            if (!test)
            {
                usu.Nombre_usu = user;
                dataGrid.DataSource = re.busca("Mercancia_" + usu.obtener_cargo(), txtMarca.Text);
            }
        }
    }
}
