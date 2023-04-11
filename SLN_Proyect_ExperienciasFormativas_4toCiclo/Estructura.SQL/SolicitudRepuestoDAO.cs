using Dominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura.SQL
{
    public class SolicitudRepuestoDAO:ConexionSQL
    {
        public List<SolicitudRepuestoModel> PA_LISTAR_SOLICITUDREPUESTO()
        {
            var lista=new List<SolicitudRepuestoModel>();
            SolicitudRepuestoModel objFichaRepo;

            SqlDataReader rd = SqlHelper.ExecuteReader(CAD_CN,"PA_LISTAR_SOLICITUDREPUESTO");

            while (rd.Read()) 
            {
                objFichaRepo= new SolicitudRepuestoModel();

                objFichaRepo.id_solRep = rd.GetString(0);
                objFichaRepo.cod_patrimonial = rd.GetString(1);
                objFichaRepo.motivo_solRep   = rd.GetString(2);
                objFichaRepo.fecha_solRep = rd.GetDateTime(3);
                objFichaRepo.estado_solRep = rd.GetString(4);

                lista.Add(objFichaRepo);
            }

            return lista;
        
        }

        public string PA_INSERTAR_SOLICITUDREPUESTO(SolicitudRepuestoModel obj)
        {
            
            string mensaje;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_INSERTAR_SOLICITUDREPUESTO", obj.id_solRep,obj.cod_patrimonial,obj.motivo_solRep,obj.fecha_solRep,obj.estado_solRep);

            if (valor != 0)
            {
                mensaje = $"{obj.id_solRep} REGISTRADO CORRECTAMENTE";
            }
            else {
                mensaje = "ERROR EN LA OPERACION SQL";
            }

            return mensaje;

        }

        public string PA_EDITAR_SOLICITUDREPUESTO(SolicitudRepuestoModel obj)
        {

            string mensaje;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_EDITAR_SOLICITUDREPUESTO",obj.id_solRep, obj.cod_patrimonial, obj.motivo_solRep, obj.fecha_solRep, obj.estado_solRep);

            if (valor != 0)
            {
                mensaje = $"{obj.id_solRep} ACTUALIZADO CORRECTAMENTE";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }

            return mensaje;

        }

        public string PA_ELIMINAR_SOLICITUDREPUESTO(SolicitudRepuestoModel obj)
        {

            string mensaje;

            int valor = SqlHelper.ExecuteNonQuery(CAD_CN, "PA_ELIMINAR_SOLICITUDREPUESTO",obj.id_solRep);

            if (valor != 0)
            {
                mensaje = $"{obj.id_solRep} ELIMINADO CORRECTAMENTE";
            }
            else
            {
                mensaje = "ERROR EN LA OPERACION SQL";
            }

            return mensaje;

        }
    }
}
