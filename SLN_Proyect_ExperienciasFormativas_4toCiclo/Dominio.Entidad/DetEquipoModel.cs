using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class DetEquipoModel
    {
        public string cod_patrimonial { set; get; }
        public int cod_equipo { set; get; }
        public int cod_proveedor { set; get; }
        public DateTime fecha_ingreso { set; get; }
        public string estado_equipo { set; get; }
    }
}
