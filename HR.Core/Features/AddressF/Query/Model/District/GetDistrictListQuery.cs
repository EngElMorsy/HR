﻿using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.District;
using MediatR;

namespace HR.Core.Features.AddressF.Query.Model.District
{
    public class GetDistrictListQuery : IRequest<Response<List<DistrictResponse>>>
    {

    }
}
