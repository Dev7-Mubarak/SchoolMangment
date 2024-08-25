using MediatR;
using SchoolMangment.Core.Bases;

namespace SchoolMangment.Core.Features.Authentication.Command.Modles
{
    public class SignInCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
