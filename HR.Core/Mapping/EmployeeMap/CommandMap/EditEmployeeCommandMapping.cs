using HR.Core.Features.EmployeF.Command.Model;
using HR.Data.Entities.EmployeeData;

namespace HR.Core.Mapping.EmployeeMap
{
    public partial class EmployeeProfile
    {
        public void EditEmployeeCommandMapping()
        {
            CreateMap<EditEmployeeCommand, Employee>()
          .ForMember(dest => dest.DepartId, opt => opt.MapFrom(src => src.DepartId))
          //.ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
          //.ForMember(dest => dest.DisName, opt => opt.MapFrom(src => src.))
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
