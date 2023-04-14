using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class FichaReposicionBL
    {
        FichaReposicionDAO fichRepDao = new FichaReposicionDAO();
        
        public List<FichaReposicionModel> PA_LISTAR_FICHAREPOSICION()
        {
            return fichRepDao.PA_LISTAR_FICHAREPOSICION();
        }
        public string PA_INSERTAR_FICHAREPOSICION(FichaReposicionModel obj)
        {
            return fichRepDao.PA_INSERTAR_FICHAREPOSICION(obj);
        }
        public string PA_EDITAR_FICHAREPOSICION(FichaReposicionModel obj)
        {
            return  fichRepDao.PA_EDITAR_FICHAREPOSICION(obj) ;
        }
        public string PA_ELIMINAR_FICHAREPOSICION (string id_fichaRepo)
        {
            return fichRepDao.PA_ELIMINAR_FICHAREPOSICION(id_fichaRepo);
        }
        public FichaReposicionModel PA_BUSCAR_SOLICITUDREPOSICION_POR_IDFICHAREPO(string id_fichaRepo)
        {
            return fichRepDao.PA_BUSCAR_SOLICITUDREPOSICION_POR_IDFICHAREPO(id_fichaRepo);
        }
    }
}
