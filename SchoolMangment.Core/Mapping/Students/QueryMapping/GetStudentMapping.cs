using SchoolMangment.Core.Features.Students.Queries.Responses;
using SchoolMangment.Data.Entities;

namespace SchoolMangment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentMapping()
        {
            CreateMap<Student, GetStudentResponse>()
              .ForMember(dest => dest.DepartmentName,
              opt => opt.MapFrom(src => src.Department.DepartmentNameEn));
        }
    }
}
