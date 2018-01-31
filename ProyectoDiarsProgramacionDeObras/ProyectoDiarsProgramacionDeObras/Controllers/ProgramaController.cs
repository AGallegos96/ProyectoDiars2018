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
            List<entObra> lista = logObra.Instancia.ListarObra();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult SeleccionaObra(int ObraID, int ProgramaID)
        {
            try
            {
                Boolean edita = logActividad.Instancia.EliminaActividad(ObraID, ProgramaID);
                return RedirectToAction("ListaPrograma");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaPrograma", new { msjException = ex.Message });
            }
        }
    }
}