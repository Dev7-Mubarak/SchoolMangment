using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Features.Users.Command.Modles;
using SchoolMangment.Core.Resurses;

namespace SchoolMangment.Core.Features.Users.Command.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constractors
        public CreateUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Actions
        public void ApplyValidationRule()
        {
            //RuleFor(x => x.FullName)
            //    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            //    .NotNull().WithMessage("Name Must not be Empty")
            //    .MaximumLength(100).WithMessage("Name Max lenght is 10");

            //RuleFor(x => x.Email)
            //    .NotEmpty().WithMessage("[propertyName] Must not be Empty")
            //    .NotNull().WithMessage("[propertyName] Must not be Empty")
            //    .MaximumLength(60).WithMessage("[propertyName] Max lenght is 10");

            //RuleFor(x => x.UserName)
            //.NotEmpty().WithMessage("[propertyName] Must not be Empty")
            //.NotNull().WithMessage("[propertyName] Must not be Empty")
            //.MaximumLength(15).WithMessage("[propertyName] Max lenght is 10");

            //RuleFor(x => x.Password)
            //    .NotEmpty().WithMessage("[propertyName] Must not be Empty")
            //    .NotNull().WithMessage("[propertyName] Must not be Empty")
            //    .MaximumLength(50).WithMessage("[propertyName] Max lenght is 10");

            //RuleFor(x => x.ConfirmPassword)
            //.NotEmpty().WithMessage("[propertyName] Must not be Empty")
            //.NotNull().WithMessage("[propertyName] Must not be Empty")
            //.MaximumLength(50).WithMessage("[propertyName] Max lenght is 10");

        }

        public void ApplyCustomValidationRule()
        {
            //RuleFor(x => x.DepartmentId)
            //.MustAsync(async (key, ConcelationToken) =>
            //await _departmentService.IsDepartmentExistById(key))
            //.WithMessage(_stringLocalizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
