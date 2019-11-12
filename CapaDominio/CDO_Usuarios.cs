using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;

namespace CapaDominio
{
    public class CDO_Usuarios
    {
        CD_Usuarios cdo_usuario = new CD_Usuarios();

        public bool LoginUsuer(string Usuario, string Contraseña)
        {
            return cdo_usuario.Login(Usuario, Contraseña);
        }

    }
}
