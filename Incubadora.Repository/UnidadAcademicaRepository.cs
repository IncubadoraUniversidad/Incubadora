using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class UnidadAcademicaRepository : BaseRepository<CatUnidadesAcademicas>
    {
        public UnidadAcademicaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
