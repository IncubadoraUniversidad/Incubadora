using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Incubadora.Business
{
    public class FaseBusiness : IFaseBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FaseRepository repository;

        public FaseBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new FaseRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método consulta todas las bases del catálogo de la bd.
        /// </summary>
        /// <returns>Una lista del catálogo fases </returns>
        public List<FaseDomainModel> GetFases()
        {
            var fases = repository.GetAll().Select(f => new FaseDomainModel
            {
                Id = f.Id,
                StrDescripcion = f.StrDescripcion,
                StrValor = f.StrValor
            }).ToList();
            return fases;
        }
    }
}
