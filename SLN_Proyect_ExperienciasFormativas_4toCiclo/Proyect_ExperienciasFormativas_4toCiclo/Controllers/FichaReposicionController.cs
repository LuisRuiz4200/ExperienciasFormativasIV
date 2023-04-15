using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class FichaReposicionController : Controller
    {
        FichaReposicionBL fichRepBL = new FichaReposicionBL();

        //CORRELATIVO DE FICHA DE REPOSICION
        private string correlativo() 
        {
            string correlativo = "FICH0001";
            if (fichRepBL.PA_LISTAR_FICHAREPOSICION().Count != 0)
            {
                foreach (var obj in fichRepBL.PA_LISTAR_FICHAREPOSICION())
                {
                    int n = int.Parse(obj.id_fichaRepo.Substring(4)) + 1;
                    correlativo = "FICH" + n.ToString("0000");
                }
            }

            return correlativo;
        }



        // GET: FichaReposicion
        public ActionResult listarFichaReposicion()
        {
            var lista = fichRepBL.PA_LISTAR_FICHAREPOSICION();

            ViewBag.USUARIO = "JEAN";

            return View(lista);
        }

        // GET: Ficha de Reposicion/Details/5
        public ActionResult detalleFicha(string id_fichaRepo)
        {
            var listado = fichRepBL.PA_LISTAR_FICHAREPOSICION();
            FichaReposicionModel objFicha = listado.Find(c=> c.id_fichaRepo.Equals(id_fichaRepo));
            return View(objFicha);
        }

        //REGISTRAR FICHA REPOSICION
        public ActionResult registrarFichaReposicion()
        {
            FichaReposicionModel model = new FichaReposicionModel();
            model.fecha_fichaRepo = DateTime.Now;
            /*
            var lista = fichRepBL.PA_LISTAR_FICHAREPOSICION();

            string codigo = "";
            if (lista.Count() != 0)
            {
                foreach (var item in lista)
                {
                    codigo = item.id_fichaRepo;

                    int correlativo = int.Parse(codigo.Substring(4)) + 1;
                    codigo = "FICH" + correlativo.ToString("0000");
                }
            }
            else {
                codigo = "FICH0001";
            } */

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            model.id_fichaRepo = correlativo();

            return View(model);
        }
        [HttpPost]
        public ActionResult registrarFichaReposicion(FichaReposicionModel obj)
        {
            string mensaje;
            obj.fecha_fichaRepo = DateTime.Now;

            try
            {
                mensaje = fichRepBL.PA_INSERTAR_FICHAREPOSICION(obj);

                ViewBag.MENSAJE = mensaje;
                return RedirectToAction("registrarFichaReposicion", obj);
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            } catch(Exception ex) 
            {
                mensaje = ex.Message;
            }
            /*
            var mensaje = fichRepBL.PA_INSERTAR_FICHAREPOSICION(obj);
            var lista = fichRepBL.PA_LISTAR_FICHAREPOSICION();
            string codigo = "";

            if (lista.Count() != 0)
            {
                foreach (var item in lista)
                {
                    codigo = item.id_fichaRepo;

                    int correlativo = int.Parse(codigo.Substring(4)) + 1;
                    codigo = "FICH" + correlativo.ToString("0000");
                }
            }
            else
            {
                codigo = "FICH0001";
            }*/
            var listadoFicha = new FichaReposicionBL().PA_LISTAR_FICHAREPOSICION();

            ViewBag.LISTAR_DET_EQUIPO = new SelectList(new DetEquipoBL().listarDetEquipo(), "cod_patrimonial", "cod_patrimonial");
            ViewBag.MENSAJE = mensaje;
            
            obj.id_fichaRepo = correlativo();
            return View(obj);
        }

        //EDITAR FICHA REPOSICION
        public ActionResult editarFichaRepo(string id_fichaRepo)
        {
            FichaReposicionModel objFicha = fichRepBL.PA_LISTAR_FICHAREPOSICION().Find(c => c.id_fichaRepo.Equals(id_fichaRepo));
            return View(objFicha);
        }

        [HttpPost]
        public ActionResult editarFichaRepo(FichaReposicionModel obj)
        {
            string mensaje;
            try
            {
                mensaje = fichRepBL.PA_EDITAR_FICHAREPOSICION(obj);
            }
            catch (SqlException ex)
            { 
                mensaje = ex.Message;
            }
            var listado = fichRepBL.PA_LISTAR_FICHAREPOSICION();
            ViewBag.MENSAJE = mensaje;
            return View("listarFichaReposicion", listado);
        }

        //ELIMINAR FICHA DE REPOSICION
        public ActionResult eliminarFicha(string id_fichaRepo)
        {
            string mensaje;

            try
            {
                mensaje = fichRepBL.PA_ELIMINAR_FICHAREPOSICION(id_fichaRepo);
            }
            catch (SqlException ex)
            { 
                mensaje = ex.Message;
            }
            var listado = fichRepBL.PA_LISTAR_FICHAREPOSICION();
            ViewBag.MENSAJE = mensaje;
            return View("listarFichaReposicion",listado);
        }
        [HttpPost]
        public ActionResult eliminarFicha()
        { 
            return View();
        }
    }
}