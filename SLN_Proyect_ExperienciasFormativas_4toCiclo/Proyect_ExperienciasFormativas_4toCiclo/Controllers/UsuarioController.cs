﻿using Dominio.Entidad;
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

            return View(model);
        }

        [HttpPost]
        public ActionResult login(UsuarioModel obj)
        {
            var listado = usuBL.Listar_Usuario();

            return View(listado);
        }
    }
}
