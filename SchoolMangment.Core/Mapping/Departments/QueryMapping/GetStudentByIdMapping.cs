using SchoolMangment.Core.Features.Departments.Query.Responses;
using SchoolMangment.Data.Entities;

namespace SchoolMangment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
              .ForMember(dest => dest.ManagerName,
              opt => opt.MapFrom(src => src.Instructor.NameEn))
              .ForMember(dest => dest.SubjectList,
              opt => opt.MapFrom(src => src.DepartmentSubjects))
              //.ForMember(dest => dest.StudentList,
              //opt => opt.MapFrom(src => src.Students))
              .ForMember(dest => dest.InstructorList,
              opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmetSubject, SubjectResponse>()
              .ForMember(dest => dest.Id,
              opt => opt.MapFrom(src => src.SubjectId))
              .ForMember(dest => dest.Name,
              opt => opt.MapFrom(src => src.Subject.SubjectNameEn));

            //CreateMap<Student, StudentResponse>()
            // .ForMember(dest => dest.Name,
            // opt => opt.MapFrom(src => src.NameEn));

            CreateMap<Instructor, InstructorResponse>()
             .ForMember(dest => dest.Name,
             opt => opt.MapFrom(src => src.NameEn));
        }
    }
}
