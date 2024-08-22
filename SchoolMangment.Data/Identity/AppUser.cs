using Microsoft.AspNetCore.Identity;

namespace SchoolMangment.Data.Identity
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
