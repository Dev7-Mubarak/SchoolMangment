using SchoolMangment.Core.Features.Users.Query.Responses;
using SchoolMangment.Data.Identity;

namespace SchoolMangment.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIdQueryMapping()
        {
            CreateMap<AppUser, GetUserByIdResponse>();
        }
    }
}
