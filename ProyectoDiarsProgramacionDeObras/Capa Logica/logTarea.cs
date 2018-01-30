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
        public List<entTarea> ListarTarea()
        {
            try
            {
                List<entTarea> lista = daoTarea.Instancia.ListarTarea();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarTipoProducto(entTarea a)
        {
            try
            {
                Boolean Inserta = datTarea.Instancia.InsertarTarea(a);
                return Inserta;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

       #endregion
    }
}
