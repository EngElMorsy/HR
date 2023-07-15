using HR.Core.Features.AddressF.Query.Model.Country;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers.Address
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/Address/Country/List")]
        public async Task<IActionResult> GetCountryList()
        {
            var respose = await _mediator.Send(new GetCountryListQuery());
            return Ok(respose);
        }
        [HttpGet("/Address/Country/Id")]
        public async Task<IActionResult> GetCountryId(int Id)
        {
            var respose = await _mediator.Send(new GetCountryIDQuery(Id));
            return Ok(respose);
        }
    }
}
