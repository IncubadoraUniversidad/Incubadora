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
    public class CarreraBusiness : ICarreraBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CarreraRepository repository;

        public CarreraBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new CarreraRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar las carreras que le pertenecen a una unidad académica
        /// </summary>
        /// <param name="unidadAcademicaId">El Id de la unidad académica</param>
        /// <returns>Una lista de carreras filtrada por Id de unidad académica</returns>
        public List<CarreraDomainModel> GetCarrerasByUnidadAcademicaId(string unidadAcademicaId)
        {
            var carreras = repository.GetAll(carrera => carrera.IdUnidadAcademica == unidadAcademicaId).Select(c => new CarreraDomainModel
            {
                Id = c.Id,
                IdStatus = c.IdStatus,
                IdUnidadAcademica = c.IdUnidadAcademica,
                StrDescripcion = c.StrDescripcion,
                StrValor = c.StrValor
            }).ToList();
            return carreras;
        }
    }
}
