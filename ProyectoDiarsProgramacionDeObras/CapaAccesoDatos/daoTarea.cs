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
    public class daoTarea
    {
        #region singleton
        private static readonly daoTarea _instancia = new daoTarea();
        public static daoTarea Instancia
        {
            get { return daoTarea._instancia; }
        }

        #endregion

        #region Metodos
        public List<entTarea> ListarTarea()
        {
            SqlCommand cmd = null;
            List<entTarea> lista = new List<entTarea>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaTarea", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entTarea ti = new entTarea();
                    ti.tareaID = Convert.ToInt16(dr["tareaID"]);
                    ti.nombreTarea = dr["nombreTarea"].ToString();
                    ti.numeroDeOperarios = Convert.ToInt16(dr["numeroDeOperarios"]);
                    lista.Add(ti);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarTarea(entTarea a)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrnombreTarea", a.nombreTarea);
                cmd.Parameters.AddWithValue("@prmstrestNumerooperariostarea", a.numeroDeOperarios);
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

        public entTarea ObtenerTarea(int idTarea)
        {
            SqlCommand cmd = null;
            entTarea a = new entTarea();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("prmintTareaID", idTarea);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    a.tareaID = Convert.ToInt16(dr["tareaID"]);
                    a.nombreTarea = dr["nombreTarea"].ToString();
                    a.numeroDeOperarios = Convert.ToInt16(dr["numeroDeOperarios"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return a;
        }

        public Boolean EditaTarea(entTarea a)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("prminttareaID", a.tareaID);
                cmd.Parameters.AddWithValue("@prmstrnombreTarea", a.nombreTarea);
                cmd.Parameters.AddWithValue("@prmintNumerooperariostarea", a.numeroDeOperarios);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
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
        #endregion
    }
}
