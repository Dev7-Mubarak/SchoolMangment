using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Features.Authentication.Command.Modles;
using SchoolMangment.Core.Resurses;

namespace SchoolMangment.Core.Features.Authentication.Command.Validations
{
    public class SignInValidtore : AbstractValidator<SignInCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constractors
        public SignInValidtore(IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Actions
        public void ApplyValidationRule()
        {
            //RuleFor(x => x.UserName)
            //    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            //    .NotNull().WithMessage("Name Must not be Empty")
            //    .MaximumLength(10).WithMessage("Name Max lenght is 10");

            //RuleFor(x => x.Password)
            //    .NotEmpty().WithMessage("[propertyName] Must not be Empty")
            //    .NotNull().WithMessage("[propertyName] Must not be Empty")
            //    .MaximumLength(10).WithMessage("[propertyName] Max lenght is 10");

        }

        public void ApplyCustomValidationRule()
        {

        }
        #endregion
    }
}
