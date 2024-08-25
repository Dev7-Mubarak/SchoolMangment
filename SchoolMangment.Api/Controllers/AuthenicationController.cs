using Microsoft.AspNetCore.Mvc;
using SchoolMangment.Api.Base;
using SchoolMangment.Core.Features.Authentication.Command.Modles;
using SchoolMangment.Data.AppMetaData;

namespace SchoolMangment.Api.Controllers
{
    [ApiController]
    public class AuthenicationController : AppControllerBase
    {
        [HttpPost(Router.Authenication.Create)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
    }
}
