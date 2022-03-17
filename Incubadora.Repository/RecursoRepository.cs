using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class RecursoRepository : BaseRepository<Recursos>
    {
        public RecursoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
