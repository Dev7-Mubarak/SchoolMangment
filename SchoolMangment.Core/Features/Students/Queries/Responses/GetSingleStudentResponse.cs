using MediatR;
using SchoolMangment.Core.Bases;

namespace SchoolMangment.Core.Features.Students.Queries.Responses
{
    public class GetSingleStudentResponse : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
