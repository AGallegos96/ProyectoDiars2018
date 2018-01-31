using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logActividad
    {
        #region singleton
        private static readonly logActividad _instancia = new logActividad();
        public static logActividad Instancia
        {
            get { return logActividad._instancia; }
        }
        #endregion

        #region Metodos
        public List<entActividad> ListarActividad(int ProgramaID)
        {
            try
            {
                return daoActividad.Instancia.ListarActividad(ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entActividad ObtenerActividad(int ActividadID, int ProgramaID)
        {
            try
            {
                return daoActividad.Instancia.ObtenerActividad(ActividadID, ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertaActividad(entActividad actividad)
        {
            try
            {
                return daoActividad.Instancia.InsertarActividad(actividad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaActividad(entActividad actividad)
        {
            try
            {
                return daoActividad.Instancia.EditarActividad(actividad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminaActividad(int ActividadID, int ProgramaID)
        {
            try
            {
                return daoActividad.Instancia.EliminarActividad(ActividadID, ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
