using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Entrega
    {
        Conexion con = new Conexion();
        public Mercancia mer = new Mercancia();
        public Usuario usu = new Usuario();
        public Local loc = new Local();
        private long codigo, cantidad, total, subtotal;
        private string fecha, hora, verificado;



        public long Codigo { get => codigo; set => codigo = value; }
        public long Cantidad { get => cantidad; set => cantidad = value; }
        public long Total { get => total; set => total = value; }
        public long Subtotal { get => subtotal; set => subtotal = value; }
        public string Fecha { get => Fecha1; set => Fecha1 = value; }
        public string Hora { get => Hora1; set => Hora1 = value; }
        public string Fecha1 { get => fecha; set => fecha = value; }
        public string Hora1 { get => hora; set => hora = value; }
        public string Verificado { get => verificado; set => verificado = value; }

        public bool Registrar_entrega()
        {
            Hora1 = DateTime.Now.ToShortTimeString();

            string mes1 = DateTime.Now.Month.ToString(), dia1 = DateTime.Now.Day.ToString();
            if (DateTime.Now.Month < 10)
                mes1 = "0" + DateTime.Now.Month;
            if (DateTime.Now.Day < 10)
                dia1 = "0" + DateTime.Now.Day;
            Fecha1 = DateTime.Now.Year + "-" + mes1 + "-" + dia1;
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Registro_Venta = new SqlCommand("Registrar_entrega '" + usu.Nombre_usu + "','" + loc.Nombre_local + "','"+Hora1+"',"+Total, a);
            SqlDataReader Actu = Registro_Venta.ExecuteReader();
            if (Actu.Read() == false)
            {
                a.Close();
                return true;
            }
            else
            {
                a.Close();
                return false;
            }
        }

        public bool Eliminar_3venta(string cod_e, string nom_p, string cant)
        {
            int code = int.Parse(cod_e.Substring(4));
            mer.Nombre = nom_p;

            long cnt = long.Parse(cant);
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("Eliminar_3entrega " + code + ",'" + mer.obtener_codigo() + "'," + cant, a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;
            }
            else
            {
                a.Close();
                return true;
            }
        }

        public bool Registrar_3venta()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("registrar_3entrega '" + codigo + "','" + mer.Codigo + "'," + cantidad + ","+subtotal, a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;
            }
            else
            {
                a.Close();
                return true;
            }
        }

        public bool Actualizar_3venta()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("Actualizar_3entrega '" + codigo + "','" + mer.Codigo + "'," + cantidad, a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;
            }
            else
            {
                a.Close();
                return true;
            }
        }


        public long obtener_ultcodigo()
        {
            SqlConnection C = con.conectar();
            C.Open();
            SqlCommand sss = new SqlCommand("select Top 1 Codigo_entrega from Entrega Order by Codigo_entrega Desc ", C);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                long cod = (long)dr["Codigo_entrega"];
                C.Close();
                return cod;
            }
            else
            {
                C.Close();
                return 0;
            }
        }
    }
}
