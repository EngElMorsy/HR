using HR.Infrustructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.Infrustructure.InfrastructBases.GeneRepo
{
    public class GenericRepAsync<T> : IGenericRepAsync<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private DbSet<T> dbSet;
        public GenericRepAsync(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        #region NonAsync 

        #region GetOne
        public T GetById(int Id)
        {
            return dbSet.Find(Id);
        }
        public T Find(Expression<Func<T, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }
        public T Find(Expression<Func<T, bool>> filter, string[] Inclues = null)
        {
            IQueryable<T> query = dbSet;

            if (Inclues != null)
                foreach (var include in Inclues)
                    query = query.Include(include);
            return query.SingleOrDefault();

            //IQueryable<T> query = dbSet;

            //foreach (Expression<Func<T, object>> include in includes)
            //    query = query.Include(include);

            //if (filter != null)
            //    query = query.Where(filter);

            //if (orderBy != null)
            //    query = orderBy(query);

            //return query.ToList();
        }
        #endregion

        #region GetAll
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public List<T> FindAllOutList(Expression<Func<T, bool>> filter, string[] Inclues = null)
        {
            IQueryable<T> query = dbSet;

            if (Inclues != null)
                foreach (var include in Inclues)
                    query = query.Include(include);
            return query.Where(filter).ToList();
        }
        public IEnumerable<T> FindAllOutIEnumerable(Expression<Func<T, bool>> filter = null, string[] Inclues = null)
        {
            IQueryable<T> query = dbSet;

            if (Inclues != null)
                foreach (var include in Inclues)
                    query = query.Include(include);
            return query.Where(filter).ToList();
        }
        public List<T> FindAllOutList(Expression<Func<T, bool>> filter, int take, int skip)
        {
            IQueryable<T> query = dbSet;
            return query.Where(filter).Skip(skip).Take(take).ToList();
        }
        public IEnumerable<T> FindAllOutIEnumerable(Expression<Func<T, bool>> filter, int take, int skip)
        {
            IQueryable<T> query = dbSet;
            return query.Where(filter).Skip(skip).Take(take).ToList();
        }
        public List<T> FindAllOutList(Expression<Func<T, bool>> filter, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = dbSet.Where(filter);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            {
                if (orderByDirection == "Asc")
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }

        public IEnumerable<T> FindAllOutIEnumerable(Expression<Func<T, bool>> filter, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = dbSet.Where(filter);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            {
                if (orderByDirection == "Asc")
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
        #endregion

        #endregion

        #region  Async 
        #region GetOne
        public async Task<T> GetByIdAsync(int Id)
        {
            return await dbSet.FindAsync(Id);
        }
        //(x=>x.titleName=="")
        public async Task<T> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.SingleOrDefaultAsync(filter);
        }
        //(x=>x.titleName=="",new []{"Depart"})
        public async Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] Inclues = null)
        {
            IQueryable<T> query = dbSet;

            if (Inclues != null)
                foreach (var include in Inclues)
                    query = query.Include(include);
            return await query.SingleOrDefaultAsync();

            //IQueryable<T> query = dbSet;

            //foreach (Expression<Func<T, object>> include in includes)
            //    query = query.Include(include);

            //if (filter != null)
            //    query = query.Where(filter);

            //if (orderBy != null)
            //    query = orderBy(query);

            //return query.ToList();
        }

        #endregion

        #region GetAll
        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllOutIEnumerableAsync(Expression<Func<T, bool>> filter = null, string[] Inclues = null)
        {
            IQueryable<T> query = dbSet;

            if (Inclues != null)
                foreach (var include in Inclues)
                    query = query.Include(include);
            return await query.Where(filter).ToListAsync();
        }
        public async Task<List<T>> FindAllOutListAsync(Expression<Func<T, bool>> filter, int take, int skip)
        {
            IQueryable<T> query = dbSet;
            return await query.Where(filter).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<T>> FindAllOutListAsync(Expression<Func<T, bool>> filter, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = dbSet.Where(filter);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            {
                if (orderByDirection == "Asc")
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }
        #endregion

        #endregion




        public async Task<IEnumerable<T>> GetEnumerAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<List<T>> GetListAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


    }
}
