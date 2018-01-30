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
        public ActionResult Index()
        {
            return View();
        }

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
            List<entObra> lista = logObra.Instancia.ListarObra();
            var lstObra = new SelectList(lista, "ObraID", "NombreObra", "ResponsableObra", "TipoObra", "UbicacionObra");
            ViewBag.Lista = lstObra;
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
                return RedirectToAction("NuevaObra", new { msjException = ex.Message });
            }

        }

    }
}
