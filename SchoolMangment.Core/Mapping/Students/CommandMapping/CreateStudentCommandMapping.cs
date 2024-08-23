using SchoolMangment.Core.Features.Students.Queries.Models;
using SchoolMangment.Data.Entities;

namespace SchoolMangment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void CreateStudentCommandMapping()
        {
            CreateMap<CreateStudentCommand, Student>();
        }
    }
}
