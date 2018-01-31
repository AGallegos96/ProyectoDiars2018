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
                List <entObra> lista = daoObra.Instancia.ListarObra();

                foreach (entObra obra in lista)
                {
                    if (logPrograma.Instancia.ObtenerPrograma(obra.ObraID) == null)
                    {
                        logPrograma.Instancia.InsertaPrograma(new entPrograma { Obra = obra, Residente = daoResidente.Instancia.ObtenerResidente(1) });
                    }
                } 

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entObra ObtenerObra(int ObraID)
        {
            try
            {
                return daoObra.Instancia.ObtenerObra(ObraID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertaObra(entObra obra)
        {
            try
            {
                return daoObra.Instancia.InsertarObra(obra);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaObra(entObra obra)
        {
            try
            {
                return daoObra.Instancia.EditarObra(obra);
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
