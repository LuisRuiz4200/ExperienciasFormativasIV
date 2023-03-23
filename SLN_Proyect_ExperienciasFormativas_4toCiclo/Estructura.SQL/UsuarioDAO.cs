using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructura.SQL;

namespace Estructura.SQL
{
    public class UsuarioDAO : ConexionSQL
    {
        public List<UsuarioModel> LISTAR_USUARIOS()
        {
            var listado = new List<UsuarioModel>();
            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_USUARIO");
            while (dr.Read())
            {
                var objUsuario = new UsuarioModel()
                {
                    cod_usuario = dr.GetString(0),
                    nom_usuario = dr.GetString(1),
                    ape_usuario = dr.GetString(2),
                    tipo_usuario = dr.GetInt32(2)
                };
                listado.Add(objUsuario);
            }
            dr.Close();
            return listado;
        }
    }
}
