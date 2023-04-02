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
    public class MantenimientoController : Controller
    {
        MantenimientoBL mantBL = new MantenimientoBL();

        // GET: Mantenimiento
        public ActionResult listarMantenimientos()
        {
            var listado = mantBL.PA_LISTAR_MANTENIMIENTO();

            return View(listado);
        }

        public ActionResult registrarMantenimiento()
        {
            MantenimientoModel model = new MantenimientoModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult registrarMantenimiento(MantenimientoModel obj)
        {
            string men = "INGRESE DATOS EN LOS CUADROS";

            try
            {
                men = mantBL.PA_INSERTAR_MANTENIMIENTO(obj);
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