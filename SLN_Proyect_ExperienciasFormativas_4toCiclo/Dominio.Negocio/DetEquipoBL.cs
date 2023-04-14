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

        public string editarDetEquipo(DetEquipoModel obj)
        {
            return detEquipoDao.editarDetEquipo(obj);
        }

        /*public string eliminarDetEquipo(string cod_patrimonial)
        {
            return detEquipoDao.eliminarDetEquipo(cod_patrimonial);
        } */

        public string PA_CAMBIAR_ESTADO(string cod_patrimonial)
        {
            string mensaje = detEquipoDao.PA_CAMBIAR_ESTADO(cod_patrimonial);
            return mensaje;
        }

        public string PA_RESTAURAR_ESTADO(string cod_patrimonial)
        {
            string mensaje = detEquipoDao.PA_RESTAURAR_ESTADO(cod_patrimonial);
            return mensaje;
        }
    }
}
