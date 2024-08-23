using AutoMapper;

namespace SchoolMangment.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateUserCommandMapping();
            GetUserByIdQueryMapping();
            GetUserPagenationMapping();
        }
    }
}
