using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace ProyectoDiarsProgramacionDeObras.Controllers
{
    public class ActividadController : Controller
    {
        public static int codigoPrograma { get; set; }

        [HttpGet]
        public ActionResult ListaActividad(int ProgramaID)
        {
            List<entActividad> lista = logActividad.Instancia.ListarActividad(ProgramaID);
            codigoPrograma = ProgramaID;
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaActividad(int ProgramaID)
        {
            entActividad actividad = new entActividad();
            actividad.Programa = logPrograma.Instancia.ObtenerPrograma(ProgramaID);
            return View(actividad);
        }

        [HttpPost]
        public ActionResult NuevaActividad(entActividad actividad)
        {
            try
            {
                actividad.Programa = logPrograma.Instancia.ObtenerPrograma(codigoPrograma);
                Boolean inserta = logActividad.Instancia.InsertaActividad(actividad);
                if (inserta)
                {
                    return RedirectToAction("ListaActividad");
                }
                else
                {
                    return View(actividad);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividad", new { msjException = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult EditaActividad(int ActividadID, int ProgramaID)
        {
            
            entActividad actividad = logActividad.Instancia.ObtenerActividad(ActividadID, ProgramaID);
            actividad.Programa = logPrograma.Instancia.ObtenerPrograma(ProgramaID);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        [HttpPost]
        public ActionResult EditaActividad(entActividad actividad)
        {
            try
            {
                actividad.Programa = logPrograma.Instancia.ObtenerPrograma(codigoPrograma);
                Boolean edita = logActividad.Instancia.EditaActividad(actividad);
                if (edita)
                {
                    return RedirectToAction("ListaActividad", new { ProgramaID = actividad.Programa.ProgramaID });
                }
                else
                {
                    return View(actividad);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividad", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaActividad(int ActividadID, int ProgramaID)
        {
            try
            {
                Boolean edita = logActividad.Instancia.EliminaActividad(ActividadID, ProgramaID);
                return RedirectToAction("ListaActividad", new { ProgramaID = ProgramaID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividad", new { msjException = ex.Message });
            }
        }
    }
}
