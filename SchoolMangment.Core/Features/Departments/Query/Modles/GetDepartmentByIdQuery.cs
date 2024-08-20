using MediatR;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Departments.Query.Responses;

namespace SchoolMangment.Core.Features.Departments.Query.Modles
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }
}
