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
        DropdownBL dropdownBL = new DropdownBL();

        // GET: Mantenimiento
        public ActionResult listarMantenimientos()
        {
            var listado = mantBL.PA_LISTAR_MANTENIMIENTO();

            return View(listado);
        }

        public ActionResult registrarMantenimiento()
        {
            MantenimientoModel model = new MantenimientoModel();

            var lista = mantBL.PA_LISTAR_MANTENIMIENTO();

            string codigo="";

            foreach (var item in lista)
            {
                codigo = "MAN" + (int.Parse(item.id_mante.Substring(6)) + 1).ToString("000000");
            }

            ViewBag.CODIGO_MANTENIMIENTO = codigo;

            ViewBag.LISTA_TIPOMANTE = new SelectList( dropdownBL.listTipoMante(),"id_dropdown","des_dropdown");
            ViewBag.LISTA_TECNICO = new SelectList(dropdownBL.listTecnico(),"id_dropdown","des_dropdown");
            return View(model);
        }

        [HttpPost]
        public ActionResult registrarMantenimiento(MantenimientoModel obj)
        {
            string men;

            var lista = mantBL.PA_LISTAR_MANTENIMIENTO();

            string codigo = "";

            foreach (var item in lista)
            {
                codigo = "MAN" + (int.Parse(item.id_mante.Substring(6)) + 1).ToString("000000");
            }

            ViewBag.CODIGO_MANTENIMIENTO = codigo;

            try
            {
                men = mantBL.PA_INSERTAR_MANTENIMIENTO(obj);
            }
            catch (SqlException ex)
            {

                men = ex.Message;
            }



            ViewBag.LISTA_TIPOMANTE = new SelectList(dropdownBL.listTipoMante(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_TECNICO = new SelectList(dropdownBL.listTecnico(), "id_dropdown", "des_dropdown");
            ViewBag.MENSAJE = men;

            return View(obj);
        }
    }
}