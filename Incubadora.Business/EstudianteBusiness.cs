using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubadora.Business.Enum;

namespace Incubadora.Business
{
    public class EstudianteBusiness : IEstudianteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EstudianteRepository repository;
        private readonly EmprendimientoEstadiaRepository emprendimientoEstadiaRepository;

        public EstudianteBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new EstudianteRepository(this.unitOfWork);
            emprendimientoEstadiaRepository = new EmprendimientoEstadiaRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de insertar un estudiante en base de datos y hace la inserción en cascada 
        /// de sus tablas relacionadas, las cuales son: Telefonos y EmprendimientoEstadia
        /// </summary>
        /// <param name="estudianteDM"></param>
        /// <returns>True si fue registrado, false si no</returns>
        public bool Add(EstudianteDomainModel estudianteDM)
        {
            var emprendimiento = new EmprendimientoEstadia
            {
                Id = Guid.NewGuid().ToString(),
                StrValor = estudianteDM.EmprendimientoEstadiaDomainModel.StrValor,
                StrDescripcion = estudianteDM.EmprendimientoEstadiaDomainModel.StrDescripcion,
                IdStatus = estudianteDM.EmprendimientoEstadiaDomainModel.IdStatus
            };

            var telefonos = new Telefonos
            {
                Id = Guid.NewGuid().ToString(),
                StrTelefonoCelular = estudianteDM.TelefonoDomainModel.StrTelefonoCelular,
                StrTelefonoFijo = estudianteDM.TelefonoDomainModel.StrTelefonoFijo
            };

            var estudianteEntity = new Estudiantes
            {
                Id = Guid.NewGuid().ToString(),
                StrNombre = estudianteDM.StrNombre,
                StrApellidoPaterno = estudianteDM.StrApellidoPaterno,
                StrApellidoMaterno = estudianteDM.StrApellidoMaterno,
                FechaNacimiento = estudianteDM.FechaNacimiento,
                Telefonos = telefonos,
                IdCarrera = estudianteDM.IdCarrera,
                IdCatGrupo = estudianteDM.IdCatGrupo,
                StrGrupoDescripcion = estudianteDM.StrGrupoDescripcion,
                IdCatPeriodoEstadia = estudianteDM.IdCatPeriodoEstadia,
                EmprendimientoEstadia = emprendimiento,
                IdStatus = 1
            };

            repository.Insert(estudianteEntity);

            return true;
        }

        /// <summary>
        /// Este método se encarga de consultar todos los estudiantes del catálogo de la bd
        /// </summary>
        /// <returns>Una lista de estudiantes</returns>
        public List<EstudianteDomainModel> GetEstudiantes()
        {
            var estudiantes = repository.GetIncludeForAll(p => p.IdStatus == (int)Enum.StatusEnum.Activo, Recursos.CatalogosEntidades.CatCarreras, Recursos.CatalogosEntidades.CatPeriodoEstadia, Recursos.CatalogosEntidades.Telefonos ).Select(e => new EstudianteDomainModel
            {
                Id = e.Id,
                StrNombre = e.StrNombre,
                StrApellidoPaterno = e.StrApellidoPaterno,
                StrApellidoMaterno = e.StrApellidoMaterno,
                FechaNacimiento = e.FechaNacimiento,
                IdTelefono = e.IdTelefono,
                IdCarrera = e.IdCarrera,
                IdCatGrupo = e.IdCatGrupo,
                StrGrupoDescripcion = e.StrGrupoDescripcion,
                IdCatPeriodoEstadia = e.IdCatPeriodoEstadia,
                IdEmprendimientoEstadia = e.IdEmprendimientoEstadia,
                StrTelefonoCelular = e.Telefonos.StrTelefonoCelular,
                StrPeriodoEstadia = e.CatPeriodoEstadia.StrValor,

            }).ToList();
            return estudiantes;
        }

        /// <summary>
        /// Este método se encarga de consultar un emprendimiento por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>un emprendimiento</returns>
        public EmprendimientoEstadiaDomainModel GetEmprendimientoById(string Id)
        {
            EmprendimientoEstadiaDomainModel emprendimientoEstadiaDM = new EmprendimientoEstadiaDomainModel();
            var emprendimiento = emprendimientoEstadiaRepository.SingleOrDefault(p => p.Id == Id);
            emprendimientoEstadiaDM.StrValor = emprendimiento.StrValor;
            emprendimientoEstadiaDM.StrDescripcion = emprendimiento.StrDescripcion;
            emprendimientoEstadiaDM.IdStatus = (int)emprendimiento.IdStatus;
            return emprendimientoEstadiaDM;
        }

