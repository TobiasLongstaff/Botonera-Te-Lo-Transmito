using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDato;

namespace CapaDominio
{
    public class CDO_ArchivoMP3
    {
        private CD_ArchivosMP3 objetoCD = new CD_ArchivosMP3();

        public void crearcuenta(string Usuario, string Nombre, string Apellido, string Mail, string Contraseña)
        {
            objetoCD.AgregarCuenta(Usuario, Nombre, Apellido, Mail, Contraseña);
        }
    }
}
