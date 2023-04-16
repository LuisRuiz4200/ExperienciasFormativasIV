using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class ReporteMantenimientoModel
    {
        public string id_mante { get; set; }
        public string nom_equipo { get; set; }
        public string tecnico { get; set; }
        public string des_tipoMante { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/yyyy}")]
        public DateTime fecha_mante { get; set; }
    }
}
