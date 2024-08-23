using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Users.Command.Modles;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Data.Identity;

namespace SchoolMangment.Core.Features.Users.Command.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<CreateUserCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<AppUser> userManager)
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // if Email is Exist
            var user = await _userManager.FindByEmailAsync(request.Email);

            // Email is Exist
            if (user != null)
                return BadRequest<string>("Email is already Exist");

            // if UserName is Exist
            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            // UserName is Exist

            if (userByUserName != null)
                return BadRequest<string>("User Name is already Exist");

            //Mapping
            var userMapping = _mapper.Map<AppUser>(request);

            //Create 
            var result = await _userManager.CreateAsync(userMapping, request.Password);

            if (!result.Succeeded)
                return BadRequest<string>(result.Errors.FirstOrDefault().Description);

            return Created("");

        }
    }
}
