using HR.Data.Entities.EmployeeData;
using HR.Infrustructure.Context;
using HR.Infrustructure.Implement;
using HR.Infrustructure.InfrastructBases.GenericRepositry;
using Microsoft.EntityFrameworkCore;

namespace HR.Infrustructure.Repositry
{
    public class EmployeeRep : GenericRepositoryAsync<Employee>, IEmployeeRep
    {
        #region Fileds
        private readonly DbSet<Employee> _Employee;

        #endregion

        #region Constructor
        public EmployeeRep(ApplicationDBContext Context) : base(Context)
        {
            _Employee = Context.Set<Employee>();
        }
        #endregion

        public async Task<List<Employee>> GetEmpListAsync()
        {
            return await _Employee.Include(x => x.Depart).ToListAsync();
        }
    }
}
