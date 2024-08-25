using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolMangment.Data.Helpers;
using SchoolMangment.Data.Identity;
using SchoolMangment.Services.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolMangment.Services.Implementations
{
    public class AuthenicationService : IAuthenicationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenicationService(UserManager<AppUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        //public Task<string> GetJWTTokenAsync(AppUser user)
        //{
        //    var (jwtToken, accessToken) = await GenerateJWTToken(user);
        //    var refreshToken = GetRefreshToken(user.UserName);
        //    var userRefreshToken = new UserRefreshToken
        //    {
        //        AddedTime = DateTime.Now,
        //        ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
        //        IsUsed = true,
        //        IsRevoked = false,
        //        JwtId = jwtToken.Id,
        //        RefreshToken = refreshToken.TokenString,
        //        Token = accessToken,
        //        UserId = user.Id
        //    };

        //    var response = new JwtAuthResult();
        //    response.refreshToken = refreshToken;
        //    response.AccessToken = accessToken;
        //    return response;
        //}

        public async Task<string> GenerateJWTToken(AppUser user)
        {
            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }

        public async Task<List<Claim>> GetClaims(AppUser user)
        {
            //var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(nameof(UserClaimModel.Id), user.Id)
            };
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
            //var userClaims = await _userManager.GetClaimsAsync(user);
            //claims.AddRange(userClaims);
            return claims;
        }
    }
}
