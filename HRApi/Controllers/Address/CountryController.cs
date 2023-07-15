using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Features.AddressF.Query.Model.Country;
using HR.Data.AppMetaData;
using HRApi.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRApi.Controllers.Address
{
    // [Route("api/[controller]")]
    [ApiController]
    public class CountryController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Router.CountryRouting.GetByID)]
        public async Task<IActionResult> GetCountryId([FromRoute] int id)
        {
            var respose = await _mediator.Send(new GetCountryIDQuery(id));
            return Ok(respose);
        }

        [HttpGet(Router.CountryRouting.List)]
        public async Task<IActionResult> GetCountryList()
        {
            var respose = await _mediator.Send(new GetCountryListQuery());
            return Ok(respose);
        }

        [HttpPost(Router.CountryRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddCountryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut(Router.CountryRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditCountryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.CountryRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteCountryCommand(id)));
        }
    }
}
