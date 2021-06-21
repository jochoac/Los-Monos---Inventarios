using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Logica;
using System.Diagnostics;

namespace VistaLM
{
    public partial class DetLocales : Form
    {
        public DetLocales()
        {
            InitializeComponent();
        }

        private void DetLocales_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Visible = true;
            dateTimePicker2.MaxDate = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grid_DataSourceChanged(object sender, EventArgs e)
        {
            if (grid.DataSource != null)
                pdfbutton.Visible = true;
            else
                pdfbutton.Visible = false;
        }
        Local loc = new Local();
        Reportes rep = new Reportes();
        private void pdfbutton_Click(object sender, EventArgs e)
        {
            string path = rep.PDF_Consolidado(rep.retorno(grid), textBox1.Text, DateTime.Now.ToLongDateString());

            MailMessage mmsg = new MailMessage();
            loc.Nombre_local = textBox1.Text;
            mmsg.To.Add(loc.obtenerCorreo());
            mmsg.From = new MailAddress("losmonosbodega@gmail.com");
            mmsg.Subject = "Consolidado diario";
            mmsg.Body = "Consolidado " + DateTime.Now.ToLongDateString();
            Attachment archivo = new Attachment(path);
            mmsg.Attachments.Add(archivo);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("losmonosbodega@gmail.com", "losmonos2018");
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            //client.Send(mmsg);

            string fecha = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            grid.DataSource = rep.Consolidado(textBox1.Text, fecha);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
            if (dateTimePicker1.Value.Month < 10)
                m = "0" + dateTimePicker1.Value.Month;
            if (dateTimePicker1.Value.Day < 10)
                d = "0" + dateTimePicker1.Value.Day;
            string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;

            string m2 = dateTimePicker2.Value.Month.ToString(), d2 = dateTimePicker2.Value.Day.ToString();
            if (dateTimePicker2.Value.Month < 10)
                m2 = "0" + dateTimePicker2.Value.Month;
            if (dateTimePicker2.Value.Day < 10)
                d2 = "0" + dateTimePicker2.Value.Day;
            string f2 = dateTimePicker2.Value.Year + "-" + m2 + "-" + d2;

            grid.DataSource = rep.Consolidado_fechas(textBox1.Text, f1, f2);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
            if (dateTimePicker1.Value.Month < 10)
                m = "0" + dateTimePicker1.Value.Month;
            if (dateTimePicker1.Value.Day < 10)
                d = "0" + dateTimePicker1.Value.Day;
            string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;

            string m2 = dateTimePicker2.Value.Month.ToString(), d2 = dateTimePicker2.Value.Day.ToString();
            if (dateTimePicker2.Value.Month < 10)
                m2 = "0" + dateTimePicker2.Value.Month;
            if (dateTimePicker2.Value.Day < 10)
                d2 = "0" + dateTimePicker2.Value.Day;
            string f2 = dateTimePicker2.Value.Year + "-" + m2 + "-" + d2;

            grid.DataSource = rep.Consolidado_fechas(textBox1.Text, f1, f2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
            if (dateTimePicker1.Value.Month < 10)
                m = "0" + dateTimePicker1.Value.Month;
            if (dateTimePicker1.Value.Day < 10)
                d = "0" + dateTimePicker1.Value.Day;
            string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;

            string m2 = dateTimePicker2.Value.Month.ToString(), d2 = dateTimePicker2.Value.Day.ToString();
            if (dateTimePicker2.Value.Month < 10)
                m2 = "0" + dateTimePicker2.Value.Month;
            if (dateTimePicker2.Value.Day < 10)
                d2 = "0" + dateTimePicker2.Value.Day;
            string f2 = dateTimePicker2.Value.Year + "-" + m2 + "-" + d2;
            rep.excelv2(rep.Consolidado_fechas(textBox1.Text, f1, f2));
            /*if (grid.Rows.Count > 0)
            {
                Reportes r = new Reportes();
                r.ExportarDataGridViewExcel(grid);
            }*/
        }

        private void grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
