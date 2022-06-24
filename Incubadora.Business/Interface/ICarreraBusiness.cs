using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface ICarreraBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar las carreras que le pertenecen a una unidad académica
        /// </summary>
        /// <param name="unidadAcademicaId">El Id de la unidad académica</param>
        /// <returns>Una lista de carreras filtrada por Id de unidad académica</returns>
        List<CarreraDomainModel> GetCarrerasByUnidadAcademicaId(string unidadAcademicaId);

        /// <summary>
        /// Este método se encarga de consultar una carrera, por medio de su ID
        /// </summary>
        /// <param name="idCarrera"></param>
        /// <returns>Una carrera</returns>
        CarreraDomainModel GetCarrera(string idCarrera);
    }
}
