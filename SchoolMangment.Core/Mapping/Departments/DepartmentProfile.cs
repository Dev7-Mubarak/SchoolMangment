using AutoMapper;

namespace SchoolMangment.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetStudentByIdMapping();
            //GetStudentMapping();
            //CreateStudentCommandMapping();
            //EditeStudentCommandMapping();
        }
    }
}
