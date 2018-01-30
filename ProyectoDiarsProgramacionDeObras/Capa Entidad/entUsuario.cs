using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entUsuario
    {
        public int UsuarioID { get; set; }
        public string Nombreusuario { get; set; }
        public bool Estadousuario { get; set; }
        public entResidente Residente { get; set; }
    }
}
