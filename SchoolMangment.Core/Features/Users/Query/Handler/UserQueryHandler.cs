using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Users.Query.Modles;
using SchoolMangment.Core.Features.Users.Query.Responses;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Core.Wrappers;
using SchoolMangment.Data.Identity;

namespace SchoolMangment.Core.Features.Users.Query.Handler
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>,
        IRequestHandler<GetUserPagenationQuery, PaginatedResult<GetUserPagenationResponse>>
    {
        #region Fildes
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        #endregion
        #region Constrcuters
        public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<AppUser> userManager, IMapper mapper)
        : base(stringLocalizer)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion
        #region Funcations
        public async Task<PaginatedResult<GetUserPagenationResponse>> Handle(GetUserPagenationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users;

            var pagnatedList = await _mapper
                .ProjectTo<GetUserPagenationResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return pagnatedList;
        }
        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // Check if the user Exist
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                return NotFound<GetUserByIdResponse>();

            //map user
            var userMapping = _mapper.Map<GetUserByIdResponse>(user);

            return Success(userMapping);
        }
        #endregion
    }
}
