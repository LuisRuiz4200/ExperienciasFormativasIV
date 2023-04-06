using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Proyect_ExperienciasFormativas_4toCiclo.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBL usuBL = new UsuarioBL();  
        DropdownBL dropdownBL = new DropdownBL();

        // GET: Usuario


        public ActionResult ListarUsuario()
        {
            var listado = usuBL.Listar_Usuario();

            ViewBag.USUARIO = "JEAN";

            return View(listado);
        }


        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string cod_usuario, string pass_usuario)
        {

            string mensaje="";
            UsuarioModel model=null; 

            try 
            { 
                model = usuBL.VALIDAR_ACCESO(cod_usuario, pass_usuario);
                ViewBag.USUARIO = model.nom_usuario;
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }

            ViewBag.MENSAJE = mensaje;

            if (model==null)
            {
                return View();
            }
            else
            {
                return View("principal");
            }

            
        }



        public ActionResult registrarUsuario()
        {
            UsuarioModel model = new UsuarioModel();

            var lista = usuBL.Listar_Usuario();

            string codigo = "";

            foreach (var item in lista)
            {
                codigo = item.cod_usuario;

                int correlativo = int.Parse(codigo.Substring(5)) + 1;
                codigo = "USER" + correlativo.ToString("0000");

            }

            ViewBag.CODIGO_USUARIO = codigo;    

            ViewBag.LISTA_TIPOUSUARIO = new SelectList(dropdownBL.listTipoUsuario(),"id_dropdown","des_dropdown");

            return View(model);
        }

        [HttpPost]
        public ActionResult registrarUsuario(UsuarioModel obj)
        {
            var mensaje = usuBL.PA_INSERTAR_USUARIO(obj);
            var lista = usuBL.Listar_Usuario();
            string codigo = "";

            foreach (var item in lista)
            {
                codigo = item.cod_usuario;

                int correlativo =int.Parse( codigo.Substring(5)) + 1;
                codigo = "USER" + correlativo;

            }

            ViewBag.CODIGO_USUARIO = codigo;

            ViewBag.LISTA_TIPOUSUARIO = new SelectList(dropdownBL.listTipoUsuario(),"id_dropdown","des_dropdown");
            ViewBag.MENSAJE = mensaje;

            obj = new UsuarioModel();

            return View(obj);
        }
    }
}
