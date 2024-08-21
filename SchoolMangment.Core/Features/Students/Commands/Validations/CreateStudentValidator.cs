using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Features.Students.Queries.Models;
using SchoolMangment.Core.Resurces;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Services.Abstracts;

namespace SchoolMangment.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constractors
        public CreateStudentValidator(IStringLocalizer<SharedResources> stringLocalizer, IStudentService studentService, IDepartmentService departmentService)
        {
            ApplyValidationRule();
            ApplyCustomValidationRule();
            _stringLocalizer = stringLocalizer;
            _studentService = studentService;
            _departmentService = departmentService;
        }
        #endregion

        #region Actions
        public void ApplyValidationRule()
        {
            //RuleFor(x => x.NameEn)
            //    .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            //    .NotNull().WithMessage("Name Must not be Empty")
            //    .MaximumLength(10).WithMessage("Name Max lenght is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("[propertyName] Must not be Empty")
                .NotNull().WithMessage("[propertyName] Must not be Empty")
                .MaximumLength(10).WithMessage("[propertyName] Max lenght is 10");

            RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("[propertyName] Must not be Empty")
            .NotNull().WithMessage("[propertyName] Must not be Empty");

        }

        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.DepartmentId)
            .MustAsync(async (key, ConcelationToken) =>
            await _departmentService.IsDepartmentExistById(key))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
