using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface ICuatrimestreBusiness
    {
        /// <summary>
        /// Este método se encarga de consultar todos los cuatrimestres de la bd.
        /// </summary>
        /// <returns>Una lista de cuatrimestres</returns>
        List<CuatrimestreDomainModel> GetAll();
    }
}
