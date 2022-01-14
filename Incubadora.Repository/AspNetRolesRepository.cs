using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class AspNetRolesRepository : BaseRepository<AspNetRoles>
    {
        public AspNetRolesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
