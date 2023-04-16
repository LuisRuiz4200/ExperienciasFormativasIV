using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class ReportesDAO : ConexionSQL
    {
        public List<ReporteMantenimientoModel> PA_REPORTE_MANTENIMIENTO()
        {

            var listado = new List<ReporteMantenimientoModel>();

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_REPORTE_MANTENIMIENTO");


            while (dr.Read())
            {
                ReporteMantenimientoModel obj = new ReporteMantenimientoModel();

                obj.id_mante = dr.GetString(0);
                obj.nom_equipo = dr.GetString(1);
                obj.tecnico = dr.GetString(2);
                obj.des_tipoMante = dr.GetString(3);
                obj.fecha_mante = dr.GetDateTime(4);

                listado.Add(obj);
            }

            dr.Close();
            return listado;

        }

        public List<ReporteSolRepuestomModel> PA_REPORTE_SOLREPUESTOS(string id_sol)
        {

            var listado = new List<ReporteSolRepuestomModel>();

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_REPORTE_SOLREPUESTOS", id_sol);


            while (dr.Read())
            {
                ReporteSolRepuestomModel obj = new ReporteSolRepuestomModel();

                obj.id_solRep = dr.GetString(0);
                obj.artefacto_det_solRep = dr.GetString(1);
                obj.motivo_solRep = dr.GetString(2);
                obj.fecha_solRep = dr.GetDateTime(3);
                obj.estado_solRep = dr.GetString(4);

                listado.Add(obj);
            }

            dr.Close();
            return listado;

        }

        public List<ReporteEquiposModel> PA_REPORTE_EQUIPOS()
        {

            var listado = new List<ReporteEquiposModel>();

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_REPORTE_EQUIPOS");


            while (dr.Read())
            {
                ReporteEquiposModel obj = new ReporteEquiposModel();

                obj.cod_patrimonial = dr.GetString(0);
                obj.nom_equipo = dr.GetString(1);
                obj.des_proveedor = dr.GetString(2);
                obj.fecha_ingreso = dr.GetDateTime(3);
                obj.estado_equipo = dr.GetString(4);

                listado.Add(obj);
            }

            dr.Close();
            return listado;

        }
    }
}
