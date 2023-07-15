using HR.Core.Bases;
using MediatR;

namespace HR.Core.Features.AddressF.Commmand.Model
{
    public class AddCityCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CountryId { get; set; }
    }
}
