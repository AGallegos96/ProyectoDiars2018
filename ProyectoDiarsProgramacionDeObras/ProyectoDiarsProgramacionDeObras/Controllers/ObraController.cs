using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace ProyectoDiarsProgramacionDeObras.Controllers
{
    public class ObraController : Controller
    {
        [HttpGet]
        public ActionResult ListaObra()
        {
            List<entObra> lista = logObra.Instancia.ListarObra();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaObra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaObra(entObra obra)
        {
            try
            {
                Boolean inserta = logObra.Instancia.InsertaObra(obra);
                if (inserta)
                {
                    return RedirectToAction("ListaObra");
                }
                else
                {
                    return View(obra);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaObra", new { msjException = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult EditaObra(int ObraID)
        {
            entObra obra = logObra.Instancia.ObtenerObra(ObraID);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        [HttpPost]
        public ActionResult EditaObra(entObra obra)
        {
            try
            {
                Boolean edita = logObra.Instancia.EditaObra(obra);
                if (edita)
                {
                    return RedirectToAction("ListaObra");
                }
                else
                {
                    return View(obra);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaObra", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaObra(int ObraID)
        {
            try
            {
                Boolean edita = logObra.Instancia.EliminaObra(ObraID);
                return RedirectToAction("ListaObra");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaObra", new { msjException = ex.Message });
            }
        }
    }   
}
