using MediatR;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Students.Queries.Responses;

namespace SchoolMangment.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
