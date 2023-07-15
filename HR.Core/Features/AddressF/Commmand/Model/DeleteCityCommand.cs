using HR.Core.Bases;
using MediatR;

namespace HR.Core.Features.AddressF.Commmand.Model
{
    public class DeleteCityCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteCityCommand(int id)
        {
            Id = id;
        }
    }
}

