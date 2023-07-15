using HR.Core.Bases;
using MediatR;

namespace HR.Core.Features.EmployeF.Command.Model
{
    //StudentCommand
    public class DeleteEmployeeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}

