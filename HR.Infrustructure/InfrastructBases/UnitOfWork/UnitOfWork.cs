using HR.Infrustructure.Context;

namespace HR.Infrustructure.InfrastructBases.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;


        // public IBaseRepositry<TD> TD { get; private set; } 

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Compelete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
