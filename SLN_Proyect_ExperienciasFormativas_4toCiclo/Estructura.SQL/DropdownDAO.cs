using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class DropdownDAO:ConexionSQL
    {
        public List<DropdownModel> listTipoMante()
        {
            var list = new List<DropdownModel>();
            try {
                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                string sql2 = "select * from tb_tipoMante";

                SqlCommand cmd = new SqlCommand(sql2, con);

                SqlDataReader dr = cmd.ExecuteReader ();

                while (dr.Read())
                {
                    DropdownModel obj = new DropdownModel()
                    {
                        id_dropdown = dr.GetInt32(0).ToString(),
                        des_dropdown = dr.GetString(1),

                    };

                    list.Add(obj);
                }

            }
            catch (SqlException sqlEx) 
            {
                string mensaje = sqlEx.Message;

            }
            return list;
        
        }

        public List<DropdownModel> listTecnico()
        {

            var list = new List<DropdownModel>();

            try
            {

                SqlConnection con = new SqlConnection(CAD_CN);
                con.Open();
                string sql2 = "select cod_tecnico, nom_tecnico  from tb_tecnico";

                SqlCommand cmd = new SqlCommand(sql2, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DropdownModel obj = new DropdownModel()
                    {
                        id_dropdown = dr.GetString(0),
                        des_dropdown = dr.GetString(1),

                    };

                    list.Add(obj);

                }

            }
            catch (SqlException sqlEx)
            {

                string mensaje = sqlEx.Message;


            }



            return list;

        }
    }
}
