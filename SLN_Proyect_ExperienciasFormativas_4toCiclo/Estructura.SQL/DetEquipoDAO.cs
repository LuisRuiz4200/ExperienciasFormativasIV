using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class DetEquipoDAO:ConexionSQL
    {

        public List<DetEquipoModel> listarDetEquipo()
        {

            var listado = new List<DetEquipoModel>();

            SqlDataReader dr =SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_DETEQUIPO");

            while (dr.Read()) 
            {
                DetEquipoModel model = new DetEquipoModel();
                model.cod_patrimonial = dr.GetString(0);
                model.cod_equipo = dr.GetInt32(1);
                model.cod_proveedor = dr.GetInt32(2);
                model.fecha_ingreso = dr.GetDateTime(3);
                model.estado_equipo = dr.GetString(4);

                listado.Add(model);

            }

            return listado;
        
        }


        public string registrarDetEquipo(DetEquipoModel obj)
        {
            string res;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_DETEQUIPO",obj.cod_patrimonial,obj.cod_equipo
                ,obj.cod_proveedor,obj.fecha_ingreso,obj.estado_equipo);

            if (valor > 0)
            {
                res = "Registrado correctamente!";
            }
            else
            {
                res = "Error de transaccion";

            }

            return res;
        }

    }
}
