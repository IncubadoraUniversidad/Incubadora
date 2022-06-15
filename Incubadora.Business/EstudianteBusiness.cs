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
                EmprendimientoEstadia = emprendimiento
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
            var estudiantes = repository.GetAll().Select(e => new EstudianteDomainModel
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
                IdEmprendimientoEstadia = e.IdEmprendimientoEstadia
            }).ToList();
            return estudiantes;
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
    }
}
