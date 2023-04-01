using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer.Server;

namespace Estructura.SQL
{
    public class TecnicoDAO:ConexionSQL
    {

        public List<TecnicoModel> PA_LISTAR_TECNICO() {

            var listado = new List<TecnicoModel>();

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_TECNICO");

            
            while (dr.Read())
            {
                TecnicoModel objTecnico = new TecnicoModel();

                objTecnico.cod_tecnico = dr.GetString(0);
                objTecnico.nom_tecnico = dr.GetString (1);
                objTecnico.ape_tecnico = dr.GetString(2);
                objTecnico.estado_tecnico = dr.GetString(3);

                listado.Add(objTecnico);
            }

            return listado;
        
        }

        public string PA_INSERTAR_TECNICO(TecnicoModel obj)
        {

            string mensaje;
            int correlativo = 0;
            string codigo = "";

            var listado = PA_LISTAR_TECNICO();

            foreach (var tec in listado) 
            {
                correlativo = int.Parse( tec.cod_tecnico.Substring(3));
                correlativo = correlativo + 1;
                codigo = "TEC" + correlativo.ToString("000");
            }

            int res= SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_TECNICO", codigo ,obj.nom_tecnico,obj.ape_tecnico,obj.estado_tecnico);

            if (res != 0)
            {
                mensaje = $"Tecnico {correlativo} registrado";
            }
            else 
            {
                mensaje = "Error en la transacción";
            }

            return mensaje;
        }
    }
}
