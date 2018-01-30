using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPrograma
    {
        public int ProgramaID { get; set; }
        public entObra Obra { get; set; }
        public entResidente Residente { get; set; }
    }
}
