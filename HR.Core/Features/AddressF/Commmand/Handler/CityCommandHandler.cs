using AutoMapper;
using HR.Core.Bases;
using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Resources;
using HR.Service.Abstracts.BaseInterface;
using MediatR;
using MG_HR.DATA.Entity.Address;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.AddressF.Commmand.Handler
{
    public class CityCommandHandler : ResponseHandler,
                                  IRequestHandler<AddCityCommand, Response<string>>,
                                  IRequestHandler<EditCityCommand, Response<string>>,
                                  IRequestHandler<DeleteCityCommand, Response<string>>
    {
        #region Fileds

        private readonly IGenericService<City> _CityServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public CityCommandHandler(IGenericService<City> CityServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _CityServices = CityServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        public async Task<Response<string>> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and student
            var Countmapper = _mapper.Map<City>(request);
            //add
            var result = await _CityServices.AddAsync(Countmapper);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditCityCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Check = await _CityServices.GetByIdAsync(request.Id);
            //return NotFound
            if (Check == null) return NotFound<string>();
            //mapping Between request and student
            var Checkmapper = _mapper.Map(request, Check);
            //Call service that make Edit
            var result = await _CityServices.EditAsync(Checkmapper);
            //return response
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Check = await _CityServices.GetByIdAsync(request.Id);
            //return NotFound
            if (Check == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _CityServices.DeleteAsync(Check);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
