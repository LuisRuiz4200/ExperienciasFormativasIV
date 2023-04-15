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
    public class TecnicoController : Controller
    {
        
        TecnicoBL tecBL = new TecnicoBL();
        
        // GET: Tecnico
        //LISTA DE TECNICOS
        public ActionResult listarTecnico(TecnicoModel obj)
        {

            var listado = new List<TecnicoModel>();
            string estado_tecnico = obj.estado_tecnico;

            switch (estado_tecnico) 
            {
                case "ACTIVO":
                    listado = tecBL.PA_LISTAR_TECNICO_POR_ESTADO(estado_tecnico);
                    break;
                case "INACTIVO":
                    listado = tecBL.PA_LISTAR_TECNICO_POR_ESTADO(estado_tecnico);
                    break;
                case "TODOS":
                    listado = tecBL.PA_LISTAR_TECNICO();
                    break;
                default:
                    listado = tecBL.PA_LISTAR_TECNICO_POR_ESTADO("ACTIVO");
                    break;
            }

            return View(listado);
        }
        //DETALLE DEL TECNICO
        public ActionResult detalleTecnico(string cod_tecnico) 
        { 
            var modelo = tecBL.PA_LISTAR_TECNICO().Find(c => c.cod_tecnico.Equals(cod_tecnico));

            return View(modelo);
        }

        //REGISTRAR TECNICO
        public ActionResult registrarTecnico()
        { 
            TecnicoModel model = new TecnicoModel();


            var lista = tecBL.PA_LISTAR_TECNICO();

            string codigo="";

            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    codigo = item.cod_tecnico;

                    int correlativo = int.Parse(codigo.Substring(3)) + 1;
                    codigo = "TEC" + correlativo.ToString("00000");

                }
            }
            else {

                codigo = "TEC00001";
            }

            ViewBag.CODIGO_TECNICO = codigo;

            return View(model);
        }

        [HttpPost]
        public ActionResult registrarTecnico (TecnicoModel obj) 
        {
            string mensaje;

            string codigo = "";

            try
            {
                mensaje = tecBL.PA_INSERTAR_TECNICO(obj);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            var lista = tecBL.PA_LISTAR_TECNICO();

            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    codigo = item.cod_tecnico;

                    int correlativo = int.Parse(codigo.Substring(3)) + 1;
                    codigo = "TEC" + correlativo.ToString("00000");

                }
            }
            else
            {

                codigo = "TEC00001";
            }

            ViewBag.CODIGO_TECNICO = codigo;
            ViewBag.MENSAJE = mensaje;

            return View(obj);
        }
        //EDITAR TECNICO
        public ActionResult editarTecnico(string cod_tecnico) 
        {
            var listaTecnico = tecBL.PA_LISTAR_TECNICO();

            TecnicoModel objTecnico = listaTecnico.Find(c=>c.cod_tecnico.Equals(cod_tecnico));

            return View(objTecnico);
        }
        [HttpPost]
        public ActionResult editarTecnico(TecnicoModel obj)
        {
            string mensaje;

            try
            {
                mensaje = tecBL.PA_EDITAR_TECNICO(obj);
            }
            catch (Exception ex)
            { 
                mensaje=ex.Message; 
            }


            var listaTecnico = tecBL.PA_LISTAR_TECNICO();

            ViewBag.MENSAJE = mensaje;

            return View("listarTecnico",listaTecnico);
        }
        //GESTIONAR EL ESTADO DEL TECNICO
        public ActionResult gestionarEstadoTecnico(string cod_tecnico,string estado_tecnico,string mensaje)
        {

            TecnicoModel objTecnico = tecBL.PA_LISTAR_TECNICO().Find(c=>c.cod_tecnico.Equals(cod_tecnico));
            var listaTecnico = tecBL.PA_LISTAR_TECNICO();

            switch (objTecnico.estado_tecnico)
            {
                case "ACTIVO":
                    try
                    {
                        mensaje = tecBL.PA_ELIMINAR_TECNICO(cod_tecnico);
                        estado_tecnico = "ACTIVO";
                        objTecnico= new TecnicoModel();
                        objTecnico.estado_tecnico= estado_tecnico;
                        return RedirectToAction("listarTecnico", "Tecnico",objTecnico);

                    }
                    catch (Exception ex)
                    {       
                        mensaje = (ex.Message);
                    }

                    break;          
                case "INACTIVO":
                     
                    try
                    {
                        mensaje = tecBL.PA_RESTAURAR_TECNICO(cod_tecnico);
                        estado_tecnico = "INACTIVO";
                        objTecnico = new TecnicoModel();
                        objTecnico.estado_tecnico = estado_tecnico;
                        return RedirectToAction("listarTecnico", "Tecnico", objTecnico);
                    }
                    catch (Exception ex)
                    {
                        mensaje = (ex.Message);
                    }
                    break;

            }

            listaTecnico = tecBL.PA_LISTAR_TECNICO();
            ViewBag.MENSAJE = mensaje;

            return View("listarTecnico", listaTecnico);
        }
        [HttpPost]
        public ActionResult gestionarEstadoTecnico()
        {
            var listaTecnico = tecBL.PA_LISTAR_TECNICO();
            return View("listarTecnico",listaTecnico);
        }

        // REPORTE
        public ActionResult listarTecnicosReporte()
        {
            var listado = tecBL.PA_LISTAR_TECNICO();

            ViewBag.CONTADOR = listado.Count;

            // Reporte
            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent = true;

            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\Reporte_ListarTecnicos.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("DataSet_ListarTecnicos", listado));

            ViewBag.REPORTE = rp;

            return View();
        }
    }
}