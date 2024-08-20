using SchoolMangment.Core.Features.Students.Commands.Models;
using SchoolMangment.Data.Entities;

namespace SchoolMangment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditeStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>();
            //.ForMember(dest => dest.DepartmentId,
            //opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
