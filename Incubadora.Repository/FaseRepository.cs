using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class FaseRepository : BaseRepository<CatFases>
    {
        public FaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
