using HR.Infrustructure.InfrastructBases.GenericRepositry;
using HR.Service.Abstracts.Address;
using MG_HR.DATA.Entity.Address;
using Microsoft.EntityFrameworkCore;

namespace HR.Service.Implementions.Address
{
    public class DistrictServices : IDisrtrictServices
    {
        private readonly IGenericRepositoryAsync<District> _districtRep;

        public DistrictServices(IGenericRepositoryAsync<District> DistrictRep)
        {
            _districtRep = DistrictRep;
        }

        public async Task<District> GetctDistriById(int id)
        {
            var District = await _districtRep.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            //.Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
            //                                           .Include(x => x.Instructors)
            //                                           .Include(x => x.Instructor).FirstOrDefaultAsync();

            return District;
        }

        public async Task<List<District>> GetDistrictListAsync()
        {
            return await _districtRep.GetTableAsTracking().Include(x => x.City).ToListAsync();

        }

        public async Task<bool> IsDistrictIdExist(int DistrictId)
        {
            return await _districtRep.GetTableNoTracking().AnyAsync(x => x.Id == DistrictId);
        }
    }
}
