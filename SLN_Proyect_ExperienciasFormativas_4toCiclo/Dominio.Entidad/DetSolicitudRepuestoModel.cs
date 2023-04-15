using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class DetSolicitudRepuestoModel
    {
        [Required]
        public string id_solRep { set; get; }
        [Required]
        public int item_det_solRep { set; get; }
        [Required]
        public string artefacto_det_solRep { set; get; }
        [Required]
        public int cant_det_solRep { set; get; }
        [Required]
        public int cod_uniMed { set; get; }

    }
}
