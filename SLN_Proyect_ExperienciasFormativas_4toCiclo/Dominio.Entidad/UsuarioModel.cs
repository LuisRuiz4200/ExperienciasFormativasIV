using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class UsuarioModel
    {
        public string cod_usuario { set; get; }
        public string nom_usuario { set; get; }
        public string ape_usuario { set; get; }
        public int tipo_usuario { set;get; }

        public List<UsuarioModel> LISTAR_USUARIOS()
        {
            throw new NotImplementedException();
        }
    }
}
