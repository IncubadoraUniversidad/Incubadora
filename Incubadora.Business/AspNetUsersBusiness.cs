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
                aspNetUsers.Email = u.Email;

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
                        Email = aspNetUsersDM.Email,
                        IdAvatar = aspNetUsersDM.IdAvatar
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

        /// <summary>
        /// Este metodo se encarga de consultar un usuario dentro del sistema
        /// </summary>
        /// <param name="loginDM">la entidad del tipo loginDM</param>
        /// <returns>regresa una entidad del tipo LoginDomainModel</returns>
        public LoginDomainModel ValidateLogin(LoginDomainModel loginDM)
        {
            LoginDomainModel loginDomainModel = null;
            var user = repository
                .SingleOrDefaultInclude(u => (u.UserName == loginDM.UserName || u.Email == loginDM.UserName) && u.PasswordHash == loginDM.PasswordHash, "CatAvatars");
            if (user != null)
            {
                AspNetRolesDomainModel aspNetRoles = null;
                foreach (var rol in user.AspNetUserRoles)
                {
                    aspNetRoles = new AspNetRolesDomainModel { Id = rol.AspNetRoles.Id, Name = rol.AspNetRoles.Name };
                }
                loginDomainModel = new LoginDomainModel {
                    Id = user.Id,
                    UserName = user.UserName,
                    IdAvatar = user.IdAvatar,
                    StrFotoUrl = user.StrFotoUrl,
                    Email = user.Email,
                    aspNetRoles = aspNetRoles,
                    avatarDomainModel = new AvatarDomainModel {
                        Id = user.IdAvatar,
                        StrUrl = user.CatAvatars.StrUrl,
                        StrValor = user.CatAvatars.StrValor
                    } 
                };
            }
            return loginDomainModel;
        }

        /// <summary>
        /// Este método se encarga de consultar si ya existe un usuario que ocupe el nombre de usuario dado
        /// Es decir, lo ocupamos para validar que el campo UserName de un AspNetUser sea único.
        /// </summary>
        /// <param name="username">Un nombre de usuario</param>
        /// <returns>True si el UserName ya está ocupado(registrado en db) false si no es así</returns>
        public bool IsUsernameTaken(string username)
        {
            var user = repository.SingleOrDefault(u => u.UserName == username);
            return user != null;
        }

        /// <summary>
        /// Este método se encarga de consultar si ya existe un usuario que ocupe el email de usuario dado
        /// Es decir, lo ocupamos para validar que el campo Email de un AspNetUser sea único.
        /// </summary>
        /// <param name="email">Un email</param>
        /// <returns>True si el Email ya está ocupado(registrado en db) false si no es así</returns>
        public bool IsEmailTaken(string email)
        {
            var user = repository.SingleOrDefault(u => u.Email == email);
            return user != null;
        }

        /// <summary>
        /// Este método se encarga de verificar si un usuario de AspNetUsers ya ha pasado
        /// por el registro de emprendedores
        /// </summary>
        /// <param name="userId">El id del usuario de la tabla AspNetUsers</param>
        /// <returns>True si el usuario ya se registró como emprendedor</returns>
        public bool EmprendedorHasRegistered(string userId)
        {
            var user = repository.SingleOrDefaultInclude(u => u.Id == userId, "Emprendedores");
            return user.Emprendedores.Count == 0;
        }

        public AspNetUsersDomainModel GetUserByEmail(string email)
        {
            AspNetUsersDomainModel userDM = null;
            var user = repository.SingleOrDefault(u => u.Email == email);
            if (user != null)
            {
                userDM = new AspNetUsersDomainModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    PasswordHash = user.PasswordHash,
                    UserName = user.UserName
                };
            }
            return userDM;
        }
    }
}
