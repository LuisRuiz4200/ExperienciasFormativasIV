using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class SolicitudRepuestoBL
    {
        SolicitudRepuestoDAO solRepDao = new SolicitudRepuestoDAO();

        public List<SolicitudRepuestoModel> PA_LISTAR_SOLICITUDREPUESTO ()
        {
            return solRepDao.PA_LISTAR_SOLICITUDREPUESTO();
        }
        public string PA_INSERTAR_SOLICITUDREPUESTO(SolicitudRepuestoModel model)
        {

            return solRepDao.PA_INSERTAR_SOLICITUDREPUESTO(model);
        }
        public string PA_EDITAR_SOLICITUDREPUESTO(SolicitudRepuestoModel model)
        {

            return solRepDao.PA_EDITAR_SOLICITUDREPUESTO(model);
        }
        public string PA_ELIMINAR_SOLICITUDREPUESTO(SolicitudRepuestoModel model)
        {

            return solRepDao.PA_ELIMINAR_SOLICITUDREPUESTO(model);
        }

    }
}
