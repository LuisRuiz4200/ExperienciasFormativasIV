using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class DetSolicitudRepuestoController : Controller
    {
        DetSolicitudRepuestoBL detSolRepBL = new DetSolicitudRepuestoBL();

        // GET: DetSolicitudRepuesto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult registrarDetSolicitudRepuesto(String id_solRep)
        {

            DetSolicitudRepuestoModel model= new DetSolicitudRepuestoModel();

            id_solRep = "S0001";

            ViewBag.ID_SOLREP=id_solRep;

            return View();
        }
        [HttpPost]
        public ActionResult registrarDetSolicitudRepuesto(DetSolicitudRepuestoModel obj)
        {
            string mensaje;
            try 
            {
                mensaje = detSolRepBL.PA_INSERTAR_DETSOLREPUESTO(obj);

            }catch (SqlException ex) 
            {
                mensaje = ex.Message;
            }

            return View();
        }
    }
}