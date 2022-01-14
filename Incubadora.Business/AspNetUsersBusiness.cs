using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Incubadora.Business
{
    public class AspNetUsersBusiness : IAspNetUsersBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AspNetUsersRepository repository;
        private readonly AspNetUsersRolesRepository usersRolesRepository;
        public AspNetUsersBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = new AspNetUsersRepository(this.unitOfWork);
            usersRolesRepository = new AspNetUsersRolesRepository(this.unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar a todos los usuarios del sistema
        /// </summary>
        /// <returns>la lista de usuarios del sistema</returns>
        public List<AspNetUsersDomainModel> GetUsers()
        {
            List<AspNetUsersDomainModel> usuarios = null;
            usuarios = repository.GetAll().Select(p => new AspNetUsersDomainModel
            {
                Id = p.Id,
                UserName = p.UserName,
                NormalizedUserName = p.NormalizedUserName,
                Email = p.Email,
                NormalizedEmail = p.NormalizedEmail,
                PasswordHash = p.PasswordHash,
                PhoneNumber = p.PhoneNumber
            }).ToList();
            return usuarios;
        }

        /// <summary>
        /// Este metodo se encarga de consultar a los usuarios  con sus respectivos roles
        /// </summary>
        /// <returns>una lista de usuariosDomainModel</returns>
        public List<AspNetUsersDomainModel> GetUserRoles()
        {
            List<AspNetUsersDomainModel> usuarios = new List<AspNetUsersDomainModel>();
            var users= repository.GetAll().ToList();
            foreach (var u in users)
            {
                AspNetUsersDomainModel aspNetUsers = new AspNetUsersDomainModel();
                aspNetUsers.UserName = u.UserName;
                aspNetUsers.Id = u.Id;
                AspNetRolesDomainModel aspNetRoles = new AspNetRolesDomainModel();
                foreach (var r in u.AspNetUserRoles)
                {
                    aspNetRoles.Name=r.AspNetRoles.Name;
                    aspNetRoles.Id = r.AspNetRoles.Id;
                }
                if(aspNetRoles !=null)
                {
                    aspNetUsers.AspNetRolesDomainModel = aspNetRoles;
                }
                usuarios.Add(aspNetUsers);
               
            }
            return usuarios;
        }


        /// <summary>
        /// Este metodo se encarga de realizar la insercion o actualizacion de una entidad AspNetUsersDM
        /// </summary>
        /// <param name="aspNetUsersDM">la entidad aspnetuserdm</param>
        /// <returns>un valor true/false</returns>
        public bool AddUpdateUser(AspNetUsersDomainModel aspNetUsersDM)
        {
            bool respuesta = false;
            if (aspNetUsersDM != null)
            {

                AspNetUsers usuario = repository.SingleOrDefault(p => p.Id == aspNetUsersDM.Id);
                if (usuario != null)
                {
                    usuario.UserName = aspNetUsersDM.UserName;
                    usuario.PasswordHash = aspNetUsersDM.PasswordHash;
                    usuario.PhoneNumber = aspNetUsersDM.PhoneNumber;
                    repository.Update(usuario);
                    respuesta = true;
                }
                else
                {
                    var Identificador = Guid.NewGuid();
                    AspNetUsers aspNetUsers = new AspNetUsers
                    {
                        Id = Identificador.ToString(),
                        UserName = aspNetUsersDM.UserName,
                        PasswordHash = aspNetUsersDM.PasswordHash,
                        
                    };
                    
                    AspNetRoles roles = new AspNetRoles { Id = aspNetUsersDM.AspNetRolesDomainModel.Id };

                    AspNetUserRoles userRoles = new AspNetUserRoles
                    {
                        
                        UserId = aspNetUsers.Id,
                        RoleId = roles.Id
                    };
                    aspNetUsers.AspNetUserRoles.Add(userRoles);
                    repository.Insert(aspNetUsers);
                    respuesta = true;
                }

            }
            return respuesta;
        }

        /// <summary>
        /// Este método se encarga de verificar si un usuario existe en el sistema y sus credenciales son las correctas
        /// </summary>
        /// <param name="loginDM">Un objeto de tipo LoginDomainModel</param>
        /// <returns>True si existe el nombre de usuario y su contraseña es correcta, false si no lo es.</returns>
        public bool Login(LoginDomainModel loginDM)
        {
            var user = repository.SingleOrDefault(u => u.UserName == loginDM.UserName);
            if (user != null)
            {
                // el usuario existe en la db, comrobando contraseña...
                return user.PasswordHash == loginDM.PasswordHash;
            }
            // el nombre de usuario no existe
            return false;
        }
    }
}
