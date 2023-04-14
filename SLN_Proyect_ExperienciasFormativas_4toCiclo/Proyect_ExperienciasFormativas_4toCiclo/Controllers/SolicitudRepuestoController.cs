using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class SolicitudRepuestoController : Controller
    {
        SolicitudRepuestoBL solRepBL = new SolicitudRepuestoBL();
        DetSolicitudRepuestoBL detSolRepBL = new DetSolicitudRepuestoBL();

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

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(),"cod_patrimonial","cod_patrimonial");
            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(),"id_dropdown","des_dropdown");


            return View();
        }

        // POST: SolicitudRepuesto/Create
        [HttpPost]
        public ActionResult registrarSolicitudRepuesto(SolicitudRepuestoModel obj)
        {
            string mensaje;


            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(), "id_dropdown","des_dropdown");

            try
            {
                mensaje =solRepBL.PA_INSERTAR_SOLICITUDREPUESTO(obj);

                ViewBag.MENSAJE=mensaje;

                return RedirectToAction("registrarDetSolicitudRepuesto", obj);
            }
            catch(SqlException ex)
            {
                mensaje =ex.Message;
                
            }catch(Exception ex)
            {
                mensaje =ex.Message;
            }

            var listaEquipo = new DetEquipoBL().listarDetEquipo();

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(listaEquipo, "cod_patrimonial", "cod_patrimonial");
            ViewBag.MENSAJE = mensaje;

            

            return View(obj);

        }



        public ActionResult registrarDetSolicitudRepuesto(SolicitudRepuestoModel obj)
        {
            ViewBag.ID_SOLREP = obj.id_solRep;

            var listaEquipo = new DetEquipoBL().listarDetEquipo();

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(listaEquipo, "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(), "id_dropdown", "des_dropdown");
            ViewBag.ITEM_DET_SOLREP = 1;

            return View("registrarSolicitudRepuesto",obj);

        }
        [HttpPost]
        public ActionResult registrarDetSolicitudRepuesto (string id_solRep)
        {
            string mensaje;

            DetSolicitudRepuestoBL detSolRepBL = new DetSolicitudRepuestoBL();


            //DEVOLVER DATOS DE LA SOLICITUD

            var objSolRep = solRepBL.PA_BUSCAR_SOLICTUDREPUESTO_POR_IDSOLREP(id_solRep);

            //DATOS DEL FORMULARIO

            var objDetalle = new DetSolicitudRepuestoModel();

            try
            {
                objDetalle.id_solRep = Request.Form["id_solRep"];
                objDetalle.item_det_solRep = int.Parse(Request.Form["item_det_solRep"]);
                objDetalle.artefacto_det_solRep = Request.Form["artefacto_det_solRep"];
                objDetalle.cant_det_solRep = int.Parse(Request.Form["cant_det_solRep"]);
                objDetalle.cod_uniMed = int.Parse(Request.Form["cod_UniMed"]);

                mensaje = detSolRepBL.PA_INSERTAR_DETSOLREPUESTO(objDetalle);
                ViewBag.MENSAJE_DETALLE = mensaje;
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            //CORRELATIVO DEL ITEM
            int itemDetalle=1;

            foreach(var item in detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep) ) 
            {
                itemDetalle = item.item_det_solRep + 1;
            }

            ViewBag.ITEM_DET_SOLREP = itemDetalle;

            //VIEW BAG ALMACENADOS
            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_DETALLE = detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep);
            ViewBag.MENSAJE_DETALLE = mensaje;
            ViewBag.ID_SOLREP = id_solRep;


            return View("registrarSolicitudRepuesto",objSolRep);
        }

        //EDITAR SOLICITUD

        public ActionResult editarSolicitudRepuesto(string id_solRep="")
        { 
            var modelo = solRepBL.PA_LISTAR_SOLICITUDREPUESTO().Find(c=>c.id_solRep.Equals(id_solRep));

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_DETALLE = detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep);

            return View(modelo);
        }
        [HttpPost]
        public ActionResult editarSolicitudRepuesto(SolicitudRepuestoModel obj)
        {
            string mensaje;
            try 
            {
                mensaje = solRepBL.PA_EDITAR_SOLICITUDREPUESTO(obj);
            }
            catch (Exception ex) 
            {
                mensaje = ex.Message;
            }

            ViewBag.MENSAJE = mensaje;
            ViewBag.LISTA_DETALLE = detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(obj.id_solRep);

            return View(obj);
        }

        //EDITAR DETALLE SOLICITUD

        public ActionResult editarDetSolicitudRepuesto(SolicitudRepuestoModel solicitudModel, string id_solRep,int item_det_solRep) 
        {

            var objDetalle = detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep).Find(c => c.item_det_solRep==item_det_solRep);

            ViewBag.MODELO_DET_SOLREP = objDetalle;

            ViewBag.ID_SOLREP = objDetalle.id_solRep;
            ViewBag.ITEM_DET_SOLREP = objDetalle.item_det_solRep;
            ViewBag.ARTEFACTO_DET_SOLREP = objDetalle.artefacto_det_solRep;
            ViewBag.CANT_DET_SOLREP = objDetalle.cant_det_solRep;
            ViewBag.COD_UNIMED = objDetalle.cod_uniMed;

            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(), "id_dropdown", "des_dropdown");
            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_DETALLE = detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep);

            return View("editarSolicitudRepuesto",solicitudModel);
        }
        [HttpPost]
        public ActionResult editarDetSolicitudRepuesto(string id_solRep, int item_det_solRep)
        {

            var objDetalle = detSolRepBL.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep).Find(c => c.item_det_solRep == item_det_solRep);

            ViewBag.MODELO_DET_SOLREP = objDetalle;

            ViewBag.ID_SOLREP = objDetalle.id_solRep;
            ViewBag.ITEM_DET_SOLREP = objDetalle.item_det_solRep;
            ViewBag.ARTEFACTO_DET_SOLREP = objDetalle.artefacto_det_solRep;
            ViewBag.CANT_DET_SOLREP = objDetalle.cant_det_solRep;
            ViewBag.COD_UNIMED = objDetalle.cod_uniMed;

            ViewBag.LISTA_UMD = new SelectList(new DropdownBL().listUnidadMedida(), "id_dropdown", "des_dropdown");
            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");

            return View("editarSolicitudRepuesto");
        }





    }
}
