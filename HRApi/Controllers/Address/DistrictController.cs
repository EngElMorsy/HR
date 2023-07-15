using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Features.AddressF.Query.Model.District;
using HR.Data.AppMetaData;
using HRApi.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRApi.Controllers.Address
{
    // [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public DistrictController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Router.DistrictRouting.GetByID)]
        public async Task<IActionResult> GetDistrictId([FromRoute] int id)
        {
            var respose = await _mediator.Send(new GetDistrictIDQuery(id));
            return Ok(respose);
        }

        [HttpGet(Router.DistrictRouting.List)]
        public async Task<IActionResult> GetDistrictList()
        {
            var respose = await _mediator.Send(new GetDistrictListQuery());
            return Ok(respose);
        }

        [HttpPost(Router.DistrictRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDistrictCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut(Router.DistrictRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDistrictCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.DistrictRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteDistrictCommand(id)));
        }
    }
}
