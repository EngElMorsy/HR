using AutoMapper;
using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.District;
using HR.Core.Features.AddressF.Query.Model.District;
using HR.Core.Resources;
using HR.Service.Abstracts.BaseInterface;
using MediatR;
using MG_HR.DATA.Entity.Address;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.AddressF.Query.Handler
{
    public class DistrictHandler : ResponseHandler, IRequestHandler<GetDistrictListQuery, Response<List<DistrictResponse>>>,
                                                  IRequestHandler<GetDistrictIDQuery, Response<DistrictResponse>>
    {
        #region Fileds
        private readonly IGenericService<District> _DistrictServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public DistrictHandler(IGenericService<District> DistrictServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _DistrictServices = DistrictServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<List<DistrictResponse>>> Handle(GetDistrictListQuery request, CancellationToken cancellationToken)
        {
            var List = await _DistrictServices.FindAllAsync(null, new[] { "City" });
            var ListMapper = _mapper.Map<List<DistrictResponse>>(List);
            return Success(ListMapper);
            //result.Meta = new { Count = studentListMapper.Count() };
            //return result;
        }

        public async Task<Response<DistrictResponse>> Handle(GetDistrictIDQuery request, CancellationToken cancellationToken)
        {
            var entityID = await _DistrictServices.FindAsync(x => x.Id == request.id, new[] { "City" });
            if (entityID == null) return NotFound<DistrictResponse>();

            var result = _mapper.Map<DistrictResponse>(entityID);
            return Success(result);
        }
        #endregion


    }
}
