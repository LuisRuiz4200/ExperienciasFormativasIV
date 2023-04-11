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
        public ActionResult listarTecnico(string estado_tecnico)
        {

            var listado = tecBL.PA_LISTAR_TECNICO();

            switch (estado_tecnico) 
            {
                case "ACTIVO":
                    listado = tecBL.PA_LISTAR_TECNICO_POR_ESTADO(estado_tecnico);
                    break;
                case "INACTIVO":
                    listado = tecBL.PA_LISTAR_TECNICO_POR_ESTADO(estado_tecnico);
                    break;
                default:
                    listado = tecBL.PA_LISTAR_TECNICO();
                    break;
            }

            return View(listado);
        }

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

        public ActionResult gestionarEstadoTecnico(string cod_tecnico)
        {
            string mensaje="";

            TecnicoModel objTecnico = tecBL.PA_LISTAR_TECNICO().Find(c=>c.cod_tecnico.Equals(cod_tecnico));
            var listaTecnico = tecBL.PA_LISTAR_TECNICO();

            switch (objTecnico.estado_tecnico)
            {
                case "ACTIVO":
                    try
                    {
                        mensaje = tecBL.PA_ELIMINAR_TECNICO(cod_tecnico);
                        
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
                    }
                    catch (Exception ex)
                    {
                        mensaje = (ex.Message);
                    }

                    break;

            }

            listaTecnico = tecBL.PA_LISTAR_TECNICO();
            ViewBag.MENSAJE = mensaje;

            //return RedirectToAction("listarTecnico",listaTecnico);
            return View("listarTecnico", listaTecnico);
        }
        [HttpPost]
        public ActionResult gestionarEstadoTecnico()
        {
            var listaTecnico = tecBL.PA_LISTAR_TECNICO();
            return View("listarTecnico",listaTecnico);
        }
    }
}