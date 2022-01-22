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
    public class ServicioBusiness : IServicioBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ServicioRepository repository;

        public ServicioBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new ServicioRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar todos los servicos del catálogo de la bd.
        /// </summary>
        /// <returns>Una lista de Servicios</returns>
        public List<ServicioDomainModel> GetServicios()
        {
            var servicios = repository.GetAll().Select(s => new ServicioDomainModel
            {
                Id = s.Id,
                StrDescripcion = s.StrDescripcion,
                StrValor = s.StrValor
            }).ToList();
            return servicios;
        }
    }
}
