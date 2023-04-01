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
    public class TecnicoController : Controller
    {
        
        TecnicoBL tecBL = new TecnicoBL();
        
        // GET: Tecnico
        public ActionResult listarTecnico()
        {
            var listado = tecBL.PA_LISTAR_TECNICO();

            ViewBag.USUARIO = "LUIS";

            return View(listado);
        }

        public ActionResult registrarTecnico()
        { 
            TecnicoModel model = new TecnicoModel();


            return View(model);
        }

        [HttpPost]
        public ActionResult registrarTecnico (TecnicoModel obj) 
        {
            string men = "INGRESE DATOS EN LOS CUADROS";

            try 
            { 
               men = tecBL.PA_INSERTAR_TECNICO(obj);
            }
            catch (SqlException ex)
            {
                men = ex.Message;
                
            }

            ViewBag.MENSAJE = men;


            return View(obj);
            
        }
    }
}