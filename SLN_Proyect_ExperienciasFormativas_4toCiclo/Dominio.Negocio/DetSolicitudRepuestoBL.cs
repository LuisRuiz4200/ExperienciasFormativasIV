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
        public List<DetSolicitudRepuestoModel> PA_LISTAR_DETSOLREPUESTO()
        {
            return PA_LISTAR_DETSOLREPUESTO();
        }
        public string PA_INSERTAR_DETSOLREPUESTO(DetSolicitudRepuestoModel model)
        {
            return PA_INSERTAR_DETSOLREPUESTO(model);
        }
        public string PA_EDITAR_DETSOLREPUESTO(DetSolicitudRepuestoModel model)
        {
            return PA_EDITAR_DETSOLREPUESTO(model);
        }
        public string PA_ELIMINAR_DETSOLREPUESTO(DetSolicitudRepuestoModel model)
        {
            return PA_ELIMINAR_DETSOLREPUESTO(model);
        }

    }
}
