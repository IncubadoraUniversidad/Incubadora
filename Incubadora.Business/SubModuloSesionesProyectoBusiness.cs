using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;

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
                    DteFechaInicio = submodulosDM.FechaInicio,
                    DteFechaTermino = submodulosDM.FechaTermino,
                    StrAsunto = submodulosDM.StrAsunto,
                    StrDescripcion = submodulosDM.StrDescripcion,
                    StrColorTema= submodulosDM.StrColorTema,
                    IdStatus = 10
                    // IdStatus = (int)Enum.StatusEnum.Activo
                };
                repository.Insert(submodulos);
                respuesta = true;
            }
            return respuesta;
        }
    }
}


