using HR.Data.Entities.EmployeeData;
using HR.Data.Helper;
using HR.Infrustructure.Implement;
using HR.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HR.Service.Implementions
{
    public class EmployeeServices : IEmployeeServices
    {
        #region Fileds
        private readonly IEmployeeRep _employeeRep;

        #endregion

        #region Constructor
        public EmployeeServices(IEmployeeRep employeeRep)
        {
            _employeeRep = employeeRep;
        }

        #endregion

        #region Query
        public async Task<List<Employee>> GetEmpListAsync()
        {
            //if you have alogic put here
            return await _employeeRep.GetEmpListAsync();
        }
        public async Task<Employee> GetEmployeeByIDAsync(int id)
        {
            //var Emp = await _employeeRep.GetByIdAsync(id);
            //return Emp; 
            var Emp = _employeeRep.GetTableNoTracking()
            .Include(x => x.Depart)
            .Where(x => x.Id == id).SingleOrDefault();
            return Emp;
        }
        #endregion


        #region Command
        public async Task<string> AddEmployee(Employee Employee)
        {
            await _employeeRep.AddAsync(Employee);
            return "Success";
        }
        public async Task<string> EditAsync(Employee Employee)
        {
            await _employeeRep.UpdateAsync(Employee);
            return "Success";
        }
        public async Task<string> DeleteAsync(Employee Employee)
        {
            var trans = _employeeRep.BeginTransaction();
            try
            {
                //Employee.Address = "cairo";
                await _employeeRep.UpdateAsync(Employee);
                await _employeeRep.DeleteAsync(Employee);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }
        #endregion



        #region Select
        public async Task<bool> IsNameArExist(string nameAr)
        {
            //check if name exists 
            var Employeeresult = _employeeRep.GetTableNoTracking().Where(x => x.NameAr == nameAr).FirstOrDefault();
            if (Employeeresult == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //check if name exists 
            var Employeeresult = _employeeRep.GetTableNoTracking().Where(x => x.NameEn == nameEn).FirstOrDefault();
            if (Employeeresult == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {

            //Check if the name is Exist Or not
            var employe = await _employeeRep.GetTableNoTracking().Where(x => x.NameAr == nameAr & x.Id != id).FirstOrDefaultAsync();
            if (employe == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {

            //Check if the name is Exist Or not
            var employe = await _employeeRep.GetTableNoTracking().Where(x => x.NameEn == nameEn & x.Id != id).FirstOrDefaultAsync();
            if (employe == null) return false;
            return true;
        }


        public IQueryable<Employee> GetEmployeesQuerable()
        {
            return _employeeRep.GetTableNoTracking().Include(x => x.Depart).AsQueryable();

        }

        //public IQueryable<Employee> FilterStudentPaginatedQuerable(string search)
        //{
        //    var querable = _employeeRep.GetTableNoTracking().Include(x => x.Depart).AsQueryable();
        //    if (search != null)
        //    {
        //        querable = querable.Where(x => x.DisName.Contains(search));
        //    }
        //    return querable;
        //}
        public IQueryable<Employee> FilterStudentPaginatedQuerable(EmployeeOrderingEnum orderingEnum, string search)
        {
            var querable = _employeeRep.GetTableNoTracking().Include(x => x.Depart).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.NameAr.Contains(search) || x.NameEn.Contains(search));
                switch (orderingEnum)
                {
                    case EmployeeOrderingEnum.Id:
                        querable = querable.OrderBy(x => x.Id);
                        break;
                    case EmployeeOrderingEnum.Code:
                        querable = querable.OrderByDescending(x => x.Code);
                        break;
                }
            }
            return querable;
        }

        public async Task<Employee> GetEmployeeByCode(int Code)
        {
            var Employee = await _employeeRep.GetTableNoTracking().Where(x => x.Code == Code).Include(x => x.Depart).FirstOrDefaultAsync();
            //.Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
            //                                           .Include(x => x.Instructors)
            //                                           .Include(x => x.Instructor).FirstOrDefaultAsync();

            return Employee;
        }

        public async Task<bool> IsEmployeeCodeExist(int EmployeeCode)
        {
            return await _employeeRep.GetTableNoTracking().AnyAsync(x => x.Code == EmployeeCode);

        }
        #endregion






    }
}
