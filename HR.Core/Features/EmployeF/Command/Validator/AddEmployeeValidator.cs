using FluentValidation;
using HR.Core.Features.EmployeF.Command.Model;
using HR.Core.Resources;
using HR.Service.Abstracts;
using HR.Service.Abstracts.Address;
using HR.Service.Abstracts.BCMDJ;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.EmployeF.Command.Validator
{
    public class AddCountryValidator : AbstractValidator<AddEmployeeCommand>
    {
        #region Fields
        private readonly IEmployeeServices _employeeService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartService _DepartService;
        private readonly IDisrtrictServices _disrtrictService;
        #endregion

        #region Constructors
        public AddCountryValidator(IEmployeeServices employeeService,
          IStringLocalizer<SharedResources> localizer,
          IDepartService DepartService,
          IDisrtrictServices DisrtrictService)
        {
            _employeeService = employeeService;
            _localizer = localizer;
            _DepartService = DepartService;
            _disrtrictService = DisrtrictService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis50]);
            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis50]);
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.DepartId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.DistrictId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Code)
          .MustAsync(async (Key, CancellationToken) => !await _employeeService.IsEmployeeCodeExist(Key))
          .WithMessage(_localizer[SharedResourcesKeys.IsExist]);


            RuleFor(x => x.NameAr)
                 .MustAsync(async (Key, CancellationToken) => !await _employeeService.IsNameArExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _employeeService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DepartId)
           .MustAsync(async (Key, CancellationToken) => await _DepartService.IsDepartmentIdExist(Key))
           .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

            RuleFor(x => x.DistrictId)
                .MustAsync(async (Key, CancellationToken) => await _disrtrictService.IsDistrictIdExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

        }

        #endregion
    }
}
