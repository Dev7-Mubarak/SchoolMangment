using Microsoft.AspNetCore.Mvc;
using SchoolMangment.Api.Base;
using SchoolMangment.Core.Features.Users.Command.Modles;
using SchoolMangment.Data.AppMetaData;

namespace SchoolMangment.Api.Controllers
{
    [ApiController]
    public class UsersController : AppControllerBase
    {
        [HttpPost(Router.UsersRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
    }
}
