using Incubadora.Repository.Infraestructure.Contract;
using System.Data.Entity;

namespace Incubadora.Repository.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IncubadoraDataBaseEntities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new IncubadoraDataBaseEntities();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
