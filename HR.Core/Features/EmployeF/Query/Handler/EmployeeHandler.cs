using AutoMapper;
using HR.Core.Bases;
using HR.Core.Features.EmployeF.Query.Model;
using HR.Core.Features.EmployeF.Query.Reponse;
using HR.Core.Resources;
using HR.Core.Wrappers;
using HR.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.EmployeF.Query.Handler
{
    public class EmployeeHandler : ResponseHandler,
        IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeListRespose>>>,
        IRequestHandler<GetEmployeeByIDQuery, Response<GetSingleEmployeeResponse>>,
        IRequestHandler<GetEmployeePaginatedListQuery, PaginatedResult<GetEmployeePaginatedListResponse>>
    {
        #region Fileds
        private readonly IEmployeeServices _employeeServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructor
        public EmployeeHandler(IEmployeeServices employeeServices, IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _employeeServices = employeeServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        public async Task<Response<List<GetEmployeeListRespose>>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var EmployeeList = await _employeeServices.GetEmpListAsync();
            var EmployeeListMapper = _mapper.Map<List<GetEmployeeListRespose>>(EmployeeList);
            var result = Success(EmployeeListMapper);
            result.Meta = new { Count = EmployeeListMapper.Count() };
            return result;
            //var result = Success(studentListMapper);
            //result.Meta = new { Count = EmployeeListMapper.Count() };
            //return result;
        }

        public async Task<Response<GetSingleEmployeeResponse>> Handle(GetEmployeeByIDQuery request, CancellationToken cancellationToken)
        {
            var EmployeID = await _employeeServices.GetEmployeeByIDAsync(request.id);
            if (EmployeID == null) return NotFound<GetSingleEmployeeResponse>();
            var result = _mapper.Map<GetSingleEmployeeResponse>(EmployeID);
            return Success(result);

        }

        public async Task<PaginatedResult<GetEmployeePaginatedListResponse>> Handle(GetEmployeePaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Employee, GetEmployeePaginatedListResponse>> expression = e => new GetEmployeePaginatedListResponse(e.Id, e.Code, e.Localize(e.NameAr, e.NameEn), e.IsActive, e.DTBrith, e.Age, e.Address, e.NationID,
            // e.DTexp, e.Gender, e.Religion, e.Social, e.Position, e.Depart.Localize(e.NameAr, e.NameEn));

            // var querable = _employeeServices.GetEmployeesQuerable();
            var FilterQuery = _employeeServices.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);

            //var PaginatedList = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var PaginatedList = await _mapper.ProjectTo<GetEmployeePaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            //FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
    }
}
