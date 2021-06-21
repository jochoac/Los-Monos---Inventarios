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
using System.Net;
using System.Net.Mail;

namespace VistaLM
{
    public partial class Entregas : Form
    {
        public Entregas()
        {
            InitializeComponent();
        }

        bool isSU = false;
        public string user;

        private void Entregas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu m = new Menu();
            m.user = user;
            m.Show();
        }
        Reportes rep = new Reportes();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isSU)
            {
                dataGridView1.DataSource = re.listaProductos("producto_su", txtbuscar.Text);
            }
            else
            {
                dataGridView1.DataSource = re.listaProductos("producto", txtbuscar.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            
        }


        Entrega en = new Entrega();
        Reportes re = new Reportes();
        
        void limpiar()
        {
            txtbuscar.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGrid.Rows.Clear();
            comboBox1.SelectedIndex = -1;
            txtbuscar.Focus();
        }
        Logica.Historial historial = new Logica.Historial();
        private void button2_Click(object sender, EventArgs e)
        {
            en.loc.Nombre_local = comboBox1.Text;
            en.usu.Nombre_usu = user;
            en.Total = 0;
            for(int i = 0; i < dataGrid.Rows.Count;i++)
            {
                en.Total += long.Parse(dataGrid.Rows[i].Cells[1].Value.ToString()) * long.Parse(dataGrid.Rows[i].Cells[2].Value.ToString());
            }
            en.Registrar_entrega();
            historial.Nombre_usu = user;
            string mes1 = DateTime.Now.Month.ToString(), dia1 = DateTime.Now.Day.ToString();
            if (DateTime.Now.Month < 10)
                mes1 = "0" + DateTime.Now.Month;
            if (DateTime.Now.Day < 10)
                dia1 = "0" + DateTime.Now.Day;
            string fecha1 = DateTime.Now.Year + "-" + mes1 + "-" + dia1;
            historial.Fecha = fecha1;
            historial.Hora = DateTime.Now.ToShortTimeString();
            historial.Descripcion = "Nueva entrega para " + comboBox1.Text;
            historial.Registrar_historial();
            for(int i = 0; i<dataGrid.RowCount;i++)
            {
                en.Cantidad = long.Parse(dataGrid.Rows[i].Cells[1].Value.ToString());
                en.mer.Nombre = dataGrid.Rows[i].Cells[0].Value.ToString();
                en.mer.Codigo = en.mer.obtener_codigo();
                en.Subtotal = long.Parse(dataGrid.Rows[i].Cells[1].Value.ToString()) * long.Parse(dataGrid.Rows[i].Cells[2].Value.ToString());
                en.Codigo = en.obtener_ultcodigo();
                en.Registrar_3venta();
            }
            MessageBox.Show("Venta registrada exitosamente");


            string path = re.PDF_venta(dataGrid, comboBox1.Text, DateTime.Now.ToShortDateString(), en.Codigo);

            /*MailMessage mmsg = new MailMessage();
            mmsg.To.Add(en.loc.obtenerCorreo());
            mmsg.From = new MailAddress("losmonosbodega@gmail.com");
            mmsg.Subject = "nueva venta";
            mmsg.Body = "probando enviar correos";
            Attachment archivo = new Attachment(path);
            mmsg.Attachments.Add(archivo);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("losmonosbodega@gmail.com", "losmonos2018");
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            client.Send(mmsg);
            */
            limpiar();
        }

        Local loc = new Local();
        private void Entregas_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = loc.fkLocal();
            comboBox1.DisplayMember = "Nombre";
            Usuario u = new Usuario();
            u.Nombre_usu = user;
            string h = u.obtener_cargo();
            if(u.obtener_cargo() != "SU")
            {
                dataGrid.Columns[2].Visible = false;
            }
            else
            {
                isSU = true;
            }
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if(isSU)
                {
                    dataGridView1.DataSource = re.listaProductos("producto_su", txtbuscar.Text);
                }
                else
                {
                    dataGridView1.DataSource = re.listaProductos("producto", txtbuscar.Text);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool a = true;
            for(int i=0;i<dataGrid.RowCount;i++)
            {
                if(dataGridView1.CurrentRow.Cells[0].Value.ToString()==dataGrid.Rows[i].Cells[0].Value.ToString())
                {
                    MessageBox.Show("El producto ya esta agregado");
                    a = false;
                    break;
                }
            }
            if(a)
            {
                Mercancia mer = new Mercancia();
                mer.Nombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                mer.Codigo = mer.obtener_codigo();
                mer.Precio = mer.obtener_Precio();
                dataGrid.Rows.Add(dataGridView1.CurrentRow.Cells[0].Value.ToString(), "0", mer.Precio);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(isSU)
            {
                dataGridView1.DataSource = re.listaProductos("producto_su", txtbuscar.Text);
            }
            else
            {
                dataGridView1.DataSource = re.listaProductos("producto", txtbuscar.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
