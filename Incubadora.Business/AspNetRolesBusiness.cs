using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Incubadora.Business
{
    public class AspNetRolesBusiness : IAspNetRolesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AspNetRolesRepository repository;
        public AspNetRolesBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new AspNetRolesRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de obtener una lista de roles
        /// </summary>
        /// <returns>lista de roles</returns>
        public List<AspNetRolesDomainModel> GetRoles()
        {
            List<AspNetRolesDomainModel> roles = null;
            roles = repository.GetAll().Select(p => new AspNetRolesDomainModel
            {
                Id = p.Id,
                Name = p.Name,
                NormalizedName = p.NormalizedName,
                ConcurrencyStamp = p.ConcurrencyStamp
            }).ToList();
            return roles;
        }

        /// <summary>
        /// Este metodo se encarga de agregar  actualziar un rol
        /// </summary>
        /// <param name="aspNetRoles">la entidad AspNetRoles</param>
        /// <returns>un valor boolean true/false</returns>
        public bool AddUpdateRol(AspNetRolesDomainModel aspNetRolesDM)
        {
            bool respuesta = false;
            if (aspNetRolesDM != null)
            {
                
                AspNetRoles roles = repository.SingleOrDefault(p => p.Id == aspNetRolesDM.Id);
                if (roles != null )
                {
                    roles.Name = aspNetRolesDM.Name;
                    roles.NormalizedName = aspNetRolesDM.Name.ToUpper();
                    roles.ConcurrencyStamp = DateTime.Now.Date.ToString();
                    repository.Update(roles);
                    respuesta = true;
                }
                else {
                    var Identificador = Guid.NewGuid();
                    AspNetRoles aspNet = new AspNetRoles
                    {
                        Id = Identificador.ToString(),
                        Name = aspNetRolesDM.Name,
                        NormalizedName = aspNetRolesDM.Name.ToUpper(),
                        ConcurrencyStamp = DateTime.Now.Date.ToString()
                    };
                    repository.Insert(aspNet);
                    respuesta = true;
                }
               
            }
            return respuesta;
        }
    }
}
