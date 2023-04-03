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
    }
}