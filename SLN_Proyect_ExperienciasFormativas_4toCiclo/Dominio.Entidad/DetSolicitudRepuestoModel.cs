using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class DetSolicitudRepuestoModel
    {
        public string id_solRep { set; get; }
        public int item_det_solRep { set; get; } 
        public string artefacto_det_solRep { set; get; }
        public int cant_det_solRep { set; get; }
        public int cod_uniMed { set; get; }

    }
}
