using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Incubadora.Business
{
    public class ProyectoBusiness : IProyectoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProyectoRepository repository;
        public ProyectoBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new ProyectoRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de insertar en cascade un Proyecto en base de datos
        /// Las entidades (tablas) que inserta en cascada son:
        /// ServiciosUniversitarios y RecursosProyectos
        /// </summary>
        /// <param name="proyectoDomainModel">Un objeto de tipo ProyectoDomainModel que contiene todos los datos</param>
        /// <returns>True si fue registrado, false si no</returns>
        public bool Add(ProyectoDomainModel proyectoDomainModel)
        {
            var serviciosUniversitarios = new List<ServiciosUniversitarios>();
            foreach (var servicioUniversitario in proyectoDomainModel.ServiciosUniversitariosDomainModel)
            {
                serviciosUniversitarios.Add(new ServiciosUniversitarios {
                    Id = Guid.NewGuid().ToString(),
                    IdServicio = servicioUniversitario.IdServicio
                });
            }
            var recursosProyectos = new List<RecursosProyectos>();
            foreach (var recursoProyecto in proyectoDomainModel.RecursosProyectosDomainModel)
            {
                recursosProyectos.Add(new RecursosProyectos {
                    Id = Guid.NewGuid().ToString(),
                    StrDescripcion = recursoProyecto.StrDescripcion,
                    StrValor = recursoProyecto.StrValor,
                    StrNombrePersona = recursoProyecto.StrNombrePersona
                });
            }
            var proyecto = new Proyectos
            {
                Id = Guid.NewGuid().ToString(),
                IdEmprendedor = proyectoDomainModel.IdEmprendedor,
                IdFase = proyectoDomainModel.IdFase,
                IdGiro = proyectoDomainModel.IdGiro,
                IntConstituidaLegal = proyectoDomainModel.IntConstituidaLegal,
                DtFechaRegistro = proyectoDomainModel.DtFechaRegistro,
                StrDescripcion = proyectoDomainModel.StrDescripcion,
                StrNombre = proyectoDomainModel.StrNombre,
                StrNombreEmpresa = proyectoDomainModel.StrNombreEmpresa,
                StrObservaciones = proyectoDomainModel.StrObservaciones,
                StrRFC = proyectoDomainModel.StrRFC,
                RecursosProyectos = recursosProyectos,
                ServiciosUniversitarios = serviciosUniversitarios,
                IdStatus = (int)Enum.StatusEnum.Activo
            };
            var proyectodb = repository.Insert(proyecto);
            return proyectodb != null;
        }

        /// <summary>
        /// Este metodo se encarga de consultar un proyecto en especifico por Id y su emprendedor
        /// </summary>
        /// <param name="Id">el identificador del emprendedor</param>
        /// <returns>la entidad del tipo ProyectoDomainModel</returns>
        public ProyectoDomainModel GetProyectoEmprendedorById(string Id)
        {
            ProyectoDomainModel proyectoDM = null;
            var proyecto = repository.SingleOrDefaultInclude(p => p.Id == Id, Recursos.CatalogosEntidades.Emprendedores);
            if (proyecto != null)
            {
                proyectoDM = new ProyectoDomainModel
                {
                    Id = proyecto.Id,
                    StrNombre = proyecto.StrNombre,
                    DtFechaRegistro = proyecto.DtFechaRegistro,
                    IdEmprendedor = proyecto.IdEmprendedor,
                    StrDescripcion = proyecto.StrDescripcion,
                    StrNombreEmpresa = proyecto.StrNombreEmpresa,
                    StrObservaciones = proyecto.StrObservaciones,
                    StrRFC = proyecto.StrRFC,
                    EmprendedorDomainModel = new EmprendedorDomainModel
                    {
                        StrNombre = proyecto.Emprendedores.StrNombre,
                        Id = proyecto.Emprendedores.Id,
                        IdStatus = proyecto.Emprendedores.IdStatus,
                        StrApellidoPaterno = proyecto.Emprendedores.StrApellidoPaterno,
                        StrApellidoMaterno = proyecto.Emprendedores.StrApellidoMaterno,
                        StrCurp = proyecto.Emprendedores.StrCurp,
                        StrEmail = proyecto.Emprendedores.StrEmail,
                        StrFechaNacimiento = proyecto.Emprendedores.StrFechaNacimiento
                    }
                };
                return proyectoDM;
            }
            else {
                return proyectoDM;
            }
        }

        /// <summary>
        /// Este metodo se encarga de eliminar logicamente de la base de datos un proyecto especifico
        /// </summary>
        /// <param name="Id">el identificador del proyecto</param>
        /// <returns>regresa true o false dependiendo de la acción</returns>
        public bool DeleteProyecto(string Id)
        {
            var proyecto = repository.SingleOrDefault(p => p.Id == Id);
            if (proyecto != null)
            {
                proyecto.IdStatus = (int)Enum.StatusEnum.Eliminar;
                repository.Update(proyecto);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Este metodo se encarga de actualizar los datos basicos del proyecto
        /// </summary>
        /// <param name="proyectoDM">la entidad proyecto</param>
        /// <returns>un valor boolean true/false</returns>
        public bool UpdateProyecto(ProyectoDomainModel proyectoDM)
        {
            bool resultado = false;
            if (proyectoDM != null)
            {
                Proyectos proyectos = repository.SingleOrDefault(p => p.Id == proyectoDM.Id);
                if (!string.IsNullOrEmpty(proyectoDM.Id))
                {
                    proyectos.StrNombre = proyectoDM.StrNombre;
                    proyectos.StrNombreEmpresa = proyectoDM.StrNombreEmpresa;
                    proyectos.StrRFC = proyectoDM.StrRFC;
                    proyectos.StrObservaciones = proyectoDM.StrObservaciones;
                    proyectos.Emprendedores.StrNombre = proyectoDM.EmprendedorDomainModel.StrNombre;
                    proyectos.Emprendedores.StrApellidoPaterno = proyectoDM.EmprendedorDomainModel.StrApellidoPaterno;
                    proyectos.Emprendedores.StrApellidoMaterno = proyectoDM.EmprendedorDomainModel.StrApellidoMaterno;
                    repository.Update(proyectos);
                    resultado = true;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Este metodo se encarga de consultar un proyecto por Id
        /// </summary>
        /// <param name="Id">el identificador del proyecto</param>
        /// <returns>regresa la entidad del proyecto</returns>
        public ProyectoDomainModel GetProyectoById(string Id)
        {
            ProyectoDomainModel proyectoDM = new ProyectoDomainModel();
            var proyecto= repository.SingleOrDefault(p => p.Id == Id);
            proyectoDM.StrNombre = proyecto.StrNombre;
            proyectoDM.StrNombreEmpresa = proyecto.StrNombreEmpresa;
            proyectoDM.StrRFC = proyecto.StrRFC;
            proyectoDM.StrObservaciones = proyecto.StrObservaciones;
            return proyectoDM;

        }
    }
}
