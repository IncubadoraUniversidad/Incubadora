using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class DocenteRepository : BaseRepository<Docentes>
    {
        public DocenteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
