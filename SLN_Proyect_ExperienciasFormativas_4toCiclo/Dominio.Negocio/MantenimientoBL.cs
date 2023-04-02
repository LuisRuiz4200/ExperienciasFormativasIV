using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class MantenimientoBL
    {
        MantenimientoDAO dao = new MantenimientoDAO();

        public List<MantenimientoModel> PA_LISTAR_MANTENIMIENTO()
        {
            var listado = dao.PA_LISTAR_MANTENIMIENTO();
            return listado;

        }

        public string PA_INSERTAR_MANTENIMIENTO(MantenimientoModel obj)
        {
            var mensaje = dao.PA_INSERTAR_MANTENIMIENTO(obj);
            return mensaje;
        }
    }
}
