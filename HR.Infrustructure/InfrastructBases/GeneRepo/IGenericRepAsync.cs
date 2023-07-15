using System.Linq.Expressions;

namespace HR.Infrustructure.InfrastructBases.GeneRepo
{
    public interface IGenericRepAsync<T> where T : class
    {
        #region NonAsync 

        #region GetOne
        T GetById(int Id);
        T Find(Expression<Func<T, bool>> filter);
        T Find(Expression<Func<T, bool>> filter
          , string[] Inclues = null);
        #endregion

        #region GetAll
        IEnumerable<T> GetAll();

        IQueryable<T> GetTableNoTracking();

        #region List
        List<T> FindAllOutList(Expression<Func<T, bool>> filter
           , string[] Inclues = null);

        public List<T> FindAllOutList(Expression<Func<T, bool>> filter, int take, int skip);

        List<T> FindAllOutList(Expression<Func<T, bool>> filter
            , int? take, int? skip,
            Expression<Func<T, object>> orderBy = null,
            string orderByDirection = "ASC");
        #endregion


        #region IEnumerable
        IEnumerable<T> FindAllOutIEnumerable(Expression<Func<T, bool>> filter
           , string[] Inclues = null);
        public IEnumerable<T> FindAllOutIEnumerable(Expression<Func<T, bool>> filter, int take, int skip);

        IEnumerable<T> FindAllOutIEnumerable(Expression<Func<T, bool>> filter
           , int? take, int? skip,
           Expression<Func<T, object>> orderBy = null,
           string orderByDirection = "ASC");
        #endregion


        #endregion
        #endregion

        #region Async 

        #region GetOne
        Task<T> GetByIdAsync(int Id);
        Task<T> FindAsync(Expression<Func<T, bool>> filter);
        Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] Inclues = null);
        #endregion

        #region GetAll
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllOutIEnumerableAsync(Expression<Func<T, bool>> filter = null
            , string[] Inclues = null);

        Task<List<T>> FindAllOutListAsync(Expression<Func<T, bool>> filter
          , int take, int skip);


        Task<List<T>> FindAllOutListAsync(Expression<Func<T, bool>> filter
            , int? take, int? skip,
            Expression<Func<T, object>> orderBy = null,
            string orderByDirection = "ASC");
        #endregion


        Task<T> AddAsync(T entity);


        //Task CreateAsync(T obj);
        #endregion












        //public IEnumerable<Task<List<T>>> FindAll();
        //Expression<Func<T, bool>> filter = null,
        //Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //params Expression<Func<T, object>>[] includes);


    }
}
