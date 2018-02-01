using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace ProyectoDiarsProgramacionDeObras.Controllers
{
    public class ProgramaController : Controller
    {
        [HttpGet]
        public ActionResult ListaPrograma()
        {
            List<entPrograma> lista = logPrograma.Instancia.ListarPrograma();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult SeleccionaObra(int ProgramaID)
        {
            try
            {
                return RedirectToAction("ListaActividad", "Actividad", new { ProgramaID = ProgramaID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaPrograma", new { msjException = ex.Message });
            }
        }
    }
}