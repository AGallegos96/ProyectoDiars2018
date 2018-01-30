using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logObra
    {
        #region singleton
        private static readonly logObra _instancia = new logObra();
        public static logObra Instancia
        {
            get { return logObra._instancia; }
        }
        #endregion

        #region Metodos
        public List<entObra> ListarObra()
        {
            try
            {
                List<entObra> lista = daoObra.Instancia.ListarObra();

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertaObra(entObra a)
        {
            try
            {
                return daoObra.Instancia.InsertarObra(a);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaObra(entObra a)
        {
            try
            {
                return daoObra.Instancia.EditarObra(a);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminaObra(int ObraID)
        {
            try
            {
                return daoObra.Instancia.EliminarObra(ObraID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
