using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IStatusBusiness
    {
        List<StatusDomainModel> GetStatus();


        /// <summary>
        /// Este metodo se encarga de agregar  actualziar un rol
        /// </summary>
        /// <param name="statusDM">la entidad AspNetRoles</param>
        /// <returns>un valor boolean true/false</returns>
        bool AddUpdateStatus(StatusDomainModel statusDM);
        /// <summary>
        /// Este metodo se encarga de validar que una entidad no exista 
        /// </summary>
        /// <param name="strValor">El parametro a buscar  </param>
        /// <returns>Valor boleano true o false</returns>
        bool ValidateStatusValue(string strValor);
    }
}
