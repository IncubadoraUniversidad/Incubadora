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
                ServiciosUniversitarios = serviciosUniversitarios
            };
            var proyectodb = repository.Insert(proyecto);
            return proyectodb != null;
        }
    }
}
