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

            dr.Close();

            return listado;
        
        }

        public List<TecnicoModel> PA_LISTAR_TECNICO_POR_ESTADO(string estado_tecnico)
        {

            var listado = new List<TecnicoModel>();

            string cad_sql = "select * from tb_tecnico where estado_tecnico = @estado_tecnico";

            try { 
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql,con);
                cmd.Parameters.AddWithValue("@estado_tecnico", estado_tecnico);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TecnicoModel objTecnico = new TecnicoModel();

                    objTecnico.cod_tecnico = dr.GetString(0);
                    objTecnico.nom_tecnico = dr.GetString(1);
                    objTecnico.ape_tecnico = dr.GetString(2);
                    objTecnico.estado_tecnico = dr.GetString(3);

                    listado.Add(objTecnico);
                }
                con.Close();
                dr.Close();
            }
            catch (SqlException ex) 
            {
                return null;
            }



            return listado;

        }

        public string PA_INSERTAR_TECNICO(TecnicoModel obj)
        {

            string mensaje;
            int correlativo;
            string codigo = "";

            var listado = PA_LISTAR_TECNICO();


            if (listado.Count !=0)
            {

                foreach (var tec in listado)
                {
                    correlativo = int.Parse(tec.cod_tecnico.Substring(3));
                    correlativo = correlativo + 1;
                    codigo = "TEC" + correlativo.ToString("00000");
                }

            }
            else {

                codigo = "TEC00001";
            
            }
            

            int res= SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_TECNICO", codigo ,obj.nom_tecnico,obj.ape_tecnico,"ACTIVO");

            if (res != 0)
            {
                mensaje = $"Tecnico {codigo} registrado";
            }
            else 
            {
                mensaje = "Error en la transacción";
            }

            return mensaje;
        }

        public string PA_EDITAR_TECNICO (TecnicoModel obj) 
        {
            string mensaje;
            string cad_sql = "update tb_tecnico set " +
                "nom_tecnico=@nom_tecnico, ape_tecnico =@ape_tecnico where cod_tecnico=@cod_tecnico";

            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql,con);
                cmd.Parameters.AddWithValue("@nom_tecnico",obj.nom_tecnico);
                cmd.Parameters.AddWithValue("@ape_tecnico", obj.ape_tecnico);
                cmd.Parameters.AddWithValue("@cod_tecnico", obj.cod_tecnico);
                cmd.ExecuteNonQuery();

                mensaje = $"{obj.cod_tecnico} ACTUALIZADO CORRECTAMENTE";

                con.Close();
            }
            catch (SqlException ex)
            { 
                mensaje= ex.Message;
            }

            return mensaje;
        }

        public string PA_ELIMINAR_TECNICO(string cod_Tecnico)
        {
            string mensaje;
            string cad_sql = "update tb_tecnico set " +
                "estado_tecnico=@estado_tecnico where cod_tecnico=@cod_tecnico";

            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql, con);
                cmd.Parameters.AddWithValue("@estado_tecnico", "INACTIVO");
                cmd.Parameters.AddWithValue("@cod_tecnico", cod_Tecnico);
                cmd.ExecuteNonQuery();

                mensaje = $"{cod_Tecnico} DADO DE BAJA";

                con.Close();
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }


        public string PA_RESTAURAR_TECNICO(string cod_Tecnico)
        {
            string mensaje;
            string cad_sql = "update tb_tecnico set " +
                "estado_tecnico=@estado_tecnico where cod_tecnico=@cod_tecnico";

            try
            {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                SqlCommand cmd = new SqlCommand(cad_sql, con);
                cmd.Parameters.AddWithValue("@estado_tecnico", "ACTIVO");
                cmd.Parameters.AddWithValue("@cod_tecnico", cod_Tecnico);
                cmd.ExecuteNonQuery();

                mensaje = $"{cod_Tecnico} RESTAURADO";

                con.Close();
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

    }
}
