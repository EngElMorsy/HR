using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.City;
using MediatR;

namespace HR.Core.Features.AddressF.Query.Model.City
{
    public class GetCityListQuery : IRequest<Response<List<CityResponse>>>
    {

    }
}
