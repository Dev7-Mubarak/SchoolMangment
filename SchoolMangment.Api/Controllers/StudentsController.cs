using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolMangment.Api.Base;
using SchoolMangment.Core.Features.Students.Commands.Models;
using SchoolMangment.Core.Features.Students.Queries.Models;
using Router = SchoolMangment.Data.AppMetaData.Router;

namespace SchoolMangment.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class StudentsController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetAll()
        {
            return NewResult(await _mediator.Send(new GetStudentQuery()));
        }

        [HttpGet(Router.StudentRouting.Paginted)]
        public async Task<IActionResult> Paginted([FromQuery] GetStudentPaginatedListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            return NewResult(await _mediator.Send(new GetStudentByIdQuery(Id)));
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> Update([FromBody] EditStudentCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            return NewResult(await _mediator.Send(new DeleteStudentCommand(Id)));
        }

    }
}
