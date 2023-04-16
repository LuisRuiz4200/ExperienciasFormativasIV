using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Negocio;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class DetEquipoController : Controller
    {

        DetEquipoBL detEquipoBL = new DetEquipoBL();
        DropdownBL dropdownBL = new DropdownBL();

        //CORRELATIVO DE CODIGO PATRIMONIAL DE EQUIPO
        private string correlativo()
        {
            string correlativo = "PAT0001";
            if (detEquipoBL.listarDetEquipo().Count != 0)
            {
                foreach (var obj in detEquipoBL.listarDetEquipo())
                {
                    int n = int.Parse(obj.cod_patrimonial.Substring(3)) + 1;
                    correlativo = "PAT" + n.ToString("0000");
                }
            }
            return correlativo;
        }


        // GET: DetEquipo
        public ActionResult listarDetEquipo()
        {
            var listado = detEquipoBL.listarDetEquipo();

            return View(listado);
        }

        //DETALLE DEL DETALLE EQUIPO
        public ActionResult detalleDetEquipo(string cod_patrimonial)
        {
            var modelo = detEquipoBL.listarDetEquipo().Find(c => c.cod_patrimonial.Equals(cod_patrimonial));

            return View(modelo);
        }

        //REGITRAR DETALLE EQUIPO
        public ActionResult registrarDetEquipo()
        {
            DetEquipoModel obj = new DetEquipoModel();
            obj.fecha_ingreso = DateTime.Now;
            obj.estado_equipo = "ACTIVO";
            

            //ESCRIBIMOS LOS DATOS DE ENTRADA
            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");
            obj.cod_patrimonial = correlativo();

            return View(obj);
        }

        [HttpPost]
        public ActionResult registrarDetEquipo(DetEquipoModel obj)
        {
            string mensaje;
            obj.fecha_ingreso = DateTime.Now;
            obj.estado_equipo = "ACTIVO";
            try
            {
                mensaje = detEquipoBL.registrarDetEquipo(obj);

                ViewBag.MENSAJE = mensaje;
                return RedirectToAction("registrarDetEquipo", obj);
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            var listaDetEquipo = new DetEquipoBL().listarDetEquipo();

            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");
            ViewBag.MENSAJE = mensaje;

            obj.cod_patrimonial = correlativo();
            return View(obj);
        }

        //EDITAR DETALLE EQUIPO
        public ActionResult editarDetEquipo(string cod_patrimonial)
        {
            var modelo = detEquipoBL.listarDetEquipo().Find(c => c.cod_patrimonial.Equals(cod_patrimonial));

            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");

            return View(modelo);
        }
        [HttpPost]
        public ActionResult editarDetEquipo(DetEquipoModel obj)
        {
            string mensaje;

            try
            {
                mensaje = detEquipoBL.editarDetEquipo(obj);
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            var listado = detEquipoBL.listarDetEquipo();
            ViewBag.LISTA_EQUIPO = new SelectList(dropdownBL.listEquipo(), "id_dropdown", "des_dropdown");
            ViewBag.LISTA_PROVEEDOR = new SelectList(dropdownBL.listProveedor(), "id_dropdown", "des_dropdown");
            ViewBag.MENSAJE = mensaje;

            return View("listarDetEquipo", listado);
        }
        //ELIMINAR DETALLE EQUIPO
        /*
        public ActionResult eliminarDetEquipo(string cod_patrimonial)
        {
            string mensaje;
            try
            {
                mensaje = detEquipoBL.eliminarDetEquipo(cod_patrimonial);
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            var listado = detEquipoBL.listarDetEquipo();
            ViewBag.MENSAJE = mensaje;

            return View("listarDetEquipo", listado);
        }
        [HttpPost]
        public ActionResult eliminarDetEquipo()
        {
            return View();
        } */

        //GESTIONAR EL ESTADO DE TECNICO
        public ActionResult gestionEstadoEquipo(string cod_patrimonial, string estado_equipo, string mensaje)
        {
            DetEquipoModel objDetEquipo = detEquipoBL.listarDetEquipo().Find(c => c.cod_patrimonial.Equals(cod_patrimonial));
            var listadoDet = detEquipoBL.listarDetEquipo();
            switch (objDetEquipo.estado_equipo)
            {
                case "ACTIVO":
                    try
                    {
                        mensaje = detEquipoBL.PA_CAMBIAR_ESTADO(cod_patrimonial);
                        estado_equipo = "ACTIVO";
                        objDetEquipo = new DetEquipoModel();
                        objDetEquipo.estado_equipo = estado_equipo;
                        //return RedirectToAction("listarDetEquipo", objDetEquipo);
                    }
                    catch (Exception ex)
                    {
                        mensaje = (ex.Message);
                    }
                    break;
                case "INACTIVO":
                    try
                    {
                        mensaje = detEquipoBL.PA_RESTAURAR_ESTADO(cod_patrimonial);
                        estado_equipo = "INACTIVO";
                        objDetEquipo = new DetEquipoModel();
                        objDetEquipo.estado_equipo = estado_equipo;
                        //return RedirectToAction("listarDetEquipo", objDetEquipo);
                    }
                    catch (Exception ex)
                    {
                        mensaje = (ex.Message);
                    }
                    break;
            }
            listadoDet = detEquipoBL.listarDetEquipo();
            ViewBag.MENSAJE = mensaje;

            return View("listarDetEquipo", listadoDet);
        }

        [HttpPost]
        public ActionResult gestionEstadoEquipo()
        {
            var listaEquipo = detEquipoBL.listarDetEquipo();
            return View("listarDetEquipo", listaEquipo);
        }

        // REPORTE
        public ActionResult listarEquiposReporte()
        {
            var listado = detEquipoBL.listarDetEquipo();

            ViewBag.CONTADOR = listado.Count;

            // Reporte
            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent= true;

            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\Reporte_ListarEquipos.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("DataSet_ListarEquipos", listado));

            ViewBag.REPORTE = rp;

            return View();
        }
    }
}