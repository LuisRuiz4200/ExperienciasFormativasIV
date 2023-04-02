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
        public string PA_INSERTAR_USUARIO(UsuarioModel obj)
        {
            string mensaje;
            int correlativo = 0;
            string codigo = "";

            var listado = LISTAR_USUARIOS();

            foreach (var usu in listado)
            {
                correlativo = int.Parse(usu.cod_usuario.Substring(3));
                correlativo = correlativo + 1;
                codigo = "USU" + correlativo.ToString("000");
            }
            int res = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_USUARIO", codigo, obj.nom_usuario, obj.ape_usuario, obj.tipo_usuario);

            if (res != 0)
            {
                mensaje = $"Tecnico {correlativo} registrado";
            }
            else
            {
                mensaje = "Error en la transaccion";
            }
            return mensaje;
        }
    }
}
