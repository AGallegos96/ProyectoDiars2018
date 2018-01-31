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
    public class daoActividad
    {
        #region singleton
        private static readonly daoActividad _instancia = new daoActividad();
        public static daoActividad Instancia
        {
            get { return daoActividad._instancia; }
        }
        #endregion

        #region Metodos
        public List<entActividad> ListarActividad()
        {
            SqlCommand cmd = null;
            List<entActividad> lista = new List<entActividad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entActividad actividad = new entActividad();
                    actividad.ActividadID = Convert.ToInt16(dr["ActividadID"]);
                    actividad.Programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    actividad.Nombreactividad = dr["Nombreactividad"].ToString();
                    actividad.Prioridadactividad = dr["Prioridadactividad"].ToString();
                    actividad.Totaloperariosactividad = Convert.ToInt16(dr["Totaloperariosactividad"]);
                    actividad.Fechainicioactividad = Convert.ToDateTime(dr["Fechainicioactividad"]);
                    actividad.Fechafinactividad = Convert.ToDateTime(dr["Fechafinactividad"]);
                    lista.Add(actividad);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public Boolean InsertarActividad(entActividad actividad)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmProgramaID", actividad.Programa.ProgramaID);
                cmd.Parameters.AddWithValue("@prmNombreactividad", actividad.Nombreactividad);
                cmd.Parameters.AddWithValue("@prmPrioridadactividad", actividad.Prioridadactividad);
                cmd.Parameters.AddWithValue("@prmTotaloperariosactividad", actividad.Totaloperariosactividad);
                cmd.Parameters.AddWithValue("@prmFechainicioactividad", actividad.Fechainicioactividad);
                cmd.Parameters.AddWithValue("@prmFechafinactividad", actividad.Fechafinactividad);
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

        public Boolean EditarActividad(entActividad actividad)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmActividadID", actividad.ActividadID);
                cmd.Parameters.AddWithValue("@prmProgramaID", actividad.Programa.ProgramaID);
                cmd.Parameters.AddWithValue("@prmNombreactividad", actividad.Nombreactividad);
                cmd.Parameters.AddWithValue("@prmPrioridadactividad", actividad.Prioridadactividad);
                cmd.Parameters.AddWithValue("@prmTotaloperariosactividad", actividad.Totaloperariosactividad);
                cmd.Parameters.AddWithValue("@prmFechainicioactividad", actividad.Fechainicioactividad);
                cmd.Parameters.AddWithValue("@prmFechafinactividad", actividad.Fechafinactividad);
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

        public Boolean EliminarActividad(int ActividadID, int ProgramaID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmActividadID", ActividadID);
                cmd.Parameters.AddWithValue("@prmProgramaID", ProgramaID);
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

        public entActividad ObtenerActividad(int ActividadID, int ProgramaID)
        {
            SqlCommand cmd = null;
            entActividad actividad = new entActividad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmActividadID", ActividadID);
                cmd.Parameters.AddWithValue("@prmProgramaID", ProgramaID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    actividad.ActividadID = Convert.ToInt16(dr["ActividadID"]);
                    actividad.Programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    actividad.Nombreactividad = dr["Nombreactividad"].ToString();
                    actividad.Prioridadactividad = dr["Prioridadactividad"].ToString();
                    actividad.Totaloperariosactividad = Convert.ToInt16(dr["Totaloperariosactividad"]);
                    actividad.Fechainicioactividad = Convert.ToDateTime(dr["Fechainicioactividad"]);
                    actividad.Fechafinactividad = Convert.ToDateTime(dr["Fechafinactividad"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return actividad;
        }
        #endregion
    }
}
