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

        // GET: Ficha de Reposicion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: RegistrarReposicion/Create
        public ActionResult registrarFichaReposicion()
        {
            DetEquipoBL detEquipoBL = new DetEquipoBL();

            var listaEquipo = detEquipoBL.listarDetEquipo();

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(listaEquipo, "cod_patrimonial", "cod_patrimonial");

            return View();
        }
    }
}