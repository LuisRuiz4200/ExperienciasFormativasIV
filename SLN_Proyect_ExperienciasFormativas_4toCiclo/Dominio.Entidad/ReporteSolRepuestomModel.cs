using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class ReporteSolRepuestomModel
    {
        public string id_solRep { get; set; }
        public int item_det_solRep { get; set; }
        public string artefacto_det_solRep { get; set; }
        public int cant_det_solRep { get; set; }
        public string des_uniMed { get; set; }
    }
}
