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
        UsuarioModel dao = new UsuarioModel();

        public List<UsuarioModel> Listar_Usuario()
        { 
          return dao.LISTAR_USUARIOS();
        }
    }
}
