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
    public class RecursoBusiness : IRecursoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly RecursoRepository repository;

        public RecursoBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new RecursoRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de registrar un recurso de proyecto en base de datos
        /// </summary>
        /// <param name="recursoDM">Un obeto de tipo RecursoDomainModel</param>
        /// <returns>True si todo salió bien.</returns>
        public bool Add(RecursoDomainModel recursoDM)
        {
            bool respuesta = false;
            var recurso = new Repository.Recursos
            {
                Id = Guid.NewGuid().ToString(),
                StrNombreRecurso = recursoDM.StrNombreRecurso,
                StrNombrePersona = recursoDM.StrNombrePersona,
                StrApellidoPaterno = recursoDM.StrApellidoPaterno,
                StrApellidoMaterno = recursoDM.StrApellidoMaterno,
                StrDescripcion = recursoDM.StrDescripcion,
                IdUsuario = recursoDM.IdUsuario
            };
            repository.Insert(recurso);
            respuesta = true;
            return respuesta;
        }


        /// <summary>
        /// Este método se encarga de consultar todos los recursos de proyectos que le pertenecen a un
        /// emprendedor
        /// </summary>
        /// <param name="userId">El Id de la sesión del usuario (AspNetUsers)</param>
        /// <returns>Una lista de RecursosDomainModel</returns>
        public List<RecursoDomainModel> GetRecursosByUserId(string userId)
        {
            var recursos = repository.GetAll(r => r.IdUsuario == userId)
                .Select(rep => new RecursoDomainModel {
                    Id = rep.Id,
                    StrNombrePersona = rep.StrNombrePersona,
                    StrNombreRecurso = rep.StrNombreRecurso,
                    StrApellidoPaterno = rep.StrApellidoPaterno,
                    StrApellidoMaterno = rep.StrApellidoMaterno,
                    StrDescripcion = rep.StrDescripcion,
                    IdUsuario = rep.IdUsuario
                })
                .ToList();
            return recursos;
        }


        /// <summary>
        /// Este método se encarga de consultar un recurso en bd por Id
        /// </summary>
        /// <param name="id">El Id del recurso</param>
        /// <returns>Un objeto de tipo RecursoDomainModel o null</returns>
        public RecursoDomainModel GetRecursoById(string id)
        {
            RecursoDomainModel recursoDM = null;
            var recurso = repository.SingleOrDefault(r => r.Id == id);
            if (recurso != null)
            {
                recursoDM = new RecursoDomainModel
                {
                    Id = id,
                    IdUsuario = recurso.IdUsuario,
                    StrNombreRecurso = recurso.StrNombreRecurso,
                    StrNombrePersona = recurso.StrNombrePersona,
                    StrApellidoPaterno = recurso.StrApellidoPaterno,
                    StrApellidoMaterno = recurso.StrApellidoMaterno,
                    StrDescripcion = recurso.StrDescripcion
                };
                return recursoDM;
            }
            return recursoDM;
        }

        /// <summary>
        /// Este método se encarga de actualizar un recurso
        /// </summary>
        /// <param name="recursoDM">Un objeto de tipo RecursoDomainModel</param>
        /// <returns>True si se actualizó</returns>
        public bool Update(RecursoDomainModel recursoDM)
        {
            var respuesta = false;
            if (recursoDM != null)
            {
                var recurso = repository.SingleOrDefault(r => r.Id == recursoDM.Id);
                recurso.StrNombreRecurso = recursoDM.StrNombreRecurso;
                recurso.StrNombrePersona = recursoDM.StrNombrePersona;
                recurso.StrApellidoPaterno = recursoDM.StrApellidoPaterno;
                recurso.StrApellidoMaterno = recursoDM.StrApellidoMaterno;
                recurso.StrDescripcion = recursoDM.StrDescripcion;
                repository.Update(recurso);
                respuesta = true;
                return respuesta;
            }
            return respuesta;
        }

        /// <summary>
        /// Este método se encarga de eliminar un recurso de base de datos 
        /// </summary>
        /// <param name="id">El id del recurso a eliminar</param>
        public void Delete(string id)
        {
            repository.Delete(r => r.Id == id);
        }
    }
}
