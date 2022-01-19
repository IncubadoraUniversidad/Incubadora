

using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class CarreraRepository : BaseRepository<CatCarreras>
    {
        public CarreraRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
