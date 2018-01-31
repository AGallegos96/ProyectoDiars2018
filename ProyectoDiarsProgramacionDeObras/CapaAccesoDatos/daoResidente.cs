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
    public class daoResidente
    {
        #region singleton
        private static readonly daoResidente _instancia = new daoResidente();
        public static daoResidente Instancia
        {
            get { return daoResidente._instancia; }
        }
        #endregion

        #region Metodos
        public entResidente ObtenerResidente(int ResidenteID)
        {
            SqlCommand cmd = null;
            entResidente residente = new entResidente();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERRESIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmResidenteID", ResidenteID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    residente.ResidenteID = Convert.ToInt16(dr["ResidenteID"]);
                    residente.Nombresresidente = dr["Nombresresidente"].ToString();
                    residente.Apellidosresidente = dr["Apellidosresidente"].ToString();
                    residente.Direccionresidente = dr["Direccionresidente"].ToString();
                    residente.Telefonoresidente = dr["Telefonoresidente"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return residente;
        }
        #endregion

    }
}
