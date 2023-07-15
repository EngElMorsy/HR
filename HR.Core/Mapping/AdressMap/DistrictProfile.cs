using AutoMapper;
using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Features.AddressF.Query.CustColm.District;
using MG_HR.DATA.Entity.Address;

namespace HR.Core.Mapping.AddressMap
{
    public class DistrictProfile : Profile
    {

        public DistrictProfile()
        {
            GetDistrictMap();
            AddDistrictCommandMapping();
            EditCityCommandMapping();
        }


        #region QUERY 
        public void GetDistrictMap()
        {
            CreateMap<District, DistrictResponse>()
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Localize(src.City.NameAr, src.City.NameEn)))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));


        }
        #endregion


        #region COMMAND 
        public void AddDistrictCommandMapping()
        {
            CreateMap<AddDistrictCommand, District>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));
        }

        public void EditCityCommandMapping()
        {
            CreateMap<EditDistrictCommand, District>()
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));
        }
        #endregion


    }
}
