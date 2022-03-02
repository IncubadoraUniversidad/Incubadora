using Incubadora.Business.Enum;
using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business
{
    public class DocenteBusiness : IDocenteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DocenteRepository repository;
        public DocenteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new DocenteRepository(unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de registrar un docente y enlazarlo con las tabla de
        /// AspNetUsers que maneja la seguridad en el sistema, además de registrar su rol
        /// correspondiente (Docente)
        /// </summary>
        /// <param name="docenteDM">Un objeto de tipo docente</param>
        /// <param name="rolId">El id del rol docente</param>
        /// <returns>True si se regsistró</returns>
        public bool Add(DocenteDomainModel docenteDM, string rolId)
        {
            var aspNetUserId = Guid.NewGuid().ToString();
            var avatarId = (docenteDM.IdSexo == (int)SexoEnum.Masculino) ? (int)AvatarEnum.Men : (int)AvatarEnum.Women;
            List<AspNetUserRoles> aspNetUserRoles = new List<AspNetUserRoles>
            {
                new AspNetUserRoles
                {
                    RoleId = rolId,
                    UserId = aspNetUserId
                }
            };
            var docente = new Docentes
            {
                Id = Guid.NewGuid().ToString(),
                IdSexo = docenteDM.IdSexo,
                StrNombre = docenteDM.StrNombre,
                StrApellidoPaterno = docenteDM.StrApellidoPaterno,
                StrApellidoMaterno = docenteDM.StrApellidoMaterno,
                IdUsuario = aspNetUserId,
                AspNetUsers = new AspNetUsers
                {
                    UserName = docenteDM.AspNetUserDomainModel.UserName,
                    Email = docenteDM.AspNetUserDomainModel.Email,
                    Id = aspNetUserId,
                    PasswordHash = docenteDM.AspNetUserDomainModel.PasswordHash,
                    IdAvatar = avatarId,
                    AspNetUserRoles = aspNetUserRoles
                }
            };
            repository.Insert(docente);
            return true;
        }
    }
}
