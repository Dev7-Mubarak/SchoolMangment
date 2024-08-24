using Microsoft.AspNetCore.Mvc;
using SchoolMangment.Api.Base;
using SchoolMangment.Core.Features.Users.Command.Modles;
using SchoolMangment.Core.Features.Users.Query.Modles;
using SchoolMangment.Data.AppMetaData;

namespace SchoolMangment.Api.Controllers
{
    [ApiController]
    public class UsersController : AppControllerBase
    {

        [HttpGet(Router.UsersRouting.Paginted)]
        public async Task<IActionResult> Paginted([FromQuery] GetUserPagenationQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Router.UsersRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string Id)
        {
            return NewResult(await _mediator.Send(new GetUserByIdQuery(Id)));
        }
        [HttpPost(Router.UsersRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPut(Router.UsersRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

    }
}
