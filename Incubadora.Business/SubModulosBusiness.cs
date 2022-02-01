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
    public class SubModulosBusiness: ISubModuloBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SubModulosRepository repository;
        public SubModulosBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.repository = new SubModulosRepository(this.unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar todos los submodulos del sistema
        /// </summary>
        /// <returns>regresa una lista de submodulos</returns>
        public List<SubModulosDomainModel> GetSubModulosAll()
        {
            var modulos = repository.GetAll().Select(m => new SubModulosDomainModel
            {

                Id = m.Id,
                StrValor = m.StrValor
            }).ToList();
            return modulos;

        }
    }
}
