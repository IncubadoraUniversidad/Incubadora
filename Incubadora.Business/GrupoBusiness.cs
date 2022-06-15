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
    public class GrupoBusiness : IGrupoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly GrupoRepository repository;

        public GrupoBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new GrupoRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de consultar todos los grupos del catálogo de la bd
        /// </summary>
        /// <returns>Una lista de los grupos</returns>
        public List<GrupoDomainModel> GetGrupos()
        {
            var grupos = repository.GetAll().Select(g => new GrupoDomainModel
            {
                Id = g.Id,
                StrValor = g.StrValor
            }).ToList();
            return grupos;
        }

        /// <summary>
        /// Este método se encarga de consultar el grupo por Id del catálogo de la bd
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns>Un grupo</returns>
        public GrupoDomainModel GetGrupoById(string IdGrupo)
        {
            GrupoDomainModel grupoDM = new GrupoDomainModel();
            var grupo = repository.SingleOrDefault(p => p.Id == IdGrupo);
            grupoDM.StrValor = grupo.StrValor;
            return grupoDM;
        }
    }
}
