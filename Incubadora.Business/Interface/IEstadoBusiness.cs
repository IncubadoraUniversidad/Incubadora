using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IEstadoBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar y retornar todos los estados de la base de datos
        /// </summary>
        /// <returns>Una lista de estados</returns>
        List<EstadoDomainModel> GetEstados();
    }
}
