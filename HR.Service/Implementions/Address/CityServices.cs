using HR.Infrustructure.InfrastructBases.GenericRepositry;
using HR.Service.Abstracts.Address;
using MG_HR.DATA.Entity.Address;
using Microsoft.EntityFrameworkCore;

namespace HR.Service.Implementions.Address
{
    public class CityServices : ICityServices
    {
        private readonly IGenericRepositoryAsync<City> _cityRep;

        public CityServices(IGenericRepositoryAsync<City> CityRep)
        {
            _cityRep = CityRep;
        }

        public async Task<List<City>> GetCityListAsync()
        {
            return await _cityRep.GetTableAsTracking().Include(x => x.Country).ToListAsync();
            //   return await _cityRep.Get();

        }


    }
}
