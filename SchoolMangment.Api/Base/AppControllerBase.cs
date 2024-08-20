using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolMangment.Core.Bases;
using System.Net;

namespace SchoolMangment.Api.Base
{
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        // check the error
        //protected readonly IMediator _mediator;
        //public AppControllerBase(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

        public ObjectResult NewResult<T>(Response<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(response),
                HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
                _ => new BadRequestObjectResult(response),
            };
        }

    }
}
