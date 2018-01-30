using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace ProyectoDiarsProgramacionDeObras.Controllers
{
    public class TareaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListaTarea()
        {
            List<entTarea> lista = logTarea.Instancia.ListarTarea();
            ViewBag.listaTarea = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaTarea()
        {
            List<entTarea> lista = logTarea.Instancia.ListarTarea();
            var lsTipoProducto = new SelectList(lista, "idTarea", "nombreObra", "cantidadDeOperarios");
            ViewBag.Lista = lsTipoProducto;
            return View();
        }

        [HttpPost]
        public ActionResult NuevoTipoProducto(entTarea tp)
        {
            try
            {
                Boolean inserta = logTarea.Instancia.InsertarTarea(tp);

                if (inserta)
                {
                    return RedirectToAction("ListaTarea");
                }
                else
                {
                    return View(tp);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("NuevaTarea", new { msjException = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult EditaTarea(int tareaID)
        {
            entTarea a = logTarea.Instancia.ObtenerTarea(tareaID);
            return View(a);
        }

        [HttpPost]
        public ActionResult EditaTarea(entTarea tp)
        {
            try
            {
                Boolean edita = logTarea.Instancia.EditaTarea(tp);

                if (edita)
                {
                    return RedirectToAction("ListaTarea");
                }
                else
                {
                    return View();
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EditaTarea", new { msjException = ex.Message });
            }
        }
    }
}