        /// <summary>
        /// Este método se encarga de consultar un estudiante mediante su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Un estudiante</returns>
        public EstudianteDomainModel GetEstudianteById(string Id)
        {
            EstudianteDomainModel estudianteDM = new EstudianteDomainModel();
            var estudiante = repository.SingleOrDefault(e => e.Id == Id);

            estudianteDM.StrNombre = estudiante.StrNombre;
            estudianteDM.StrApellidoPaterno = estudiante.StrApellidoPaterno;
            estudianteDM.StrApellidoMaterno = estudiante.StrApellidoMaterno;
            estudianteDM.FechaNacimiento = estudiante.FechaNacimiento;
            estudianteDM.IdTelefono = estudiante.IdTelefono;
            estudianteDM.IdCarrera = estudiante.IdCarrera;
            estudianteDM.IdCatGrupo = estudiante.IdCatGrupo;
            estudianteDM.StrGrupoDescripcion = estudiante.StrGrupoDescripcion;
            estudianteDM.IdCatPeriodoEstadia = estudiante.IdCatPeriodoEstadia;

            return estudianteDM;
        }

        /// <summary>
        /// Este método se encarga de consultar un estudiante mediante el id del emprendimientoEstadia
        /// </summary>
        /// <param name="IdEmprendimientoEstadia"></param>
        /// <returns>Un estudiante</returns>
        public EstudianteDomainModel GetEstudianteByIdEmprendimiento(string IdEmprendimientoEstadia)
        {
            EstudianteDomainModel estudianteDM = new EstudianteDomainModel();
            var estudiante = repository.SingleOrDefault(e => e.IdEmprendimientoEstadia == IdEmprendimientoEstadia);

            estudianteDM.StrNombre = estudiante.StrNombre;
            estudianteDM.StrApellidoPaterno = estudiante.StrApellidoPaterno;
            estudianteDM.StrApellidoMaterno = estudiante.StrApellidoMaterno;
            estudianteDM.FechaNacimiento = estudiante.FechaNacimiento;
            estudianteDM.IdTelefono = estudiante.IdTelefono;
            estudianteDM.IdCarrera = estudiante.IdCarrera;
            estudianteDM.IdCatGrupo = estudiante.IdCatGrupo;
            estudianteDM.StrGrupoDescripcion = estudiante.StrGrupoDescripcion;
            estudianteDM.IdCatPeriodoEstadia = estudiante.IdCatPeriodoEstadia;

            return estudianteDM;
        }

        /// <summary>
        /// Este metodo se encarga de actualizar los datos del estudiante
        /// </summary>
        /// <param name="estudianteDM">la entidad Estudiante</param>    
        /// <returns>Un valor boolean true/false</returns>
        public bool UpdateEstudiante(EstudianteDomainModel estudianteDM)
        {
            bool resultado = false;
            if (estudianteDM != null)
            {
                Estudiantes estudiantes = repository.SingleOrDefault(p => p.Id == estudianteDM.Id);
                if (!string.IsNullOrEmpty(estudianteDM.Id))
                {
                    estudiantes.StrNombre = estudianteDM.StrNombre;
                    estudiantes.StrApellidoPaterno = estudianteDM.StrApellidoPaterno;
                    estudiantes.StrApellidoMaterno = estudianteDM.StrApellidoMaterno;
                    estudiantes.StrGrupoDescripcion = estudianteDM.StrGrupoDescripcion;
                    repository.Update(estudiantes);
                    resultado = true;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar logicamente de la base de datos un estudiante especifico
        /// </summary>
        /// <param name="Id">el identificador del estudiante</param>
        /// <returns>regresa true o false dependiendo de la acción</returns>
        public bool DeleteEstudiante(string Id)
        {
            var estudiante = repository.SingleOrDefault(p => p.Id == Id);
            if (estudiante != null)
            {
                estudiante.IdStatus = (int)Enum.StatusEnum.Eliminar;
                repository.Update(estudiante);
                return true;
            }
            return false;
        }
    }
}
