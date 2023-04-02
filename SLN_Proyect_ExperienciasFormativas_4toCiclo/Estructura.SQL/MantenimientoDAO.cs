using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidad;
using System.Data.SqlClient;
using Estructura.SQL;

namespace Estructura.SQL
{
    public class MantenimientoDAO : ConexionSQL
    {
        public List<MantenimientoModel> LISTAR_MANTENIMIENTO()
        {
            var listado = new List<MantenimientoModel>();
            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_MANTENIMIENTO");
            while (dr.Read()) 
            {
                var objMantenimiento = new MantenimientoModel()
                {
                    id_mante = dr.GetString(0),
                    cod_patrimonial = dr.GetString(1),
                    cod_tecnico = dr.GetString(2),
                    cod_tipoMante = dr.GetInt32(3),
                    obs_tipoMante = dr.GetString(4),
                    estado_equipo = dr.GetString(5),
                    fecha_mante = dr.GetDateTime(6),
                    estado_mante = dr.GetString(7)
                };
                listado.Add(objMantenimiento);
            }
            dr.Close();
            return listado;
        }

        public string PA_INSERTAR_MANTENIMIENTO(MantenimientoModel obj)
        {
            string mensaje;
            int correlativo = 0;
            string codigo = "";

            var listado = LISTAR_MANTENIMIENTO();
            foreach (var usu in listado)
            {
                correlativo = int.Parse(usu.id_mante.Substring(3));
                correlativo = correlativo + 1;
                codigo = "MAN" + correlativo.ToString("000");
            }
            int res = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_MANTENIMIENTO", codigo, obj.cod_patrimonial, obj.cod_tecnico, obj.cod_tipoMante, obj.obs_tipoMante, obj.estado_equipo, obj.fecha_mante, obj.estado_mante);

            if (res != 0)
            {
                mensaje = $"Mantenimiento{correlativo} registrado";
            }
            else
            {
                mensaje = "Error en la transaccion";
            }
            return mensaje;
        }
    }
}
