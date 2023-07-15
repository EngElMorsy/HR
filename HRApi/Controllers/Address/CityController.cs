using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Features.AddressF.Query.Model.City;
using HR.Data.AppMetaData;
using HRApi.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRApi.Controllers.Address
{
    // [Route("api/[controller]")]
    [ApiController]
    public class CityController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.CityRouting.GetByID)]
        public async Task<IActionResult> GetCityId([FromRoute] int id)
        {
            var respose = await _mediator.Send(new GetCityIDQuery(id));
            return Ok(respose);
        }

        [HttpGet(Router.CityRouting.List)]
        public async Task<IActionResult> GetCityList()
        {
            var respose = await _mediator.Send(new GetCityListQuery());
            return Ok(respose);
        }



        [HttpPost(Router.CityRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddCityCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut(Router.CityRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditCityCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.CityRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteCityCommand(id)));
        }
    }
}
