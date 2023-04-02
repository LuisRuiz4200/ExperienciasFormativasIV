using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class MantenimientoBL
    {
        MantenimientoDAO manDao = new MantenimientoDAO();

        public List<MantenimientoModel> Listar_Mantenimiento()
        {
            var listado = manDao.LISTAR_MANTENIMIENTO();
            return listado;
        }

        public string PA_INSERTAR_USUARIO(MantenimientoModel obj)
        {
            string mensaje = manDao.PA_INSERTAR_MANTENIMIENTO(obj);

            return mensaje; 
        }
    }
}
