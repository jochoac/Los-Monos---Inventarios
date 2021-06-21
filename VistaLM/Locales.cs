using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace VistaLM
{
    public partial class Locales : Form
    {
        public Locales()
        {
            InitializeComponent();
        }

        public string user;

        private void Locales_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu m = new Menu();
            m.user = user;
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        Local loc = new Local();
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" & txtcorreo.Text != "" & txttelefono.Text != "" & txtdireccion.Text != "")
            {
                loc.Nombre_local = txtnombre.Text;
                loc.Correo_local = txtcorreo.Text;
                loc.Telefono_local = long.Parse(txttelefono.Text);
                loc.Direccion_local = txtdireccion.Text;
                string a = loc.Registro_loc();
                DataTable Consultar = loc.Consulta_local();
                dataGridView1.DataSource = Consultar;
                dataGridView1.ClearSelection();
                MessageBox.Show(a);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Por favor ingrese los datos correspondientes");
            }
        }

        private void Limpiar()
        {
            txtnombre.Clear();
            txtcorreo.Clear();
            txttelefono.Clear();
            txtdireccion.Clear();
        }

        private void Locales_Load(object sender, EventArgs e)
        {
            DataTable Consultar = loc.Consulta_local();
            dataGridView1.DataSource = Consultar;
            dataGridView1.ClearSelection();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtcorreo_Leave(object sender, EventArgs e)
        {
            if (txtcorreo.Text != "")
            {
                if (Validaciones.ValidarEmail(txtcorreo.Text) == false)
                {
                    txtcorreo.Focus();
                    txtcorreo.ForeColor = Color.Red;
                }
                else
                {
                    txtcorreo.ForeColor = Color.Green;
                }
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.Números(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
