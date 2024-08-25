using SchoolMangment.Data.Identity;

namespace SchoolMangment.Services.Abstracts
{
    public interface IAuthenicationService
    {
        //public Task<string> GetJWTTokenAsync(AppUser user);
        public Task<string> GenerateJWTToken(AppUser user);
    }
}
