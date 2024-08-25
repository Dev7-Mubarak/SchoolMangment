using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolMangment.Core.Bases;
using SchoolMangment.Core.Features.Authentication.Command.Modles;
using SchoolMangment.Core.Resurses;
using SchoolMangment.Data.Identity;
using SchoolMangment.Services.Abstracts;

namespace SchoolMangment.Core.Features.Authentication.Command.Handler
{
    public class AuthenticationHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> stringLocalizer;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthenicationService _authService;

        public AuthenticationHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthenicationService authService) : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            // Find user
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return NotFound<string>();

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                return BadRequest<string>();

            //Generate Token
            var token = await _authService.GenerateJWTToken(user);

            return Success(token);
        }

    }
}
