using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaDato
{
    public class CD_ArchivosMP3
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void AgregarCuenta(string Usuario, string Nombre, string Apellido, string Mail, string Contraseña)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into Usuarios values('" + Usuario + "','" + Nombre + "', '" + Apellido + "', '" + Mail + "','" + Contraseña + "')";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
        }      
    }
}
