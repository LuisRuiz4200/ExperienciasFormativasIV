using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Proyect_ExperienciasFormativas_4toCiclo;

namespace Estructura.SQL
{
    public class ConexionSQL
    {
        public String CAD_CN = ConfigurationManager.ConnectionStrings["CN1"].ConnectionString;
    }
}
