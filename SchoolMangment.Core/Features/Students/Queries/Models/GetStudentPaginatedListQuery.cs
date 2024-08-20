using MediatR;
using SchoolMangment.Core.Features.Students.Queries.Responses;
using SchoolMangment.Core.Wrappers;
using SchoolMangment.Data.Helpers;

namespace SchoolMangment.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery :
        IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
