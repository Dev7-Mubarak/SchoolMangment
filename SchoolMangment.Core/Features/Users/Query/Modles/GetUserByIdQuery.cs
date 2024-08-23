using MediatR;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Users.Query.Responses;

namespace SchoolMangment.Core.Features.Users.Query.Modles
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

    }
}
