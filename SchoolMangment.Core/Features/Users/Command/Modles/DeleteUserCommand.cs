using MediatR;
using SchoolMangment.Core.Bases;

namespace SchoolMangment.Core.Features.Users.Command.Modles
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
