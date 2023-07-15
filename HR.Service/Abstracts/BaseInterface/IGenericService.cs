using System.Linq.Expressions;

namespace HR.Service.Abstracts.BaseInterface
{
    public interface IGenericService<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetListAsync();
        public Task<string> AddAsync(T Entity);
        public Task<string> EditAsync(T Entity);
        public Task<string> DeleteAsync(T Entity);
        public Task<bool> IsNameExist(Expression<Func<T, bool>> filter);

        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria = null, string[] includes = null);


        //public List<T> GetList(Expression<Func<T, bool>> filter = null,
        //Func<IQueryable<T>,
        //IOrderedQueryable<T>> orderBy = null,
        //params Expression<Func<T, object>>[] includes);
        //public Task<bool> IsNameArExist(string nameAr);
        //public Task<bool> IsNameEnExist(string nameEn);
    }
}
