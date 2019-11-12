using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Common.Cache;

namespace CapaDato
{
    public class CD_Usuarios:ConnectionToSql
    {
        public bool Login(string Usuario, string Contraseña)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Usuarios where Usuario=@usuario and Contraseña=@contraseña";
                    command.Parameters.AddWithValue("@usuario", Usuario);
                    command.Parameters.AddWithValue("@contraseña", Contraseña);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheBotones.Id = reader.GetInt32(0);
                            //CacheBotones.Usuario = reader.GetString(1);
                            //CacheBotones.Nombre = reader.GetString(2);
                            //CacheBotones.Apellido = reader.GetString(3);
                            //CacheBotones.Mail = reader.GetString(4);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
