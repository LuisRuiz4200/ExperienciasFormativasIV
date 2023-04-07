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
        public ActionResult login(string cod_usuario=null, string pass_usuario=null)
        {

            string mensaje="";
            string vista;
            UsuarioModel model=null; 

            try 
            { 
                model = usuBL.VALIDAR_ACCESO(cod_usuario, pass_usuario);

                if(model != null) {
                    ViewBag.USUARIO = model.nom_usuario;
                }
                
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }


            if (model==null)
            {
                mensaje = "Credenciales incorrectas, POSIBLE HACKER";
                vista = "login";

            }
            else
            {
                mensaje = $"BIENVENIDO {model.nom_usuario} AL SISTEMA HISTORY MEDIC";
                vista = "principal";
            }


            ViewBag.MENSAJE = mensaje;

            return View(vista);



            
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
