using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio.Entidad
{
    public class MantenimientoModel
    {
        public string id_mante { set; get; }
        public string cod_patrimonial { set; get; } 
        public string cod_tecnico { set; get; }
        public int cod_tipoMante { set; get; }
        public string obs_tipoMante { set; get; }
        public string estado_equipo { set; get; }
        public DateTime fecha_mante { set; get; }   
        public string estado_mante { set; get; }
    }
}