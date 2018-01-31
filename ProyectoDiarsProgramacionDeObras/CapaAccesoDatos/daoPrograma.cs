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

        public List<entPrograma> ListarPrograma()
        {
            SqlCommand cmd = null;
            List<entPrograma> lista = new List<entPrograma>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPrograma programa = new entPrograma();
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Residente = daoResidente.Instancia.ObtenerResidente(1);
                    programa.Obra = daoObra.Instancia.ObtenerObra(Convert.ToInt16(dr["ObraID"]));
                    lista.Add(programa);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarPrograma(entPrograma programa)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmObraID", programa.Obra.ObraID);
                cmd.Parameters.AddWithValue("@prmResidenteID", programa.Residente.ResidenteID);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Inserta = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Inserta;
        }

        public entPrograma ObtenerPrograma(int ProgramaID)
        {
            SqlCommand cmd = null;
            entPrograma programa = new entPrograma();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmProgramaID", ProgramaID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Residente = daoResidente.Instancia.ObtenerResidente(1);
                    programa.Obra = daoObra.Instancia.ObtenerObra(Convert.ToInt16(dr["ObraID"]));
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
