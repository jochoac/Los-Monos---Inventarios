﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using System.Diagnostics;

namespace VistaLM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtusu.Focus();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            LoginClass l = new LoginClass();
            if (txtusu.Text == "" | txtpass.Text == "")
            {
                MessageBox.Show("Por favor ingrese todos los datos");
            }
            else
            {
                string mensaje = l.loggear(txtusu.Text, txtpass.Text);
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                    Menu abrir = new Menu();
                    abrir.user = txtusu.Text;
                    abrir.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Error al iniciar sesión\nVerifique su Nombre de Ususario o Contraseña");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtusu_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.Cuentas(e);
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.Pass(e);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
