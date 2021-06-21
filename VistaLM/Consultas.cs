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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }
        public string user;
        private void Consultas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu m = new Menu();
            m.user = user;
            m.Show();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            if(user == "EMPLEADO")
            {
                grid.ReadOnly = true;
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Entregas");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        Reportes rep = new Reportes();
        Usuario usu = new Usuario();
        Mercancia mer = new Mercancia();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mercancia")
            {
                usu.Nombre_usu = user;
                string a = usu.obtener_cargo();
                grid.DataSource = mer.consultar_mercancia(user);
                panel1.Visible = true;
            }
            else
            {
                grid.DataSource = rep.Consultas(comboBox1.Text);
                panel1.Visible = false;
            }

            if (comboBox1.Text == "Historial general")
            {
                grid.DataSource = rep.Consulta_historial();
            }

            if (comboBox1.Text == "Mercancia" || comboBox1.Text == "Historial Mercancia")
            {
                buscarico.Visible = true;
                buscartxt.Visible = true;
            }
            else
            {
                buscarico.Visible = false;
                buscartxt.Visible = false;
            }

            if (comboBox1.Text == "Entregas" || comboBox1.Text == "Pedidos")
                detalletxt.Visible = true;
            else
                detalletxt.Visible = false;
        }

        private void grid_DataSourceChanged(object sender, EventArgs e)
        {
            if (grid.DataSource != null)
                button1.Visible = true;
            else
                button1.Visible = false;
        }

        private void buscartxt_TextChanged(object sender, EventArgs e)
        {
                if(comboBox1.Text == "Mercancia")
                {
                    usu.Nombre_usu = user;
                    grid.DataSource = rep.busca("Mercancia_" + usu.obtener_cargo(), buscartxt.Text);
                }
            
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(comboBox1.Text == "Entregas" || comboBox1.Text == "Pedidos")
            {
                Detalle_EntPed det = new Detalle_EntPed();
                det.user = user;
                det.codtxt.Text = grid.CurrentRow.Cells[0].Value.ToString();
                if (comboBox1.Text == "Pedidos")
                {
                    det.pedido = true;
                    det.fechalbl.Text += grid.CurrentRow.Cells[2].Value.ToString();
                    det.usutxt.Text = grid.CurrentRow.Cells[1].Value.ToString();
                    det.locallbl.Visible = false;
                }
                else if (comboBox1.Text == "Entregas")
                {
                    det.entrega = true;
                    det.locallbl.Text += grid.CurrentRow.Cells[1].Value.ToString();
                    det.usutxt.Text = grid.CurrentRow.Cells[2].Value.ToString();
                    det.fechalbl.Text += grid.CurrentRow.Cells[3].Value.ToString();
                }
                det.ShowDialog();
            }
            if(comboBox1.Text == "Historial Mercancia")
            {
                Historial h = new Historial();
                h.textBox1.Text = grid.CurrentRow.Cells[1].Value.ToString();
                h.ShowDialog();
            }
            if(comboBox1.Text == "Locales")
            {
                DetLocales dl = new DetLocales();
                dl.textBox1.Text = grid.CurrentRow.Cells[0].Value.ToString();
                dl.ShowDialog();
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mercancia")
            {
                usu.Nombre_usu = user;
                string a = usu.obtener_cargo();
                grid.DataSource = mer.consultar_mercancia(user);
            }
            else
            {
                grid.DataSource = rep.Consultas(comboBox1.Text);
            }

            

            if (comboBox1.Text == "Mercancia")
            {
                panel1.Visible = true;
            }
            else
                panel1.Visible = false;

            if (comboBox1.Text == "Mercancia")
            {
                buscarico.Visible = true;
                buscartxt.Visible = true;
            }
            else
            {
                buscarico.Visible = false;
                buscartxt.Visible = false;
            }

            if (comboBox1.Text == "Entregas" || comboBox1.Text == "Pedidos")
                detalletxt.Visible = true;
            else
                detalletxt.Visible = false;
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pdfbutton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mercancia")
            {
                usu.Nombre_usu = user;
                string a = usu.obtener_cargo();
                rep.exportExcel(mer.consultar_mercancia(user));
            }
            else
            {
                rep.exportExcel(rep.Consultas(comboBox1.Text));
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
