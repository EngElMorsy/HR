using AutoMapper;
using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Features.AddressF.Query.CustColm.City;
using MG_HR.DATA.Entity.Address;

namespace HR.Core.Mapping.AddressMap
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            GetCityMap();
            AddCityCommandMapping();
            EditCityCommandMapping();
        }


        #region Query  
        public void GetCityMap()
        {
            CreateMap<City, CityResponse>()
           .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Localize(src.Country.NameAr, src.Country.NameEn)))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
        #endregion



        #region Command  
        public void AddCityCommandMapping()
        {
            CreateMap<AddCityCommand, City>()
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId));
        }

        public void EditCityCommandMapping()
        {
            CreateMap<EditCityCommand, City>()
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId));
        }

        #endregion
    }
}
