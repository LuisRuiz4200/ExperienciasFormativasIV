using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class FichaReposicionController : Controller
    {
        FichaReposicionBL fichRepBL = new FichaReposicionBL();

        // GET: FichaReposicion
        public ActionResult listarFichaRepuesto()
        {
            var lista = fichRepBL.PA_LISTAR_FICHAREPOSICION();
            return View(lista);
        }
    }
}