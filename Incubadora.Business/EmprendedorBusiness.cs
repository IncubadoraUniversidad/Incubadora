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
    public class EmprendedorBusiness : IEmprendedorBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmprendedorRepository repository;
        private readonly ProyectoRepository repositoryProyecto;
        public EmprendedorBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new EmprendedorRepository(this.unitOfWork);
            repositoryProyecto = new ProyectoRepository(this.unitOfWork);
        }


        /// <summary>
        /// Este método se encarga de crear un emprendedor en base de datos y hace la inserción en cascada
        /// de sus tablas relacionadas, las cuales son: Telefonos, Direcciones y DatosLaborales
        /// </summary>
        /// <param name="emprendedorDomainModel">Un objeto de tipo emprendedor</param>
        /// <returns>True si fue registrado, false si no</returns>
        public bool Add(EmprendedorDomainModel emprendedorDomainModel)
        {
            emprendedorDomainModel.IdStatus = 1;
            //emprendedorDomainModel.StrFotoUrl = "";
            emprendedorDomainModel.DatoLaboralDomainModel.IdStatus = 1;
            var telefonos = new Telefonos
            {
                Id = Guid.NewGuid().ToString(),
                StrTelefonoCelular = emprendedorDomainModel.TelefonoDomainModel.StrTelefonoCelular,
                StrTelefonoFijo = emprendedorDomainModel.TelefonoDomainModel.StrTelefonoFijo
            };
            var direcciones = new Direcciones
            {
                Id = Guid.NewGuid().ToString(),
                IdColonia = emprendedorDomainModel.DireccionDomainModel.IdColonia,
                IdEstado = emprendedorDomainModel.DireccionDomainModel.IdEstado,
                IdMunicipio = emprendedorDomainModel.DireccionDomainModel.IdMunicipio,
                StrCalle = emprendedorDomainModel.DireccionDomainModel.StrCalle
            };
            var datosLaborales = new DatosLaborales
            {
                Id = Guid.NewGuid().ToString(),
                IdCarrera = emprendedorDomainModel.DatoLaboralDomainModel.IdCarrera,
                IdCuatrimestre = emprendedorDomainModel.DatoLaboralDomainModel.IdCuatrimestre,
                IdStatus = emprendedorDomainModel.DatoLaboralDomainModel.IdStatus,
                IdUnidadAcademica = emprendedorDomainModel.DatoLaboralDomainModel.IdUnidadAcademica,
                StrObservaciones = emprendedorDomainModel.DatoLaboralDomainModel.StrObservaciones,
                IntOcupacion = emprendedorDomainModel.DatoLaboralDomainModel.IntOcupacion
            };
            var emprendedorEntity = new Emprendedores
            {
                Id = Guid.NewGuid().ToString(),
                StrNombre = emprendedorDomainModel.StrNombre,
                StrApellidoPaterno = emprendedorDomainModel.StrApellidoPaterno,
                StrApellidoMaterno = emprendedorDomainModel.StrApellidoMaterno,
                StrCurp = emprendedorDomainModel.StrCurp,
                StrFechaNacimiento = emprendedorDomainModel.StrFechaNacimiento,
                Telefonos = telefonos,
                Direcciones = direcciones,
                StrEmail = emprendedorDomainModel.StrEmail,
                StrFotoUrl = emprendedorDomainModel.StrFotoUrl,
                IdStatus = emprendedorDomainModel.IdStatus,
                DatosLaborales = datosLaborales,
                IdUsuario = emprendedorDomainModel.IdUsuario
            };
            repository.Insert(emprendedorEntity);
            return true;
        }
        /// <summary>
        /// Este método se encarga de consultar y retornar todos los emprendedores de la base de datos
        /// </summary>
        /// <returns>Una lista de emprendedores</returns>
        public List<EmprendedorDomainModel> GetEmprendedores()
        {
            var emprendedores = repository.GetAll().Select(e => new EmprendedorDomainModel
            {
                Id = e.Id,
                StrNombre = e.StrNombre,
                StrApellidoPaterno = e.StrApellidoPaterno,
                StrApellidoMaterno = e.StrApellidoMaterno,
                StrCurp = e.StrCurp,
                StrFechaNacimiento = e.StrFechaNacimiento,
                StrEmail = e.StrEmail,
                StrFotoUrl= e.StrFotoUrl,
                IdDatoLaboral = e.IdDatoLaboral,
                IdStatus = e.IdStatus

            }).ToList();
            return emprendedores;
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los emprendedores y sus proyectos realcionados tomando como base la lista de proyectos
        /// </summary>
        /// <param name="catalogo">el catalogo relacionado con la tabla a consultar</param>
        /// <returns>la lista de proyectos</returns>
        public List<ProyectoDomainModel> GetProyectoEmprendedores()
        {
            var proyectos = repositoryProyecto
                .GetIncludeAll(p=> p.IdStatus == (int)Enum.StatusEnum.Activo,
                Recursos.CatalogosEntidades.Emprendedores)                
                .Select(p => new ProyectoDomainModel {
                    Id = p.Id,
                    StrNombre = p.StrNombre,
                    StrNombreEmpresa = p.StrNombreEmpresa,
                    StrDescripcion = p.StrDescripcion,
                    EmprendedorDomainModel = new EmprendedorDomainModel { 
                        Id=p.IdEmprendedor,
                        StrNombre =p.Emprendedores.StrNombre,
                        StrApellidoPaterno = p.Emprendedores.StrApellidoPaterno,
                        StrApellidoMaterno = p.Emprendedores.StrApellidoMaterno,
                        StrCurp =p.Emprendedores.StrCurp,
                        StrFechaNacimiento = p.Emprendedores.StrFechaNacimiento,
                        StrEmail = p.Emprendedores.StrEmail,
                        StrFotoUrl = p.Emprendedores.StrFotoUrl
                    },
                }).ToList();
            return proyectos;
        }

        /// <summary>
        /// Este método se encarga de buscar y retornar un emprendedor en base de datos de acuerdo al Id asociado
        /// de la tabla AspNetUsers.
        /// </summary>
        /// <param name="aspNetUserId">Id de la tabla AspNetUsers asociado a un emprendedor</param>
        /// <returns>Un Objeto de tipo EmprendedorDomainModel</returns>
        public EmprendedorDomainModel GetEmprendedorByAspNetUserId(string aspNetUserId)
        {
            EmprendedorDomainModel emprendedorDM = null;
            var emprendedor = repository.SingleOrDefault(e => e.IdUsuario == aspNetUserId);
            if (emprendedor != null)
            {
                emprendedorDM = new EmprendedorDomainModel
                {
                    Id = emprendedor.Id,
                    IdDatoLaboral = emprendedor.IdDatoLaboral,
                    IdDireccion = emprendedor.IdDireccion,
                    IdStatus = emprendedor.IdStatus,
                    IdTelefono = emprendedor.IdTelefono,
                    IdUsuario = emprendedor.IdUsuario,
                    StrApellidoMaterno = emprendedor.StrApellidoMaterno,
                    StrApellidoPaterno = emprendedor.StrApellidoPaterno,
                    StrCurp = emprendedor.StrCurp,
                    StrEmail = emprendedor.StrEmail,
                    StrFechaNacimiento = emprendedor.StrFechaNacimiento,
                    StrFotoUrl = emprendedor.StrFotoUrl,
                    StrNombre = emprendedor.StrNombre
                };
            }
            return emprendedorDM;
        }

        /// <summary>
        /// Este método se encarga de consultar y retornar un emprendedor de la base de datos segun el id del proyecto
        /// </summary>
        /// <returns>Un emprendedor</returns>
        public EmprendedorDomainModel GetEmprendedorByIdProyecto(string IdEmprendedor)
        {
            EmprendedorDomainModel emprendedorDM = new EmprendedorDomainModel();
            var emprendedor = repository.SingleOrDefault(p => p.Id == IdEmprendedor);

            emprendedorDM.StrNombre = emprendedor.StrNombre;
            emprendedorDM.StrApellidoPaterno = emprendedor.StrApellidoPaterno;
            emprendedorDM.StrApellidoMaterno = emprendedor.StrApellidoMaterno;
            emprendedorDM.StrEmail = emprendedor.StrEmail;
            emprendedorDM.IdUsuario = emprendedor.IdUsuario;
            
            return emprendedorDM;
        }
    }
}
