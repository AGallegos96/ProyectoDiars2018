﻿using System;
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


        [HttpGet]
        public ActionResult ListaActividad()
        {
            List<entActividad> lista = logActividad.Instancia.ListarActividad();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaActividad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaActividad(entActividad actividad)
        {
            try
            {
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
                Boolean edita = logActividad.Instancia.EditaActividad(actividad);
                if (edita)
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
        public ActionResult EliminaActividad(int ActividadID, int ProgramaID)
        {
            try
            {
                Boolean edita = logActividad.Instancia.EliminaActividad(ActividadID, ProgramaID);
                return RedirectToAction("ListaObra");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividad", new { msjException = ex.Message });
            }
        }
    }
}