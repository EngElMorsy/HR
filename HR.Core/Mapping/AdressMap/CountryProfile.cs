using AutoMapper;
using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Features.AddressF.Query.CustColm.Country;
using MG_HR.DATA.Entity.Address;

namespace HR.Core.Mapping.AdressMap
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {

            AddCountryCommandMapping();
            EditCountryCommandMapping();
            GetCountryMap();
        }

        #region Query 

        public void GetCountryMap()
        {
            //for goback 
            CreateMap<Country, CountryResponse>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

        }
        #endregion


        #region Command  
        public void AddCountryCommandMapping()
        {
            CreateMap<AddCountryCommand, Country>();
            //.ForMember(dest => dest.DepartId, opt => opt.MapFrom(src => src.DepartId));
        }
        public void EditCountryCommandMapping()
        {
            CreateMap<EditCountryCommand, Country>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }


        #endregion
    }
}
