using HR.Core.Bases;
using HR.Core.Features.EmployeF.Query.Reponse;
using MediatR;

namespace HR.Core.Features.EmployeF.Query.Model
{
    public class GetEmployeeByIDQuery : IRequest<Response<GetSingleEmployeeResponse>>
    {
        public int id { get; set; }
        public GetEmployeeByIDQuery(int Id)
        {
            id = Id;

        }
    }
}
