using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.City;
using MediatR;

namespace HR.Core.Features.AddressF.Query.Model.City
{
    public class GetCityIDQuery : IRequest<Response<CityResponse>>
    {
        public int id { get; set; }
        public GetCityIDQuery(int Id)
        {
            id = Id;

        }
    }
}
