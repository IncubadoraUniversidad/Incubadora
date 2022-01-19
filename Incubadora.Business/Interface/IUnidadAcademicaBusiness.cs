using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IUnidadAcademicaBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar todas las unidades académicas de la bd.
        /// </summary>
        /// <returns>Una lista de unidades académicas de la base de datos</returns>
        List<UnidadAcademicaDomainModel> GetAll();
    }
}
