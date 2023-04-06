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

        public UsuarioModel VALIDAR_ACCESO(string cod_usuario, string pass_usuario)
        {
            UsuarioModel PA_VALIDAR = usuDao.PA_VALIDAR_ACCESO(cod_usuario, pass_usuario);

            return PA_VALIDAR;
        }
        public List<UsuarioModel> Listar_Usuario()
        { 
            var listado = usuDao.LISTAR_USUARIOS();

            return listado;
        }
        
        public string PA_INSERTAR_USUARIO(UsuarioModel obj)
        {
            string mensaje = usuDao.PA_INSERTAR_USUARIO(obj);

            return mensaje;
        }

    }
}
