namespace SchoolMangment.Core.Features.Students.Queries.Responses
{
    public class GetStudentPaginatedListResponse
    {
        public GetStudentPaginatedListResponse(int id, string nameEn, string? address, string departmentName)
        {
            Id = id;
            NameEn = nameEn;
            Address = address;
            DepartmentName = departmentName;
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string? Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
