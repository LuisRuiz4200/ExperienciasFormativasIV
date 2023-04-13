using Dominio.Entidad;
using Estructura.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class TecnicoBL
    {

        TecnicoDAO tecDao = new TecnicoDAO();

        public List<TecnicoModel> PA_LISTAR_TECNICO()
        { 
            var listado = tecDao.PA_LISTAR_TECNICO();

            return listado;
        
        }

        public List<TecnicoModel> PA_LISTAR_TECNICO_POR_ESTADO(string estado_tecnico)
        {
            var listado = tecDao.PA_LISTAR_TECNICO_POR_ESTADO(estado_tecnico);

            return listado;

        }

        public string PA_INSERTAR_TECNICO(TecnicoModel obj)
        {
            string mensaje = tecDao.PA_INSERTAR_TECNICO(obj);

            return mensaje;

        }

        public string PA_EDITAR_TECNICO(TecnicoModel obj)
        {
            string mensaje = tecDao.PA_EDITAR_TECNICO(obj);

            return mensaje;

        }

        public string PA_ELIMINAR_TECNICO(string cod_tecnico)
        {
            string mensaje = tecDao.PA_ELIMINAR_TECNICO(cod_tecnico);

            return mensaje;

        }

        public string PA_RESTAURAR_TECNICO(string cod_tecnico)
        {
            string mensaje = tecDao.PA_RESTAURAR_TECNICO(cod_tecnico);

            return mensaje;

        }




    }


}
