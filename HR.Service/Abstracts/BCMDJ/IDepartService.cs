using MG_HR.DATA.Entity.BCMDJ;

namespace HR.Service.Abstracts.BCMDJ
{
    public interface IDepartService
    {
        public Task<Depart> GetDepartmentById(int id);
        public Task<bool> IsDepartmentIdExist(int departmentId);
    }
}
