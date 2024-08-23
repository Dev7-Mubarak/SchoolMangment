namespace SchoolMangment.Core.Features.Users.Query.Responses
{
    public class GetUserByIdResponse
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
