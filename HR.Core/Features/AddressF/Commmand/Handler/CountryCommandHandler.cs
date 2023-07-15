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
    public class CountryCommandHandler : ResponseHandler,
                                  IRequestHandler<AddCountryCommand, Response<string>>,
                                  IRequestHandler<EditCountryCommand, Response<string>>,
                                  IRequestHandler<DeleteCountryCommand, Response<string>>
    {
        #region Fileds

        private readonly IGenericService<Country> _CountryServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public CountryCommandHandler(IGenericService<Country> CountryServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _CountryServices = CountryServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        public async Task<Response<string>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and student
            var Countmapper = _mapper.Map<Country>(request);
            //add
            var result = await _CountryServices.AddAsync(Countmapper);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditCountryCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Check = await _CountryServices.GetByIdAsync(request.Id);
            //return NotFound
            if (Check == null) return NotFound<string>();
            //mapping Between request and student
            var Checkmapper = _mapper.Map(request, Check);
            //Call service that make Edit
            var result = await _CountryServices.EditAsync(Checkmapper);
            //return response
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Check = await _CountryServices.GetByIdAsync(request.Id);
            //return NotFound
            if (Check == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _CountryServices.DeleteAsync(Check);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
