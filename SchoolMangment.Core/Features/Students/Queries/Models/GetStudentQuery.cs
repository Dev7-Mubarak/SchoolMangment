using MediatR;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Students.Queries.Responses;

namespace SchoolMangment.Core.Features.Students.Queries.Models
{
    public class GetStudentQuery : IRequest<Response<IEnumerable<GetStudentResponse>>>
    {
    }
}
