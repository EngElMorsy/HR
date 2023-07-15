using HR.Core.Features.EmployeF.Command.Model;
using HR.Core.Features.EmployeF.Query.Model;
using HR.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers.Employee
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Router.EmployeeRouting.List)]
        public async Task<IActionResult> GetEmployeeList()
        {
            var respose = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(respose);
        }

        [HttpGet(Router.EmployeeRouting.GetByID)]
        public async Task<IActionResult> GetEmployeeID([FromRoute] int id)
        {
            // var respose = await _mediator.Send(new GetEmployeeByIDQuery() {Id=id });
            var respose = await _mediator.Send(new GetEmployeeByIDQuery(id));

            return Ok(respose);
        }
        [HttpPost(Router.EmployeeRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddEmployeeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }


    }
}
