using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Features.Students.Queries.Models;
using SchoolMangment.Core.Resurces;
using SchoolMangment.Core.Resurses;

namespace SchoolMangment.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constractors
        public CreateStudentValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Actions
        public void ApplyValidationRule()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Empty")
                .MaximumLength(10).WithMessage("Name Max lenght is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("[propertyName] Must not be Empty")
                .NotNull().WithMessage("[propertyName] Must not be Empty")
                .MaximumLength(10).WithMessage("[propertyName] Max lenght is 10");
        }

        public void ApplyCustomValidationRule()
        {

        }
        #endregion
    }
}
