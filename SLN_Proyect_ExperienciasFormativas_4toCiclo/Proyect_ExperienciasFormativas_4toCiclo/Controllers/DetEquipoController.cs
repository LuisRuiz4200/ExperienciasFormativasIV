using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Negocio;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class DetEquipoController : Controller
    {

        DetEquipoBL detEquipoBL = new DetEquipoBL();
        DropdownBL dropdownBL = new DropdownBL();   

        // GET: DetEquipo
        public ActionResult listarDetEquipo()
        {
            var listado =detEquipoBL.listarDetEquipo();

            return View(listado);
        }
        //DETALLE DEL DETALLE EQUIPO
        public ActionResult detalleDetEquipo(string cod_patrimonial)
        {
            var modelo = detEquipoBL.listarDetEquipo().Find(c=>c.cod_patrimonial.Equals(cod_patrimonial));

            return View(modelo);
        }
        //REGITRAR DETALLE EQUIPO
        public ActionResult registrarDetEquipo()
        {
            DetEquipoModel obj = new DetEquipoModel();

            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");

            return View(obj);

        }
        [HttpPost]
        public ActionResult registrarDetEquipo(DetEquipoModel obj)
        {
            string mensaje;

            try
            {
                mensaje = detEquipoBL.registrarDetEquipo(obj);
            }
            catch (Exception ex) 
            {
                mensaje = ex.Message;
            }

            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");
            ViewBag.MENSAJE = mensaje;

            return View(obj);
        }
        //EDITAR DETALLE EQUIPO
        public ActionResult editarDetEquipo(string cod_patrimonial)
        {
            var modelo = detEquipoBL.listarDetEquipo().Find(c => c.cod_patrimonial.Equals(cod_patrimonial));

            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");

            return View(modelo);
        }
        [HttpPost]
        public ActionResult editarDetEquipo(DetEquipoModel obj)
        {
            string mensaje;

            try
            {
                mensaje = "";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");

            return View();
        }
        //ELIMINAR DETALLE EQUIPO
        public ActionResult eliminarDetEquipo(string cod_patrimonial) 
        {
            return View();
        }
        [HttpPost]
        public ActionResult eliminarDetEquipo()
        {
            return View();
        }
    }
}