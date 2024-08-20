using FluentValidation;
using SchoolMangment.Core.Features.Students.Commands.Models;

namespace SchoolMangment.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        #endregion

        #region Constractors
        public EditStudentValidator()
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
        }
        #endregion

        #region Actions
        public void ApplyValidationRule()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("Name Must not be Empty")
                .NotNull().WithMessage("Name Must not be Empty")
                .MaximumLength(30).WithMessage("Name Max lenght is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("[propertyName] Must not be Empty")
                .NotNull().WithMessage("[propertyName] Must not be Empty")
                .MaximumLength(50).WithMessage("[propertyName] Max lenght is 10");
        }

        public void ApplyCustomValidationRule()
        {
            // check for Name is exist
        }
        #endregion
    }
}
