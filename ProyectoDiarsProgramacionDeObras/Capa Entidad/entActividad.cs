using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entActividad
    {
        public int ActividadID { get; set; }
        public string Nombreactividad { get; set; }
        public string Prioridadactividad { get; set; }
        public int Totaloperariosactividad { get; set; }
        public DateTime Fechainicioactividad { get; set; }
        public DateTime Fechafinactividad { get; set; }
        public entPrograma Programa { get; set; }
    }
}
