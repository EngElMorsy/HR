using HR.Core.Features.EmployeF.Command.Model;
using HR.Core.Features.EmployeF.Query.Model;
using HR.Data.AppMetaData;
using HRApi.Base;
using Microsoft.AspNetCore.Mvc;

namespace HRApi.Controllers.Employee
{
    [ApiController]
    //[Microsoft.AspNetCore.Components.Route("v/employee")]
    public class EmployeeController : AppControllerBase
    {


        [HttpGet(Router.EmployeeRouting.List)]

        public async Task<IActionResult> GetEmployeeList()
        {
            var respose = await Mediator.Send(new GetEmployeeListQuery());
            return Ok(respose);
        }

        [HttpGet(Router.EmployeeRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetEmployeePaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.EmployeeRouting.GetByID)]
        public async Task<IActionResult> GetEmployeeID([FromRoute] int id)
        {
            // var respose = await _mediator.Send(new GetEmployeeByIDQuery() {Id=id });
            // var respose = );

            return NewResult(await Mediator.Send(new GetEmployeeByIDQuery(id)));
        }
        [HttpPost(Router.EmployeeRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddEmployeeCommand command)
        {
            var response = await Mediator.Send(command);
            //return RedirectToAction("GetEmployeeList");
            return NewResult(response);
        }

        [HttpPut(Router.EmployeeRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditEmployeeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.EmployeeRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteEmployeeCommand(id)));
        }
    }
}
