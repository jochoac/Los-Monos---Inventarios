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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public string user;


        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Locales l = new Locales();
            l.user = user;
            l.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registrar_Mercancia rm = new Registrar_Mercancia();
            rm.user = user;
            rm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultas c = new Consultas();
            c.user = user;
            c.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pedidos p = new Pedidos();
            p.user = user;
            p.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Entregas en = new Entregas();
            en.user = user;
            en.Show();
            Hide();
        }
        private void miPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        Usuario usu = new Usuario();
        private void Menu_Load(object sender, EventArgs e)
        {
            usu.Nombre_usu = user;
            string a = usu.obtener_cargo();
            if(a == "EMPLEADO")
            {
                
                button5.Visible = false;
                
                label5.Visible = false;
                registrarUsuariosToolStripMenuItem.Visible = false;
            }
        }

        private void cambiarMiContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contraseña c = new Contraseña();
            c.user = user;
            c.ShowDialog();
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios();
            usu.user = user;
            usu.Show();
            Hide();
        }
    }
}
