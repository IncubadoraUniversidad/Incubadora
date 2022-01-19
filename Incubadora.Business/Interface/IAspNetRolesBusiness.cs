using Incubadora.Domain;
using System.Collections.Generic;

namespace Incubadora.Business.Interface
{
    public interface IAspNetRolesBusiness
    {
        /// <summary>
        /// Este metodo se encarga de obtener una lista de roles
        /// </summary>
        /// <returns>lista de roles</returns>
        List<AspNetRolesDomainModel> GetRoles();


        /// <summary>
        /// Este metodo se encarga de agregar  actualziar un rol
        /// </summary>
        /// <param name="aspNetRoles">la entidad AspNetRoles</param>
        /// <returns>un valor boolean true/false</returns>
        bool AddUpdateRol(AspNetRolesDomainModel aspNetRolesDM);
    }
}
