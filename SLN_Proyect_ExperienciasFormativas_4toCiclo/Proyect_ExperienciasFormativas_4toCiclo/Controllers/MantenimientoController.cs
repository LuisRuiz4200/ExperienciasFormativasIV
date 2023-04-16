using Dominio.Entidad;
using Dominio.Negocio;
using Microsoft.Reporting.WebForms;
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
        ReportesBL reportesBL = new ReportesBL();

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

            string codigo = "MAN000001";

            if (lista.Count() != 0)
            {
                foreach (var item in lista)
                {
                    codigo = "MAN" + (int.Parse(item.id_mante.Substring(6)) + 1).ToString("000000");
                }
            }

            model.id_mante = codigo;

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_TIPOMANTE = new SelectList(dropdownBL.listTipoMante(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_TECNICO = new SelectList(dropdownBL.listTecnico(), "id_dropdown", "des_dropdown");
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


            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_TIPOMANTE = new SelectList(dropdownBL.listTipoMante(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_TECNICO = new SelectList(dropdownBL.listTecnico(), "id_dropdown", "des_dropdown");
            ViewBag.MENSAJE = men;

            return View(obj);
        }

        public ActionResult detalleMantenimiento(string id_mante)
        {
            var modelo = mantBL.PA_LISTAR_MANTENIMIENTO().Find(c => c.id_mante.Equals(id_mante));
            return View(modelo);
        }

        public ActionResult editarMantenimiento(string id_mante)
        {
            var modelo = mantBL.PA_LISTAR_MANTENIMIENTO().Find(c => c.id_mante.Equals(id_mante));
            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_TIPOMANTE = new SelectList(dropdownBL.listTipoMante(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_TECNICO = new SelectList(dropdownBL.listTecnico(), "id_dropdown", "des_dropdown");

            return View(modelo);
        }

        [HttpPost]
        public ActionResult editarMantenimiento(MantenimientoModel obj)
        {
            string mensaje;
            try
            {
                mensaje = mantBL.PA_EDITAR_MANTENIMIENTO(obj);
            }
            catch (SqlException ex)
            {

                mensaje = ex.Message;
            }

            var listado = mantBL.PA_LISTAR_MANTENIMIENTO();
            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.LISTA_TIPOMANTE = new SelectList(dropdownBL.listTipoMante(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_TECNICO = new SelectList(dropdownBL.listTecnico(), "id_dropdown", "des_dropdown");
            ViewBag.MENSAJE = mensaje;

            return View("listarMantenimientos", listado);
        }

        // REPORTE
        public ActionResult reporteMantenimiento()
        {
            var listado = reportesBL.PA_REPORTE_MANTENIMIENTO();
            ViewBag.CONTADOR = listado.Count;

            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent = true;

            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\Reporte_ListarMantenimientos.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("DataSet_ListarMantenimientos", listado));

            ViewBag.REPORTE = rp;

            return View();
        }
    }
}