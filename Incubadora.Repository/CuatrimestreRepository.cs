using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class CuatrimestreRepository : BaseRepository<CatCuatrimestres>
    {
        public CuatrimestreRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
