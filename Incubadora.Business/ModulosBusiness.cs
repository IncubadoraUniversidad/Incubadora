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
    public class ModulosBusiness: IModuloBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ModulosRepository repository;
        public ModulosBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.repository = new ModulosRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los modulos del sistema
        /// </summary>
        /// <returns>regresa una lista de modulos</returns>
        public List<ModulosDomainModel> GetModulosAll()
        {
            var modulos = repository.GetAll().Select(m => new ModulosDomainModel
            {

                Id = m.Id,
                StrValor = m.StrValor
            }).ToList();
            return modulos;
         
        }
    }
}
