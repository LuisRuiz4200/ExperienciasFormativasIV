using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class SolicitudRepuestoController : Controller
    {
        SolicitudRepuestoBL solRepBL = new SolicitudRepuestoBL();

        // GET: SolicitudRepuesto
        public ActionResult listarSolicitudRepuesto()
        {
            var lista = solRepBL.PA_LISTAR_SOLICITUDREPUESTO();

            return View(lista);
        }

        // GET: SolicitudRepuesto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SolicitudRepuesto/Create
        public ActionResult registrarSolicitudRepuesto()
        {

            return View();
        }

        // POST: SolicitudRepuesto/Create
        [HttpPost]
        public ActionResult registrarSolicitudRepuesto(SolicitudRepuestoModel obj)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudRepuesto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SolicitudRepuesto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudRepuesto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SolicitudRepuesto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
