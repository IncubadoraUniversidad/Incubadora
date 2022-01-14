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
    public class EstadoBusiness : IEstadoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EstadoRepository repository;

        public EstadoBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = new EstadoRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar y retornar todos los estados de la base de datos
        /// </summary>
        /// <returns>Una lista de estados</returns>
        public List<EstadoDomainModel> GetEstados()
        {
            var estados = repository.GetAll().Select(estado => new EstadoDomainModel
            {
                Id = estado.Id,
                StrNombre = estado.StrNombre,
                StrDescripcion = estado.StrDescripcion
            }).ToList();
            return estados;
        }
    }
}
