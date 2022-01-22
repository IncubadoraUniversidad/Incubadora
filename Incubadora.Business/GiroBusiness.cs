using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Incubadora.Business
{
    public class GiroBusiness : IGiroBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly GiroRepository repository;
        public GiroBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new GiroRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar todos los giros del catálogo de la bd.
        /// </summary>
        /// <returns>Una lista del catálogo de giros</returns>
        public List<GiroDomainModel> GetGiros()
        {
            var giros = repository.GetAll().Select(g => new GiroDomainModel
            {
                Id = g.Id,
                StrDescripcion = g.StrDescripcion,
                StrValor = g.StrValor
            }).ToList();
            return giros;
        }
    }
}
