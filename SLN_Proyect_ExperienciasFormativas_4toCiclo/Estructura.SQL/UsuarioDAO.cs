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
        public UsuarioModel PA_VALIDAR_ACCESO(string cod_usuario, string pass_usuario)
        {
            SqlConnection conexion = new SqlConnection(CAD_CN);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_usuario where cod_usuario=@codigo and pass_usuario=@password", conexion);
            cmd.Parameters.AddWithValue("@codigo", cod_usuario);
            cmd.Parameters.AddWithValue("@password", pass_usuario);
            SqlDataReader dr = cmd.ExecuteReader();
            UsuarioModel usuarioModel=null; 
            if (dr.Read())
            {
                usuarioModel = new UsuarioModel();
                usuarioModel.cod_usuario = dr.GetString(0);
                usuarioModel.nom_usuario= dr.GetString(1);
                usuarioModel.ape_usuario= dr.GetString(2);
                usuarioModel.pass_usuario = dr.GetString(3);
                usuarioModel.tipo_usuario = dr.GetInt32(4);
            }
            return usuarioModel;

        }



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
                    pass_usuario = dr.GetString(3),
                    tipo_usuario = dr.GetInt32(4)
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

            if (listado.Count > 0)
            {
                foreach (var usu in listado)
                {
                    correlativo = int.Parse(usu.cod_usuario.Substring(4));
                    correlativo = correlativo + 1;
                    codigo = "USER" + correlativo.ToString("0000");
                }
            }
            else {

                codigo = "USER0001";
            }

            try
            {
                int res = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_USUARIO", codigo, obj.nom_usuario, obj.ape_usuario, obj.pass_usuario, obj.tipo_usuario);

                if (res != 0)
                {
                    mensaje = $"Tecnico {correlativo} registrado";
                }
                else
                {
                    mensaje = "Error en la transaccion";
                }
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }
    }
}
