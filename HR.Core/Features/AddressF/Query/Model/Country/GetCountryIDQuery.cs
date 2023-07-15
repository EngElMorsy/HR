using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.Country;
using MediatR;

namespace HR.Core.Features.AddressF.Query.Model.Country
{
    public class GetCountryIDQuery : IRequest<Response<CountryResponse>>
    {
        public int id { get; set; }
        public GetCountryIDQuery(int Id)
        {
            id = Id;

        }
    }
}
