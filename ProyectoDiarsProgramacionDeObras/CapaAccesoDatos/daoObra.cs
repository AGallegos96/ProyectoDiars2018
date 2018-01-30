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
    public class daoObra
    {
        #region singleton
        private static readonly daoObra _instancia = new daoObra();
        public static daoObra Instancia
        {
            get { return daoObra._instancia; }
        }
        #endregion

        #region Metodos
        public List<entObra> ListarObra()
        {
            SqlCommand cmd = null;
            List<entObra> lista = new List<entObra>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTAROBRAS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entObra obra = new entObra();
                    obra.ObraID = Convert.ToInt16(dr["ObraID"]);
                    obra.Nombreobra = dr["Nombreobra"].ToString();
                    obra.Responsableoobra = dr["Responsableobra"].ToString();
                    obra.Tipoobra = dr["Tipoobra"].ToString();
                    obra.Ubicacionobra = dr["Ubicacionobra"].ToString();
                    lista.Add(obra);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public Boolean InsertarObra(entObra obra)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTAROBRA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreObra", obra.Nombreobra);
                cmd.Parameters.AddWithValue("@prmstrResponsableObra", obra.Responsableoobra);
                cmd.Parameters.AddWithValue("@prmstrTipoObra", obra.Tipoobra);
                cmd.Parameters.AddWithValue("@prmstrUbicacionObra", obra.Ubicacionobra);
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

        public Boolean EditarObra(entObra obra)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITAROBRA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintObraID", obra.ObraID);
                cmd.Parameters.AddWithValue("@prmstrNombreObra", obra.Nombreobra);
                cmd.Parameters.AddWithValue("@prmstrResponsableObra", obra.Responsableoobra);
                cmd.Parameters.AddWithValue("@prmstrTipoObra", obra.Tipoobra);
                cmd.Parameters.AddWithValue("@prmstrUbicacionObra", obra.Ubicacionobra);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }

        public Boolean EliminarObra(int ObraID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINAROBRA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintObraID", ObraID);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    elimina = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return elimina;
        }

        #endregion
    }
}
