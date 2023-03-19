using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidad;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class DetEquipoController : Controller
    {
        // GET: DetEquipo
        public ActionResult listarDetEquipo()
        {
            return View();
        }
        public ActionResult registrarDetEquipo(DetEquipoModel obj) 
        { 
            return View(); 
        
        }
        [HttpPost]
        public ActionResult registrarDetEquipo()
        {
            return View();

        }
    }
}