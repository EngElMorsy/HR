using HR.Infrustructure.InfrastructBases.GenericRepositry;
using HR.Service.Abstracts.BaseInterface;
using System.Linq.Expressions;

namespace HR.Service.Implementions.BaseRepositry
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepositoryAsync<T> _entityRep;

        public GenericService(IGenericRepositoryAsync<T> entityRep)
        {
            _entityRep = entityRep;
        }

        #region Query  
        public async Task<T> GetByIdAsync(int id)
        {

            var Emp = await _entityRep.GetByIdAsync(id);
            return Emp;
        }
        public async Task<List<T>> GetListAsync()
        {

            return await _entityRep.GetListAsync();
        }


        #endregion

        #region Command
        public async Task<string> AddAsync(T Entity)
        {
            await _entityRep.AddAsync(Entity);
            return "Success";
        }
        public async Task<string> EditAsync(T Entity)
        {
            await _entityRep.UpdateAsync(Entity);
            return "Success";
        }
        public async Task<string> DeleteAsync(T Entity)
        {
            var trans = _entityRep.BeginTransaction();
            try
            {
                await _entityRep.DeleteAsync(Entity);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }



        public async Task<bool> IsNameExist(Expression<Func<T, bool>> filter)
        {
            var data = await _entityRep.IsNameExist(filter);
            if (data == null) return false;
            return true;
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            return await _entityRep.FindAsync(criteria, includes);

        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria = null, string[] includes = null)
        {
            return await _entityRep.FindAllAsync(criteria, includes);

        }




        #endregion







    }
}
