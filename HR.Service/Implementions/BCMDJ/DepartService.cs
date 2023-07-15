using HR.Infrustructure.InfrastructBases.GenericRepositry;
using HR.Service.Abstracts.BCMDJ;
using MG_HR.DATA.Entity.BCMDJ;
using Microsoft.EntityFrameworkCore;

namespace HR.Service.Implementions.BCMDJ
{
    public class DepartService : IDepartService
    {
        #region fileds  
        private readonly IGenericRepositoryAsync<Depart> _DepartRep;
        #endregion


        #region Constractor
        public DepartService(IGenericRepositoryAsync<Depart> DepartRep)
        {
            _DepartRep = DepartRep;
        }
        #endregion



        #region Actions  

        public async Task<Depart> GetDepartmentById(int id)
        {
            var Employee = await _DepartRep.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            //.Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
            //                                           .Include(x => x.Instructors)
            //                                           .Include(x => x.Instructor).FirstOrDefaultAsync();

            return Employee;
        }

        public async Task<bool> IsDepartmentIdExist(int departmentId)
        {
            return await _DepartRep.GetTableNoTracking().AnyAsync(x => x.Id == departmentId);



        }
        #endregion
    }
}
