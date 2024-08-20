using MediatR;
using SchoolMangment.Core.Bases;

namespace SchoolMangment.Core.Features.Students.Queries.Models
{
    public class CreateStudentCommand : IRequest<Response<string>>
    {
        public string NameEn { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
