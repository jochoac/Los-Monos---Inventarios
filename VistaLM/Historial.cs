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
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
        }
        Reportes rep = new Reportes();
        public bool entregas= false, pedidos = false;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            if (entregas)
                grid.DataSource = rep.historial_e(textBox1.Text);
            else if (pedidos)
                grid.DataSource = rep.historial_p(textBox1.Text);
        }
    }
}
