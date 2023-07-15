using FluentValidation;
using HR.Core.Features.AddressF.Commmand.Model;
using HR.Core.Resources;
using HR.Service.Abstracts.BaseInterface;
using MG_HR.DATA.Entity.Address;
using Microsoft.Extensions.Localization;

namespace HR.Core.Features.AddressF.Commmand.Validator
{
    public class EditCountryValidator : AbstractValidator<EditCountryCommand>
    {
        #region Fields
        private readonly IGenericService<Country> _Service;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Constructors
        public EditCountryValidator(IGenericService<Country> Service,
          IStringLocalizer<SharedResources> localizer)
        {
            _Service = Service;
            _localizer = localizer;

            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis50]);
            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                  .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis50]);
        }

        public void ApplyCustomValidationsRules()
        {


            RuleFor(x => new { x.NameAr, x.Id })
                 .MustAsync(async (Key, CancellationToken) => !await _Service.IsNameExist(x => x.NameAr == Key.NameAr && x.Id == Key.Id))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _Service.IsNameExist(x => x.NameEn == Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);


        }



        #endregion


    }
}