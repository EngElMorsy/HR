using HR.Core.Bases;
using HR.Core.Features.EmployeF.Query.Reponse;
using MediatR;

namespace HR.Core.Features.EmployeF.Query.Model
{
    public class GetEmployeeListQuery : IRequest<Response<List<GetEmployeeListRespose>>>
    {

    }
}
