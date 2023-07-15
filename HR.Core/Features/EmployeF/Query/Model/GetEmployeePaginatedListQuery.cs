using HR.Core.Features.EmployeF.Query.Reponse;
using HR.Core.Wrappers;
using HR.Data.Helper;
using MediatR;

namespace HR.Core.Features.EmployeF.Query.Model
{
    public class GetEmployeePaginatedListQuery : IRequest<PaginatedResult<GetEmployeePaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public EmployeeOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }

    }
}
