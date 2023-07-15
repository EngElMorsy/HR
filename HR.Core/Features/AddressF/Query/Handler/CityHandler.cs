using AutoMapper;
using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.City;
using HR.Core.Features.AddressF.Query.Model.City;
using HR.Core.Resources;
using HR.Service.Abstracts.BaseInterface;
using MediatR;
using MG_HR.DATA.Entity.Address;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.AddressF.Query.Handler
{
    public class CityHandler : ResponseHandler, IRequestHandler<GetCityListQuery, Response<List<CityResponse>>>,
                                                   IRequestHandler<GetCityIDQuery, Response<CityResponse>>
    {
        #region Fileds
        private readonly IGenericService<City> _CityServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public CityHandler(IGenericService<City> CityServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _CityServices = CityServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<List<CityResponse>>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            var List = await _CityServices.FindAllAsync(null, new[] { "Country" });
            var ListMapper = _mapper.Map<List<CityResponse>>(List);
            return Success(ListMapper);
            //result.Meta = new { Count = studentListMapper.Count() };
            //return result;
        }

        public async Task<Response<CityResponse>> Handle(GetCityIDQuery request, CancellationToken cancellationToken)
        {
            var entityID = await _CityServices.FindAsync(x => x.Id == request.id, new[] { "Country" });
            if (entityID == null) return NotFound<CityResponse>();

            var result = _mapper.Map<CityResponse>(entityID);
            return Success(result);
        }
        #endregion


    }
}
