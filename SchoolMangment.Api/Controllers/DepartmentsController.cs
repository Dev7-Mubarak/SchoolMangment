using Microsoft.AspNetCore.Mvc;
using SchoolMangment.Api.Base;
using SchoolMangment.Core.Features.Departments.Query.Modles;
using SchoolMangment.Data.AppMetaData;

namespace SchoolMangment.Api.Controllers
{
    public class DepartmentsController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetById([FromQuery] GetDepartmentByIdQuery query)
        {
            return NewResult(await _mediator.Send(query));
        }
    }
}
