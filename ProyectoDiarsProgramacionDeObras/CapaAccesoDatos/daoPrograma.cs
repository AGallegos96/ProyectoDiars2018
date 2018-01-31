using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class daoPrograma
    {
        #region singleton
        private static readonly daoPrograma _instancia = new daoPrograma();
        public static daoPrograma Instancia
        {
            get { return daoPrograma._instancia; }
        }
        #endregion

        #region Metodos
        public entPrograma ObtenerPrograma(int ObraID)
        {
            SqlCommand cmd = null;
            entPrograma programa = new entPrograma();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmObraID", ObraID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Residente.ResidenteID = Convert.ToInt16(dr["ResidenteID"]);
                    programa.Obra.ObraID = Convert.ToInt16(dr["ObraID"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return programa;
        }
        #endregion
    }
}
