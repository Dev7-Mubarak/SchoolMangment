using MediatR;
using SchoolMangment.Core.Bases;

namespace SchoolMangment.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
