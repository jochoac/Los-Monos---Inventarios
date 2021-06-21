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
    public partial class restaurar : Form
    {
        public restaurar()
        {
            InitializeComponent();
        }
        public string user;
        LoginClass log = new LoginClass();
        Mercancia mer = new Mercancia();
        private void button1_Click(object sender, EventArgs e)
        {
            if(log.loggear(user, txtpass.Text) != "")
            {
                mer.Restaurar(long.Parse(numericUpDown1.Value.ToString()));
                MessageBox.Show("Productos restaurados a cantidad = "+numericUpDown1.Value);
                Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
