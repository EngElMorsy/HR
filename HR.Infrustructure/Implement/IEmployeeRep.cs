using HR.Data.Entities.EmployeeData;
using HR.Infrustructure.InfrastructBases.GenericRepositry;

namespace HR.Infrustructure.Implement
{
    public interface IEmployeeRep : IGenericRepositoryAsync<Employee>
    {
        public Task<List<Employee>> GetEmpListAsync();
    }
}
