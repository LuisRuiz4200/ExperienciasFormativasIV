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

            dr.Close();

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

        public string editarDetEquipo(DetEquipoModel obj)
        {
            string mensaje;
            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_EDITAR_DETEQUIPO", obj.cod_patrimonial, obj.cod_equipo, obj.cod_proveedor, obj.fecha_ingreso, obj.estado_equipo);

            if (valor != 0)
            {
                mensaje = $"{obj.cod_patrimonial} ACTUALIZADO CORRECTAMENTE";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }
            return mensaje;
        }

        /*
        public string eliminarDetEquipo(string cod_patrimonial)
        { 
            string mensaje;
            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_ELIMINAR_DETEQUIPO", cod_patrimonial);
            if (valor != 0)
            {
                mensaje = $"{cod_patrimonial} ELIMINADO CORRECTAMENTE";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }
            return mensaje;
                
        } */

        public string PA_CAMBIAR_ESTADO(string cod_patrimonial)
        {
            string mensaje;
            string cad_sql = "update tb_det_equipo set " +
                "estado_equipo=@estado_equipo where cod_patrimonial=@cod_patrimonial";
            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql, con);
                cmd.Parameters.AddWithValue("@estado_equipo", "INACTIVO");
                cmd.Parameters.AddWithValue("cod_patrimonial", cod_patrimonial);
                cmd.ExecuteNonQuery();

                mensaje = $"{cod_patrimonial} DADO DE BAJA";
                con.Close();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }
        public string PA_RESTAURAR_ESTADO(string cod_patrimonial)
        {
            string mensaje;
            string cad_sql = "update tb_det_equipo set " +
                "estado_equipo=@estado_equipo where cod_patrimonial=@cod_patrimonial";
            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql, con);
                cmd.Parameters.AddWithValue("@estado_equipo", "ACTIVO");
                cmd.Parameters.AddWithValue("cod_patrimonial", cod_patrimonial);
                cmd.ExecuteNonQuery();

                mensaje = $"{cod_patrimonial} RESTAURADO";
                con.Close();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;

        }
       
        

    }
}
