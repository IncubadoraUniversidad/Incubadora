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

        /// <summary>
        /// Este metodo se encarga de consultar un usuario dentro del sistema
        /// </summary>
        /// <param name="loginDM">la entidad del tipo loginDM</param>
        /// <returns>regresa una entidad del tipo LoginDomainModel</returns>
        LoginDomainModel ValidateLogin(LoginDomainModel loginDM);

        /// <summary>
        /// Este método se encarga de consultar si ya existe un usuario que ocupe el nombre de usuario dado
        /// Es decir, lo ocupamos para validar que el campo UserName de un AspNetUser sea único.
        /// </summary>
        /// <param name="username">Un nombre de usuario</param>
        /// <returns>True si el UserName ya está ocupado(registrado en db) false si no es así</returns>
        bool IsUsernameTaken(string username);

        /// <summary>
        /// Este método se encarga de consultar si ya existe un usuario que ocupe el email de usuario dado
        /// Es decir, lo ocupamos para validar que el campo Email de un AspNetUser sea único.
        /// </summary>
        /// <param name="email">Un email</param>
        /// <returns>True si el Email ya está ocupado(registrado en db) false si no es así</returns>
        bool IsEmailTaken(string email);
    }
}
