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
    public class PeriodoEstadiaBusiness : IPeriodoEstadiaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PeriodoEstadiaRepository repository;

        public PeriodoEstadiaBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new PeriodoEstadiaRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar todos los periodos de estadia del catálogo de la bd
        /// </summary>
        /// <returns>Una lista de los periodos de estadia</returns>
        public List<PeriodoEstadiaDomainModel> GetPeriodos()
        {
            var periodos = repository.GetAll().Select(p => new PeriodoEstadiaDomainModel
            {
                Id = p.Id,
                StrValor = p.StrValor
            }).ToList();
            return periodos;
        }

        /// <summary>
        /// Este método se encarga de consultar el periodo de estadia por Id del catálogo de la bd
        /// </summary>
        /// <param name="IdPeriodo"></param>
        /// <returns>Un periodo de estadia</returns>
        public PeriodoEstadiaDomainModel GetPeriodoById(string IdPeriodo)
        {
            PeriodoEstadiaDomainModel periodoEstadiaDM = new PeriodoEstadiaDomainModel();
            var grupo = repository.SingleOrDefault(p => p.Id == IdPeriodo);
            periodoEstadiaDM.StrValor = grupo.StrValor;
            return periodoEstadiaDM;
        }
    }
}
