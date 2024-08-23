using MediatR;
using SchoolMangment.Core.Features.Users.Query.Responses;
using SchoolMangment.Core.Wrappers;

namespace SchoolMangment.Core.Features.Users.Query.Modles
{
    public class GetUserPagenationQuery : IRequest<PaginatedResult<GetUserPagenationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
