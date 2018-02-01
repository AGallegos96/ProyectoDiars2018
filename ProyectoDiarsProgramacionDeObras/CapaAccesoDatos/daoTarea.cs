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
        public List<entTarea> ListarTarea( int actividadID)
        {
            SqlCommand cmd = null;
            List<entTarea> lista = new List<entTarea>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintactividadID", actividadID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entTarea ti = new entTarea();
                    ti.tareaID = Convert.ToInt16(dr["tareaID"]);
                    ti.Actividad.ActividadID = Convert.ToInt16(dr["ActividadID"]);
                    ti.nombreTarea = dr["nombreTarea"].ToString();
                    ti.duracionTarea = Convert.ToInt16(dr["duracionTarea"]);
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

        public Boolean InsertarTarea(entTarea Tarea)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintactividadID", Tarea.Actividad.ActividadID);
                cmd.Parameters.AddWithValue("@prmstrNombreTarea", Tarea.nombreTarea);
                cmd.Parameters.AddWithValue("@prmintDuracionTarea", Tarea.duracionTarea);
                cmd.Parameters.AddWithValue("@prmintNumerooperariostarea", Tarea.numeroDeOperarios);
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

        public entTarea ObtenerTarea(int TareaID, int ActividadID )
        {
            SqlCommand cmd = null;
            entTarea tarea = new entTarea();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spObtenerTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTareaID", TareaID);
                cmd.Parameters.AddWithValue("@prmintactividadID", ActividadID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tarea.tareaID = Convert.ToInt16(dr["tareaID"]);
                    tarea.Actividad.ActividadID = Convert.ToInt16(dr["ActividadID"]);
                    tarea.nombreTarea = dr["nombreTarea"].ToString();
                    tarea.duracionTarea = Convert.ToInt16(dr["duracionTarea"]);
                    tarea.numeroDeOperarios = Convert.ToInt16(dr["numeroDeOperarios"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return tarea;
        }

        public Boolean EditaTarea(entTarea Tarea)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("prmintTareaID", Tarea.tareaID);
                cmd.Parameters.AddWithValue("prmintActividadID", Tarea.Actividad.ActividadID);
                cmd.Parameters.AddWithValue("@prmstrNombreTarea", Tarea.nombreTarea);
                cmd.Parameters.AddWithValue("@prmintDuracionTarea", Tarea.duracionTarea);
                cmd.Parameters.AddWithValue("@prmintNumerooperariostarea", Tarea.numeroDeOperarios);
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

        public Boolean EliminarTarea(int tareaID , int actividadID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminaTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prminttareaID", tareaID);
                cmd.Parameters.AddWithValue("@prmintactividadID", actividadID);
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
