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

        // GET: DetEquipo
        public ActionResult listarDetEquipo()
        {
            var listado =detEquipoBL.listarDetEquipo();

            return View(listado);
        }

        public ActionResult registrarDetEquipo()
        {
            DetEquipoModel obj = new DetEquipoModel();

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

            ViewBag.MENSAJE = mensaje;

            return View(obj);
        }
    }
}