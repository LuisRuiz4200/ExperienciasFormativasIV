using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

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

            DetEquipoBL detEquipoBL = new DetEquipoBL();

            var listaEquipo = detEquipoBL.listarDetEquipo();

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(listaEquipo,"cod_patrimonial","cod_patrimonial");

            return View();
        }

        // POST: SolicitudRepuesto/Create
        [HttpPost]
        public ActionResult registrarSolicitudRepuesto(SolicitudRepuestoModel obj)
        {
            string mensaje;

            try
            {
                mensaje =solRepBL.PA_INSERTAR_SOLICITUDREPUESTO(obj);
                //return RedirectToAction("Index");
            }
            catch(SqlException ex)
            {
                mensaje =ex.Message;
                
            }

            var listaEquipo = new DetEquipoBL().listarDetEquipo();

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(listaEquipo, "cod_patrimonial", "cod_patrimonial");
            ViewBag.MENSAJE = mensaje;

            DetSolicitudRepuestoModel detalle= new DetSolicitudRepuestoModel();
            detalle.id_solRep = obj.id_solRep;

            return RedirectToAction("registrarDetSolicitudRepuesto", "DetSolicitudRepuesto", detalle);
            //return View();

        }

       /* public ActionResult ingresarArticulo2(int item_det_solRep, string id_solRep, string artefacto_det_solRep,int cant_det_solRep, int cod_uniMed) { 
        
            DetSolicitudRepuestoModel detalle = new DetSolicitudRepuestoModel();
            detalle.item_det_solRep = item_det_solRep;
            detalle.id_solRep = id_solRep;
            detalle.artefacto_det_solRep = artefacto_det_solRep;
            detalle.cant_det_solRep = cant_det_solRep;
            detalle.cod_uniMed = cod_uniMed;


            var listaEquipo = new DetEquipoBL().listarDetEquipo();
            List<DetSolicitudRepuestoModel> lista = new List<DetSolicitudRepuestoModel>();
            lista.Add(detalle);

            ViewBag.LISTA_ARTICULO = lista;
            ViewBag.LISTAR_DET_EQUIPO = new SelectList(listaEquipo, "cod_patrimonial", "cod_patrimonial");

            return View("registrarSolicitudRepuesto");
        
        }*/



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
