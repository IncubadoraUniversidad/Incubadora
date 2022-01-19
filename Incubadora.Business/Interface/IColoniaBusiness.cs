using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IColoniaBusiness
    {
        /// <summary>
        /// Este método se encarga de retornar todas las colonias que pertenezcan a un municipio
        /// </summary>
        /// <param name="idMunicipio">El id del municipio</param>
        /// <returns>Una lista de colonias filtradas por el municipio al que pertenecen</returns>
        List<ColoniaDomainModel> GetColoniasByMunicipioId(int idMunicipio);
    }
}
