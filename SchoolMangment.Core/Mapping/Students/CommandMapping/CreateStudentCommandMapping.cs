using SchoolMangment.Core.Features.Students.Queries.Models;
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
        public void CreateStudentCommandMapping()
        {
            CreateMap<CreateStudentCommand, Student>();
              //.ForMember(dest => dest.DepartmentId,
              //opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
