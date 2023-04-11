using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class DetSolicitudRepuestoDAO:ConexionSQL
    {
        public List<DetSolicitudRepuestoModel> PA_LISTA_DETSOLREPUESTO() 
        {
            var lista = new List<DetSolicitudRepuestoModel>();
            DetSolicitudRepuestoModel model;

            SqlDataReader dr = SqlHelper.ExecuteReader(CAD_CN, "PA_LISTAR_DETSOLREPUESTO");

            while (dr.Read())
            {
                model = new DetSolicitudRepuestoModel();
                model.id_solRep = dr.GetString(0);
                model.item_det_solRep = dr.GetInt32(1);
                model.artefacto_det_solRep = dr.GetString(2);
                model.cant_det_solRep = dr.GetInt32(3);
                model.cod_uniMed = dr.GetInt32(4);
                lista.Add(model);
            }

            dr.Close();

            return lista;
        }

        public string PA_INSERTAR_DETSOLREPUESTO(DetSolicitudRepuestoModel obj)
        {

            string mensaje;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_DETSOLREPUESTO", obj.id_solRep, obj.artefacto_det_solRep, obj.cant_det_solRep, obj.cod_uniMed);
            if (valor == 0)
            {

                mensaje = $"{obj.artefacto_det_solRep} AGREGADO CORRECTAMENTE EN LA SOLICITUD {obj.id_solRep}";
            }
            else {
                mensaje = "ERROR EN LA OPERACION SQL";
            }


            return mensaje;
        }

        public string PA_EDITAR_DETSOLREPUESTO(DetSolicitudRepuestoModel obj)
        {

            string mensaje;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_EDITAR_DETSOLREPUESTO", obj.id_solRep,obj.item_det_solRep, obj.artefacto_det_solRep, obj.cant_det_solRep, obj.cod_uniMed);
            if (valor == 0)
            {

                mensaje = $"{obj.item_det_solRep} EDITADO CORRECTAMENTE EN LA SOLICITUD {obj.id_solRep}";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }


            return mensaje;
        }

        public string PA_ELIMINAR_DETSOLREPUESTO(DetSolicitudRepuestoModel obj)
        {

            string mensaje;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_ELIMINAR_DETSOLREPUESTO", obj.id_solRep, obj.item_det_solRep);
            if (valor == 0)
            {

                mensaje = $"{obj.item_det_solRep} EDITADO CORRECTAMENTE EN LA SOLICITUD {obj.id_solRep}";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }


            return mensaje;
        }
    }
}
