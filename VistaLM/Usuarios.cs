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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        Usuario usu = new Usuario();
        private void Usuarios_Load(object sender, EventArgs e)
        {
            dataGrid.DataSource = usu.Consulta_usuarios();
            Caja_Usu.Focus();
        }
        public string user;

        private void clear()
        {
            Caja_Usu.Clear();
            Combo_cargo.SelectedIndex = -1;
            Caja_Empleado.Clear();
            Caja_ID.Clear();
            Combo_Estado.SelectedIndex = -1;
            Caja_correo.Clear();
            Caja_telefono.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (Caja_Usu.Text == "" | Caja_Empleado.Text == "" | Caja_ID.Text == "" | Combo_cargo.Text == "")
                {
                    MessageBox.Show("Por favor ingrese todos los datos");
                }
                else
                {
                    usu.Id_e = long.Parse(Caja_ID.Text);
                    usu.Cargo_usu = Combo_cargo.Text;
                    usu.Correo_usu = Caja_correo.Text;
                    usu.Estado_usu = Combo_Estado.Text;
                    usu.Password = Caja_ID.Text;
                    usu.Nombre_E = Caja_Empleado.Text;
                    usu.Telefono_e = long.Parse(Caja_telefono.Text);
                    usu.Nombre_usu = Caja_Usu.Text;
                    Menu Home = new Menu();
                    usu.Registro_usu();


                dataGrid.DataSource = usu.Consulta_usuarios();
                Caja_Usu.Focus();
                clear();
            }
            }

        private void Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu home = new Menu();
            home.user = user;
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }
