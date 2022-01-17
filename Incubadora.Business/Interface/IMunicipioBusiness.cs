using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IMunicipioBusiness
    {
        /// <summary>
        /// Este método se encarga de retornar todos los municipios que pertenezcan a un estado
        /// </summary>
        /// <param name="idEstado">El Id del estado</param>
        /// <returns>Una lista de municipios filtrada por el estado al que pertenecen</returns>
        List<MunicipioDomainModel> GetMunicipiosByEstadoId(int idEstado);
    }
}
