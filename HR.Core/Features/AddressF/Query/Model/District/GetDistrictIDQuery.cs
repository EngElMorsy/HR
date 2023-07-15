using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.District;
using MediatR;

namespace HR.Core.Features.AddressF.Query.Model.District
{
    public class GetDistrictIDQuery : IRequest<Response<DistrictResponse>>
    {
        public int id { get; set; }
        public GetDistrictIDQuery(int Id)
        {
            id = Id;

        }
    }
}
