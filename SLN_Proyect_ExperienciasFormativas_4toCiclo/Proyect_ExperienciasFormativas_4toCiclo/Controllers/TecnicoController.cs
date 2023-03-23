using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class TecnicoController : Controller
    {
        
        TecnicoBL tecBL = new TecnicoBL();
        
        // GET: Tecnico
        public ActionResult listarTecnico()
        {
            var listado = tecBL.PA_LISTAR_TECNICO();

            return View(listado);
        }
    }
}