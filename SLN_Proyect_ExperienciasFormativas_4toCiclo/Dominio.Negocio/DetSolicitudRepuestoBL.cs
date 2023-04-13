using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class DetSolicitudRepuestoBL
    {

        DetSolicitudRepuestoDAO detSolRepDao = new DetSolicitudRepuestoDAO();

        public List<DetSolicitudRepuestoModel> PA_LISTAR_DETSOLREPUESTO()
        {
            return detSolRepDao.PA_LISTA_DETSOLREPUESTO();
        }
        public string PA_INSERTAR_DETSOLREPUESTO(DetSolicitudRepuestoModel model)
        {
            return detSolRepDao.PA_INSERTAR_DETSOLREPUESTO(model);
        }
        public string PA_EDITAR_DETSOLREPUESTO(DetSolicitudRepuestoModel model)
        {
            return detSolRepDao.PA_EDITAR_DETSOLREPUESTO(model);
        }
        public string PA_ELIMINAR_DETSOLREPUESTO(DetSolicitudRepuestoModel model)
        {
            return detSolRepDao.PA_ELIMINAR_DETSOLREPUESTO(model);
        }
        public List<DetSolicitudRepuestoModel> PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(string id_solRep)
        {
            return detSolRepDao.PA_LISTAR_DETSOLREPUESTO_POR_IDSOLREP(id_solRep);
        }
    }
}
