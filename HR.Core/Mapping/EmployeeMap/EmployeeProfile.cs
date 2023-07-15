using AutoMapper;

namespace HR.Core.Mapping.EmployeeMap
{
    public partial class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            GetEmployeeListMap();
            GetEmployeeByIDMap();
            AddEmployeeCommandMapping();
            EditEmployeeCommandMapping();
            GetStudentPaginationMapping();
        }
    }
}
