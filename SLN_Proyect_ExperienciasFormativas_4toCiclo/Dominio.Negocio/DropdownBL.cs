﻿using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class DropdownBL
    {
        DropdownDAO objDao = new DropdownDAO();

        public List<DropdownModel> listTipoMante()
        {
            var lista = objDao.listTipoMante();
            return lista;
        }

        public List<DropdownModel> listTecnico()
        {
            var lista = objDao.listTecnico();
            return lista;

        }
        public List<DropdownModel> listEquipo()
        {
            var lista = objDao.listEquipo();
            return lista;

        }

        public List<DropdownModel> listProveedor()
        {
            var lista = objDao.listProveedor();
            return lista;

        }


        public List<DropdownModel> listTipoUsuario()
        {
            var lista = objDao.listTipoUsuario();
            return lista;

        }

        public List<DropdownModel> listUnidadMedida() 
        {
            var lista = objDao.listUnidadMedida();

            return lista;
        }



    }
}
