using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class SolicitudRepuestoModel
    {
        public String id_solRep { get; set; }
        public String cod_patrimonial { get; set; }
        public String motivo_solRep { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}" )]
        public DateTime fecha_solRep { get; set; }
        public String estado_solRep { get; set; }
    }
}
