using HR.Data.Entities.EmployeeData;
using HR.Data.Helper;

namespace HR.Service.Abstracts
{
    public interface IEmployeeServices
    {
        public Task<List<Employee>> GetEmpListAsync();
        public Task<Employee> GetEmployeeByIDAsync(int id);
        public Task<string> AddEmployee(Employee Employee);
        public Task<Employee> GetEmployeeByCode(int Code);
        public Task<bool> IsEmployeeCodeExist(int EmployeeCode);

        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Employee Employee);
        public Task<string> DeleteAsync(Employee Employee);

        public IQueryable<Employee> GetEmployeesQuerable();
        //  public IQueryable<Employee> FilterStudentPaginatedQuerable(string search);
        public IQueryable<Employee> FilterStudentPaginatedQuerable(EmployeeOrderingEnum orderingEnum, string search);
    }
    //public Task<Student> GetStudentByIDWithIncludeAsync(int id);

    //public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);

}

