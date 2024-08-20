using SchoolMangment.Core.Features.Students.Queries.Responses;
using SchoolMangment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
              .ForMember(dest => dest.DepartmentName,
              opt => opt.MapFrom(src => src.Department.DepartmentNameEn));
        }
    }
}
