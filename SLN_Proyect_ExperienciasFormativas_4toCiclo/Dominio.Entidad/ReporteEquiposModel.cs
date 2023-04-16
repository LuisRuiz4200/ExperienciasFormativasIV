using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class ReporteEquiposModel
    {
        public string cod_patrimonial { get; set; }
        public string nom_equipo { get; set; }
        public string des_proveedor { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/yyyy}")]
        public DateTime fecha_ingreso { get; set; }
        public string estado_equipo { get; set; }
    }
}
