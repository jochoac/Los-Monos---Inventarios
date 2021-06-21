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
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        public string user;

        private void Pedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu m = new Menu();
            m.user = user;
            m.Show();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        Reportes rep = new Reportes();
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {

        }

        Pedido ped = new Pedido();

        void limpiar()
        {
            txtbuscar.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGrid.Rows.Clear();
            txtbuscar.Focus();
        }
        Logica.Historial historial = new Logica.Historial();
        private void button2_Click(object sender, EventArgs e)
        {
            ped.usu.Nombre_usu = user;
            ped.Codigo_pedido = textBox1.Text;
            historial.Nombre_usu = user;
            historial.Fecha = DateTime.Now.ToShortDateString();
            historial.Hora = DateTime.Now.ToShortTimeString();
            historial.Descripcion = "Registro nuevo pedido";
            historial.Registrar_historial();
            ped.RegistrarPedido();
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                ped.Cantidad_productos = long.Parse(dataGrid.Rows[i].Cells[1].Value.ToString());
                ped.mer.Nombre = dataGrid.Rows[i].Cells[0].Value.ToString();
                ped.mer.Codigo = ped.mer.obtener_codigo();
                ped.Codigo_pedido = ped.obtener_ultcodigo();
                ped.Registrar_3pedido();
            }
            MessageBox.Show("Pedido registrado exitosamente");
            limpiar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid.Rows.Add(dataGridView1.CurrentRow.Cells[0].Value.ToString(), "0");
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                dataGridView1.DataSource = rep.listaProductos("producto_1", txtbuscar.Text);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rep.listaProductos("producto_1", txtbuscar.Text);
        }
    }
}
