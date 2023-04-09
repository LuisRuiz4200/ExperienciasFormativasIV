using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructura.SQL;
using System.Net.NetworkInformation;

namespace Estructura.SQL
{
    public class UsuarioDAO : ConexionSQL
    {
        public UsuarioModel PA_VALIDAR_ACCESO(string cod_usuario, string pass_usuario)
        {

            UsuarioModel usuarioModel = null;

            SqlConnection conexion = new SqlConnection(CAD_CN);
            conexion.Open();

            SqlCommand cmd = new SqlCommand("select * from tb_usuario where cod_usuario=@codigo and pass_usuario=@password", conexion);
            cmd.Parameters.AddWithValue("@codigo", cod_usuario);
            cmd.Parameters.AddWithValue("@password", pass_usuario);
            SqlDataReader dr = cmd.ExecuteReader();
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

        public UsuarioModel PA_BUSCAR_USUARIO(string cod_usuario) 
        {
            string cad_sql = "select * from where cod_usuario=@cod_usuario";
            UsuarioModel objUsuario= null;

            try 
            { 
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql,con);
                cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read()) 
                { 
                    objUsuario = new UsuarioModel();
                    objUsuario.cod_usuario = dr.GetString(0);
                    objUsuario.nom_usuario = dr.GetString (1);
                    objUsuario.ape_usuario = dr.GetString(2);
                    objUsuario.pass_usuario = dr.GetString(3);
                    objUsuario.tipo_usuario = dr.GetInt32 (4);

                }

            }catch(SqlException ex) 
            {
                return null;
            }
            return objUsuario;
        }

        public string PA_EDITAR_USUARIO(UsuarioModel obj) 
        {
            String cad_sql = "update tb_usuario set" +
                " nom_usuario=@nom_usuario, ape_usuario=@ape_usuario, pass_usuario=@pass_usuario, tipo_usuario=@tipo_usuario" +
                " where cod_usuario = @cod_usuario";
            String mensaje;
            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand sql = new SqlCommand(cad_sql,con);

                sql.Parameters.AddWithValue("@nom_usuario", obj.nom_usuario);
                sql.Parameters.AddWithValue("@ape_usuario", obj.ape_usuario);
                sql.Parameters.AddWithValue("@pass_usuario", obj.pass_usuario);
                sql.Parameters.AddWithValue("@tipo_usuario", obj.tipo_usuario);
                sql.Parameters.AddWithValue("@cod_usuario", obj.cod_usuario);

                sql.ExecuteNonQuery();

                mensaje = $"{obj.cod_usuario}  {obj.nom_usuario} actualizado correctamente";
                
            }
            catch (SqlException ex)
            { 
                mensaje=ex.Message;
            }
            

            return mensaje;
        }

        public string PA_ELIMINAR_USUARIO(string cod_usuario)
        {
            string cad_sql = "delete from tb_usuario where cod_usuario=@cod_usuario";
            string mensaje;
            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand sql = new SqlCommand(cad_sql, con);

                sql.Parameters.AddWithValue("@cod_usuario", cod_usuario);

                sql.ExecuteNonQuery();

                mensaje = $"{cod_usuario} eliminado correctamente";

            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }


            return mensaje;
        }
    }
    
}
