using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class MantenimientoDAO : ConexionSQL
    {
        public List<MantenimientoModel> PA_LISTAR_MANTENIMIENTO()
        {

            var listado = new List<MantenimientoModel>();

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_MANTENIMIENTO");


            while (dr.Read())
            {
                MantenimientoModel objMante = new MantenimientoModel();

                objMante.id_mante = dr.GetString(0);
                objMante.cod_patrimonial = dr.GetString(1);
                objMante.cod_tecnico = dr.GetString(2);
                objMante.cod_tipoMante = dr.GetInt32(3);
                objMante.obs_tipoMante = dr.GetString(4);
                objMante.estado_equipo = dr.GetString(5);
                objMante.fecha_mante = dr.GetDateTime(6);
                objMante.estado_mante = dr.GetString(7);


                listado.Add(objMante);
            }

            dr.Close();
            return listado;

        }

        public string PA_INSERTAR_MANTENIMIENTO(MantenimientoModel obj)
        {

            string mensaje;
            int correlativo = 0;
            string codigo = "";

            var listado = PA_LISTAR_MANTENIMIENTO();


            if (listado.Count > 0)
            {
                foreach (var mant in listado)
                {
                    correlativo = int.Parse(mant.id_mante.Substring(6));
                    correlativo = correlativo + 1;
                    codigo = "MAN" + correlativo.ToString("000000");
                }

            }
            else
            {
                codigo = "MAN000001";
            
            }
            

            int res = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_MANTENIMIENTO", codigo, obj.cod_patrimonial, obj.cod_tecnico, obj.cod_tipoMante, obj.obs_tipoMante, obj.estado_equipo, obj.fecha_mante, obj.estado_mante);

            if (res != 0)
            {
                mensaje = $"Mantenimiento {correlativo} registrado";
            }
            else
            {
                mensaje = "Error en la transacción";
            }

            return mensaje;
        }
    }
}
