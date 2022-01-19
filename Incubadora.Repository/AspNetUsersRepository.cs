using Incubadora.Repository.Infraestructure;
using Incubadora.Repository.Infraestructure.Contract;

namespace Incubadora.Repository
{
    public class AspNetUsersRepository : BaseRepository<AspNetUsers>
    {
        public AspNetUsersRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
