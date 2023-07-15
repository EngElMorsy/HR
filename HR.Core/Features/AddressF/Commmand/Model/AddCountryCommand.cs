using HR.Core.Bases;
using MediatR;

namespace HR.Core.Features.AddressF.Commmand.Model
{
    public class AddCountryCommand : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}
