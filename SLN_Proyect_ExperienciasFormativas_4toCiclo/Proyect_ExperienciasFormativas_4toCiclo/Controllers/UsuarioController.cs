using Dominio.Entidad;
using Dominio.Negocio;
using System;
using System.Collections.Generic;
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

        public ActionResult registrarUsuario()
        {
            UsuarioModel model = new UsuarioModel();

            ViewBag.LISTA_TIPOUSUARIO = new SelectList(dropdownBL.listTipoUsuario(),"id_dropdown","des_dropdown");

            return View(model);
        }

        [HttpPost]
        public ActionResult registrarUsuario(UsuarioModel obj)
        {
            var mensaje = usuBL.PA_INSERTAR_USUARIO(obj);

            ViewBag.LISTA_TIPOUSUARIO = new SelectList(dropdownBL.listTipoUsuario(),"id_dropdown","des_dropdown");
            ViewBag.MENSAJE = mensaje;

            obj = new UsuarioModel();

            return View(obj);
        }
    }
}
