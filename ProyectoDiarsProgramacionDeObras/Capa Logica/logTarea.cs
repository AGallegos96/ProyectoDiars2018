using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad; 
namespace CapaLogica
{
    public class logTarea
    {
        #region singleton
        private static readonly logTarea _instancia = new logTarea();
        public static logTarea Instancia
        {
            get { return logTarea._instancia; }
        }

        #endregion

        #region Metodos
        public List<entTarea> ListarTarea(int actividadID)
        {
            try
            {
                List<entTarea> lista = daoTarea.Instancia.ListarTarea(actividadID);
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarTarea(entTarea tarea)
        {
            try
            {
                Boolean Inserta = daoTarea.Instancia.InsertarTarea(tarea);
                return Inserta;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Boolean EditaTarea(entTarea tarea)
        {
            try
            {
                Boolean edita = daoTarea.Instancia.EditaTarea(tarea);
                return edita;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public entTarea ObtenerTarea(int tareaID, int actividadID)
        {
            try
            {
                entTarea edita = daoTarea.Instancia.ObtenerTarea(tareaID, actividadID);
                return edita;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean EliminaTarea(int TareaID, int ActividadID)
        {
            try
            {
                return daoActividad.Instancia.EliminarActividad(TareaID, ActividadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
