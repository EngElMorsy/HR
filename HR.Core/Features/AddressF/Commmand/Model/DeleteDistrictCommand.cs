using HR.Core.Bases;
using MediatR;

namespace HR.Core.Features.AddressF.Commmand.Model
{
    public class DeleteDistrictCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDistrictCommand(int id)
        {
            Id = id;
        }
    }
}

