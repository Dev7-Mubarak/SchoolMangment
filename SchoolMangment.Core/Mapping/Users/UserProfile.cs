using AutoMapper;

namespace SchoolMangment.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateUserMapping();
            UpdateUserMapping();
            CreateUserCommandMapping();
            GetUserByIdQueryMapping();
            GetUserPagenationMapping();
        }
    }
}
