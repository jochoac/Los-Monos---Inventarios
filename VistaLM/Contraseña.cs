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
    public partial class Contraseña : Form
    {
        public Contraseña()
        {
            InitializeComponent();
        }
        Usuario usu = new Usuario();
        public string user;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusu.Text != txtpass.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                limpiar();
            }
            else
                usu.Nombre_usu = user;
                usu.cambiarContraseña(txtpass.Text);
        }

        private void limpiar()
        {
            txtusu.Clear();
            txtpass.Clear();
            txtusu.Focus();
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void Contraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
