using AutoMapper;
using HR.Core.Bases;
using HR.Core.Features.AddressF.Query.CustColm.Country;
using HR.Core.Features.AddressF.Query.Model.Country;
using HR.Core.Resources;
using HR.Service.Abstracts.BaseInterface;
using MediatR;
using MG_HR.DATA.Entity.Address;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.AddressF.Query.Handler
{
    public class CountryHandler : ResponseHandler, IRequestHandler<GetCountryListQuery, Response<List<CountryResponse>>>,
                                                   IRequestHandler<GetCountryIDQuery, Response<CountryResponse>>
    {
        #region Fileds
        private readonly IGenericService<Country> _countryServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public CountryHandler(IGenericService<Country> countryServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _countryServices = countryServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<List<CountryResponse>>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var List = await _countryServices.GetListAsync();
            var ListMapper = _mapper.Map<List<CountryResponse>>(List);
            return Success(ListMapper);
            //result.Meta = new { Count = studentListMapper.Count() };
            //return result;
        }

        public async Task<Response<CountryResponse>> Handle(GetCountryIDQuery request, CancellationToken cancellationToken)
        {
            var entityID = await _countryServices.GetByIdAsync(request.id);
            if (entityID == null) return NotFound<CountryResponse>();

            var result = _mapper.Map<CountryResponse>(entityID);
            return Success(result);
        }
        #endregion


    }
}
