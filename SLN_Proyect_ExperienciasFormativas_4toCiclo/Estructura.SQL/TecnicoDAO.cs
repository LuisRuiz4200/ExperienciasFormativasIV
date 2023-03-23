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

            SqlConnection con = new SqlConnection(ConexionSQL.CAD_CN);

            con.Open();

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_TECNICO");

            TecnicoModel objTecnico = new TecnicoModel();
            
            while (dr.Read())
            {
                objTecnico.cod_tecnico = dr.GetString(0);
                objTecnico.nom_tecnico = dr.GetString (1);
                objTecnico.ape_tecnico = dr.GetString(2);
                objTecnico.estado_tecnico = dr.GetString(3);

                listado.Add(objTecnico);
            }

            return listado;
        
        }

    }
}
