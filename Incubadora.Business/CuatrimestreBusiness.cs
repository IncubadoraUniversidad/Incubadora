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
    public class CuatrimestreBusiness : ICuatrimestreBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CuatrimestreRepository repository;

        public CuatrimestreBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new CuatrimestreRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar todos los cuatrimestres de la bd.
        /// </summary>
        /// <returns>Una lista de cuatrimestres</returns>
        public List<CuatrimestreDomainModel> GetAll()
        {
            var cuatrimestres = repository.GetAll().Select(cuatri => new CuatrimestreDomainModel
            {
                Id = cuatri.Id,
                StrDescripcion = cuatri.StrDescripcion,
                StrValor = cuatri.StrValor
            }).ToList();
            return cuatrimestres;
        }
    }
}
