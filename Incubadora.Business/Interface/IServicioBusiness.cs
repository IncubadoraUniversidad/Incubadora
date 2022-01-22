using Incubadora.Domain;
using System.Collections.Generic;

namespace Incubadora.Business.Interface
{
    public interface IServicioBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar todos los servicos del catálogo de la bd.
        /// </summary>
        /// <returns>Una lista de Servicios</returns>
        List<ServicioDomainModel> GetServicios();
    }
}
