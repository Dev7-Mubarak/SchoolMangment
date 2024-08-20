using AutoMapper;
namespace SchoolMangment.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentMapping();
            GetStudentByIdMapping();
            CreateStudentCommandMapping();
            EditeStudentCommandMapping();
        }
    }
}
