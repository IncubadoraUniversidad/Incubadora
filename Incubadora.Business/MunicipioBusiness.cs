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
    public class MunicipioBusiness : IMunicipioBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly MunicipioRepository repository;

        public MunicipioBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new MunicipioRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de retornar todos los municipios que pertenezcan a un estado
        /// </summary>
        /// <param name="idEstado">El Id del estado</param>
        /// <returns>Una lista de municipios filtrada por el estado al que pertenecen</returns>
        public List<MunicipioDomainModel> GetMunicipiosByEstadoId(int idEstado)
        {
            var municipios = repository.GetAll(municipio => municipio.IdEstado == idEstado).Select(m => new MunicipioDomainModel
            {
                Id = m.Id,
                IdEstado = m.IdEstado,
                StrNombre = m.StrNombre,
                StrDescripcion = m.StrDescripcion
            }).ToList();
            return municipios;
        }
    }
}
