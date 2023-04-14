using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
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
            }
            model.id_fichaRepo = codigo;

            return View(model);
        }
        [HttpPost]
        public ActionResult registrarFichaReposicion(FichaReposicionModel obj)
        {
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
            }
                       
            ViewBag.MENSAJE = mensaje;
            var newObj = new FichaReposicionModel();
            newObj.id_fichaRepo = codigo;
            return View(newObj);
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