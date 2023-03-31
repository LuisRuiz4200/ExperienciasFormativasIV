using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class TecnicoBL
    {

        TecnicoDAO tecDao = new TecnicoDAO();

        public List<TecnicoModel> PA_LISTAR_TECNICO()
        { 
            var listado = tecDao.PA_LISTAR_TECNICO();

            return listado;
        
        }

        public string PA_INSERTAR_TECNICO(TecnicoModel obj)
        {
            string mensaje = tecDao.PA_INSERTAR_TECNICO(obj);

            return mensaje;

        }
    }


}
