using HR.Core.Features.EmployeF.Query.Reponse;
using HR.Data.Entities.EmployeeData;

namespace HR.Core.Mapping.EmployeeMap
{
    public partial class EmployeeProfile
    {
        public void GetEmployeeByIDMap()
        {
            CreateMap<Employee, GetSingleEmployeeResponse>()
          .ForMember(dest => dest.DepartName, opt => opt.MapFrom(src => src.Depart.Localize(src.Depart.NameAr, src.Depart.NameEn)))
          .ForMember(dest => dest.DisName, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
