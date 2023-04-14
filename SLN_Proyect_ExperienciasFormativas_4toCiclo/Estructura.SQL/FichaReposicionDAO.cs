using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class FichaReposicionDAO : ConexionSQL
    {
        public List<FichaReposicionModel> PA_LISTAR_FICHAREPOSICION()
        {
            var lista = new List<FichaReposicionModel>();
            FichaReposicionModel objFichaRepo;

            SqlDataReader rd = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_FICHAREPOS");
            while (rd.Read())
            {
                objFichaRepo = new FichaReposicionModel();

                objFichaRepo.id_fichaRepo = rd.GetString(0);
                objFichaRepo.cod_patrimonial = rd.GetString(1);
                objFichaRepo.motivo_fichaRepo = rd.GetString(2);
                objFichaRepo.fecha_fichaRepo = rd.GetDateTime(3);
                objFichaRepo.estado_fichaRepo = rd.GetString(4);

                lista.Add(objFichaRepo);
            }
            return lista;
        }

        public string PA_INSERTAR_FICHAREPOSICION(FichaReposicionModel obj)
        {
            string mensaje;
            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_FICHAREPOS", obj.id_fichaRepo, obj.cod_patrimonial, obj.motivo_fichaRepo, obj.fecha_fichaRepo, obj.estado_fichaRepo);

            if (valor == 0)
            {
                mensaje = $"{obj.id_fichaRepo} REGISTRADO CORRECTAMENTE";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }
            return mensaje;
        }

        public string PA_EDITAR_FICHAREPOSICION(FichaReposicionModel obj)
        {
            string mensaje;
            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_EDITAR_FICHAREPOSICION", obj.id_fichaRepo, obj.cod_patrimonial, obj.motivo_fichaRepo, obj.fecha_fichaRepo, obj.estado_fichaRepo);

                if (valor != 0)
                {
                mensaje = $"{obj.id_fichaRepo} ACTUALIZADO CORRECTAMENTE";
                }
                else
                {
                mensaje = "ERROR EN LA OPERACION SQL";
                }
                return mensaje;
        }

        public string PA_ELIMINAR_FICHAREPOSICION(FichaReposicionModel obj)
        {
            string mensaje;
            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_ELIMINAR_FICHAREPOSICION", obj.id_fichaRepo);
            if (valor != 0)
            {
                mensaje = $"{obj.id_fichaRepo} ELIMINADO CORRECTAMENTE";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }
            return mensaje;
        }

        public FichaReposicionModel PA_BUSCAR_SOLICITUDREPOSICION_POR_IDFICHAREPO(string id_fichaRepo)
        {
            FichaReposicionModel obj = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_BUSCAR_SOLICITUDREPOSICION_POR_IDFICHAREPO", id_fichaRepo);
            if (dr.Read())
            {
                obj = new FichaReposicionModel();

                obj.id_fichaRepo = dr.GetString(0);
                obj.cod_patrimonial = dr .GetString(1); 
                obj.motivo_fichaRepo = dr.GetString (2);
                obj.fecha_fichaRepo = dr.GetDateTime(3);
                obj.estado_fichaRepo = dr.GetString(4);
            }
            return obj;
        }

    }
}
