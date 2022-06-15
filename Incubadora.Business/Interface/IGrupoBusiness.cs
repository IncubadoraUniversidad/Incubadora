using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IGrupoBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar todos los grupos del catálogo de la bd
        /// </summary>
        /// <returns>Una lista de los grupos</returns>
        List<GrupoDomainModel> GetGrupos();
        /// <summary>
        /// Este método se encarga de consultar el grupo por Id del catálogo de la bd
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns>Un grupo</returns>
        GrupoDomainModel GetGrupoById(string IdGrupo);
    }
}
