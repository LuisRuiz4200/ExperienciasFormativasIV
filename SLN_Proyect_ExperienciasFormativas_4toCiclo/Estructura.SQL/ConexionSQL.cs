using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Estructura.SQL
{
    public class ConexionSQL
    {
        public static String CAD_CN = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
    }
}
