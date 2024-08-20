using SchoolMangment.Data.Entities;

namespace SchoolMangment.Services.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
