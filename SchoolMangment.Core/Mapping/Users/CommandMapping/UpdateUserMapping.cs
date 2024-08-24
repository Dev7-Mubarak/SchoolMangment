using SchoolMangment.Core.Features.Users.Command.Modles;
using SchoolMangment.Data.Identity;

namespace SchoolMangment.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, AppUser>();
        }
    }
}
