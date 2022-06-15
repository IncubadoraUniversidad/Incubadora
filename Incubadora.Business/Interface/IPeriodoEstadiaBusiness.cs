using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IPeriodoEstadiaBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar todos los periodos de estadia del catálogo de la bd
        /// </summary>
        /// <returns>Una lista de los periodos de estadia</returns>
        List<PeriodoEstadiaDomainModel> GetPeriodos();

        /// <summary>
        /// Este método se encarga de consultar el periodo de estadia por Id del catálogo de la bd
        /// </summary>
        /// <param name="IdPeriodo"></param>
        /// <returns>Un periodo de estadia</returns>
        PeriodoEstadiaDomainModel GetPeriodoById(string IdPeriodo);
    }
}
