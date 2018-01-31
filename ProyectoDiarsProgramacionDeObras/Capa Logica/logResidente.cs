using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logResidente
    {
        #region singleton
        private static readonly logResidente _instancia = new logResidente();
        public static logResidente Instancia
        {
            get { return logResidente._instancia; }
        }
        #endregion

        #region Metodos
        public entResidente ObtenerResidente(int ResidenteID)
        {
            try
            {
                return daoResidente.Instancia.ObtenerResidente(ResidenteID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
