using HR.Core.Features.EmployeF.Command.Model;
using HR.Data.Entities.EmployeeData;

namespace HR.Core.Mapping.EmployeeMap
{
    public partial class EmployeeProfile
    {
        public void AddEmployeeCommandMapping()
        {
            CreateMap<AddEmployeeCommand, Employee>()
             .ForMember(dest => dest.DepartId, opt => opt.MapFrom(src => src.DepartId))
             .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.DistrictId));
            //.ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
            //.ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));

        }

    }
}
