using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Incubadora.Business
{
    public class SubModuloSesionesProyectoBusiness : ISubModuloSesionesProyectoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SubModuloSesionesProyectoRepository repository;

        public SubModuloSesionesProyectoBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.repository = new SubModuloSesionesProyectoRepository(this.unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de agregar los submodulos
        /// </summary>
        /// <param name="submodulosDM">la entidad AspNetRoles</param>
        /// <returns>retorna un valor boolean true/false</returns>
        public bool AddSubModuloSesiones(SubModuloSesionesProyectoDomainModel submodulosDM)
        {
            bool respuesta = false;
            if (submodulosDM != null)
            {
                SubModuloSesionesProyecto submodulos = new SubModuloSesionesProyecto 
                {
                    IdProyecto = submodulosDM.IdProyecto,
                    IdSesion = submodulosDM.IdSesion,
                    DteFechaInicio = submodulosDM.DteFechaInicio,
                    DteFechaTermino = submodulosDM.DteFechaTermino,
                    StrAsunto = submodulosDM.StrAsunto,
                    StrDescripcion = submodulosDM.StrDescripcion,
                    StrColorTema= submodulosDM.StrColorTema,
                    IdStatus = (int)Enum.StatusEnum.Activo
                 
                   
                };
                repository.Insert(submodulos);
                respuesta = true;
            }
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de consultar en la tabla SubModuloSesionesProyecto
        /// </summary>
        /// <returns>regresa una lista de SubModuloSesionesProyecto</returns>
        public List<SubModuloSesionesProyectoDomainModel> GetEventos()
        {

            List<SubModuloSesionesProyectoDomainModel> evts = null;
            evts = repository.GetAll().Select(p => new SubModuloSesionesProyectoDomainModel

            {
                IdProyecto = p.IdProyecto,
                IdSesion = p.IdSesion,
                DteFechaInicio = p.DteFechaInicio.Value,
                DteFechaTermino = p.DteFechaTermino.Value,
                StrAsunto = p.StrAsunto,
                StrDescripcion = p.StrDescripcion,
                StrColorTema = p.StrColorTema,
                IdStatus = (int)Enum.StatusEnum.Activo

            }).ToList();
            return evts;
        }
    }
}


