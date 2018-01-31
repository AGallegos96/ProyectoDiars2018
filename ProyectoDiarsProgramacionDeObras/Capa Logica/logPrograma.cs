using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logPrograma
    {
        #region singleton
        private static readonly logPrograma _instancia = new logPrograma();
        public static logPrograma Instancia
        {
            get { return logPrograma._instancia; }
        }
        #endregion

        #region Metodos
        public List<entPrograma> ListarPrograma()
        {
            try
            {
                return daoPrograma.Instancia.ListarPrograma();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertaPrograma(entPrograma programa)
        {
            try
            {
                return daoPrograma.Instancia.InsertarPrograma(programa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entPrograma ObtenerPrograma(int ObraID)
        {
            try
            {
                return daoPrograma.Instancia.ObtenerPrograma(ObraID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
