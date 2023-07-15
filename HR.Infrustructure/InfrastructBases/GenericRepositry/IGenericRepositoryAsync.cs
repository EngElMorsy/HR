using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace HR.Infrustructure.InfrastructBases.GenericRepositry
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        public Task<List<T>> GetListAsync();
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);

        Task<T> IsNameExist(Expression<Func<T, bool>> filter);

        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);


        //List<T> Get(Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>,
        //    IOrderedQueryable<T>> orderBy = null,
        //    params Expression<Func<T, object>>[] includes);

        //T GetFirstOrDefault(
        // Expression<Func<T, bool>> filter = null,
        // params Expression<Func<T, object>>[] includes);

        //Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter = null);
        //Task<IEnumerable<Employee>> SearchAsync(Expression<Func<Employee, bool>> filter = null);
        //Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter);
        //Task<Employee> CreateAsync(Employee obj);
        //Task UpdateAsync(Employee obj);
        //Task DeleteAsync(Employee obj);
    }
}
