using SchoolMangment.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Core.Features.Students.Queries.Responses
{
    public class GetStudentResponse
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
