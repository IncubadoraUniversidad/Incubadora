using Incubadora.Domain;
using System.Collections.Generic;

namespace Incubadora.Business.Interface
{
    public interface IAspNetUsersBusiness
    {
        List<AspNetUsersDomainModel> GetUsers();
        /// <summary>
        /// Este metodo se encarga de realizar la insercion o actualizacion de una entidad AspNetUsersDM
        /// </summary>
        /// <param name="aspNetUsersDM">la entidad aspnetuserdm</param>
        /// <returns>un valor true/false</returns>
        bool AddUpdateUser(AspNetUsersDomainModel aspNetUsersDM);
        
        /// <summary>
        /// Este metodo se encarga de consultar a los usuarios  con sus respectivos roles
        /// </summary>
        /// <returns>una lista de usuariosDomainModel</returns>
        List<AspNetUsersDomainModel> GetUserRoles();

        /// <summary>
        /// Este método se encarga de verificar si un usuario existe en el sistema y sus credenciales son las correctas
        /// </summary>
        /// <param name="loginDM">Un objeto de tipo LoginDomainModel</param>
        /// <returns>True si existe el nombre de usuario y su contraseña es correcta, false si no lo es.</returns>
        bool Login(LoginDomainModel loginDM);
    }
}
