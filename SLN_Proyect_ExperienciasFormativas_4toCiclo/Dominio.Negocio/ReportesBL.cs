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
    public class ReportesBL
    {
        ReportesDAO dao = new ReportesDAO();
        public List<ReporteMantenimientoModel> PA_REPORTE_MANTENIMIENTO()
        {
            var listado = dao.PA_REPORTE_MANTENIMIENTO();
            return listado;
        }

        public List<ReporteSolRepuestomModel> PA_REPORTE_SOLREPUESTOS(string id_sol)
        {
            var listado = dao.PA_REPORTE_SOLREPUESTOS(id_sol);
            return listado;
        }

        public List<ReporteEquiposModel> PA_REPORTE_EQUIPOS()
        {
            var listado = dao.PA_REPORTE_EQUIPOS();
            return listado;
        }
    }
}
