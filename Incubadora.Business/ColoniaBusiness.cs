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
    public class ColoniaBusiness : IColoniaBusiness
    {
        //estoy generando cambios erik guerrero bravo
        private readonly IUnitOfWork unitOfWork;
        private readonly ColoniaRepository repository;

        public ColoniaBusiness(IUnitOfWork _unitOfWork)
        {
             this.unitOfWork = _unitOfWork;
            repository = new ColoniaRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este método se encarga de retornar todas las colonias que pertenezcan a un municipio
        /// </summary>
        /// <param name="idMunicipio">El id del municipio</param>
        /// <returns>Una lista de colonias filtradas por el municipio al que pertenecen</returns>
        public List<ColoniaDomainModel> GetColoniasByMunicipioId(int idMunicipio)
        {
            var colonias = repository.GetAll(colonia => colonia.IdMunicipio == idMunicipio).Select(c => new ColoniaDomainModel
            {
                Id = c.Id,
                IdMunicipio = c.IdMunicipio,
                StrCodigoPostal = c.StrCodigoPostal,
                StrDescripcion = c.StrDescripcion,
                StrNombre = c.StrNombre
            }).ToList();
            return colonias;
        }
    }
}
