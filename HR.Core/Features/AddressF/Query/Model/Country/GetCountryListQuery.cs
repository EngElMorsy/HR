using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.Country;
using MediatR;

namespace HR.Core.Features.AddressF.Query.Model.Country
{
    public class GetCountryListQuery : IRequest<Response<List<CountryResponse>>>
    {

    }
}
