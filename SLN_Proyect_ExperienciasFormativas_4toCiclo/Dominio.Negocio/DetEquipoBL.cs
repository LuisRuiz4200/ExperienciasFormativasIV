using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructura.SQL;

namespace Dominio.Negocio
{

    public class DetEquipoBL
    {
        DetEquipoDAO detEquipoDao = new DetEquipoDAO();

        public List<DetEquipoModel> listarDetEquipo()
        {
            return detEquipoDao.listarDetEquipo();
        
        }

        public string registrarDetEquipo(DetEquipoModel obj)
        {

            return detEquipoDao.registrarDetEquipo(obj);
        }
    }
}
