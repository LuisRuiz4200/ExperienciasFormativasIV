using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidad;
using Estructura.SQL;

namespace Dominio.Negocio
{
    public class UsuarioBL
    {
        UsuarioDAO usuDao = new UsuarioDAO();

        public List<UsuarioModel> Listar_Usuario()
        { 
            var listado = usuDao.LISTAR_USUARIOS();

            return listado;
        }
    }
}
