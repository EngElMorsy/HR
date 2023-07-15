using AutoMapper;
using HR.Core.Bases;
using HR.Core.Features.EmployeF.Command.Model;
using HR.Core.Resources;
using HR.Data.Entities.EmployeeData;
using HR.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.EmployeF.Command.Handler
{
    public class EmployeeCommandHandler : ResponseHandler,
        IRequestHandler<AddEmployeeCommand, Response<string>>,
        IRequestHandler<EditEmployeeCommand, Response<string>>,
        IRequestHandler<DeleteEmployeeCommand, Response<string>>
    {

        #region Fileds
        private readonly IEmployeeServices _employeeServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Constructor
        public EmployeeCommandHandler(IEmployeeServices employeeServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _employeeServices = employeeServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        public async Task<Response<string>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and student
            var Employtmapper = _mapper.Map<Employee>(request);
            //add
            var result = await _employeeServices.AddEmployee(Employtmapper);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var employee = await _employeeServices.GetEmployeeByIDAsync(request.Id);
            //return NotFound
            if (employee == null) return NotFound<string>();
            //mapping Between request and student
            var employeemapper = _mapper.Map(request, employee);
            //Call service that make Edit
            var result = await _employeeServices.EditAsync(employeemapper);
            //return response
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Employee = await _employeeServices.GetEmployeeByIDAsync(request.Id);
            //return NotFound
            if (Employee == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _employeeServices.DeleteAsync(Employee);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
