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
        public string artefacto_det_solRep { get; set; }
        public string motivo_solRep { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/yyyy}")]
        public DateTime fecha_solRep { get; set; }
        public string estado_solRep { get; set; }
    }
}
