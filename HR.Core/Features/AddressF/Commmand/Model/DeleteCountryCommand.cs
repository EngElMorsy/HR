using HR.Core.Bases;
using MediatR;

namespace HR.Core.Features.AddressF.Commmand.Model
{
    public class DeleteCountryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteCountryCommand(int id)
        {
            Id = id;
        }
    }
}

