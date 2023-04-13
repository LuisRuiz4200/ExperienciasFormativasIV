using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class FichaReposicionModel
    {
        public string id_fichaRepo { set; get; }
        public string cod_patrimonial { set; get; }
        public string motivo_fichaRepo { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mmmm/yyyy}")]
        public DateTime fecha_fichaRepo { set; get; }
        public string estado_fichaRepo { set; get; }
    }
}
