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
    public class UnidadAcademicaBusiness : IUnidadAcademicaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UnidadAcademicaRepository repository;

        public UnidadAcademicaBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new UnidadAcademicaRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar todas las unidades académicas de la bd.
        /// </summary>
        /// <returns>Una lista de unidades académicas de la base de datos</returns>
        public List<UnidadAcademicaDomainModel> GetAll()
        {
            var unidadesAcademicas = repository.GetAll().Select(ua => new UnidadAcademicaDomainModel
            {
                Id = ua.Id,
                StrValor = ua.StrValor,
                StrDescripcion = ua.StrDescripcion
            }).ToList();
            return unidadesAcademicas;
        }
    }
}
