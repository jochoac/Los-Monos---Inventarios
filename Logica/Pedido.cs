using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Pedido
    {

        Conexion con = new Conexion();
        //Atributos
        private long cantidad_productos;
        private string fecha_pedido, hora_pedido, codigo_pedido;
        public Usuario usu = new Usuario();
        public Mercancia mer = new Mercancia();

        public string Codigo_pedido { get => codigo_pedido; set => codigo_pedido = value; }
        public long Cantidad_productos { get => cantidad_productos; set => cantidad_productos = value; }
        public string Fecha_pedido { get => Fecha_pedido1; set => Fecha_pedido1 = value; }
        public string Fecha_pedido1 { get => fecha_pedido; set => fecha_pedido = value; }
        public string Hora_pedido { get => hora_pedido; set => hora_pedido = value; }

        public bool RegistrarPedido()
        {
            fecha_pedido = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            hora_pedido = DateTime.Now.ToShortTimeString();
        
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Registro_Pedido = new SqlCommand("Registrar_Pedido '" + usu.Nombre_usu + "','"+hora_pedido+"','"+codigo_pedido+"'", a);
            SqlDataReader Actu = Registro_Pedido.ExecuteReader();
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

        public bool Registrar_3pedido()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("registrar_3pedido '" + codigo_pedido + "','" + mer.Codigo + "'," + cantidad_productos, a);
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

        public string obtener_ultcodigo()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select Top 1 Codigo_pedido from Pedido Order by Codigo_pedido Desc ", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                string cod = (string)dr["Codigo_Pedido"];
                a.Close();
                return cod;
            }
            else
            {
                a.Close();
                return "";
            }
        }
    }
}
