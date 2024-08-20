using SchoolMangment.Data.Entities;
using SchoolMangment.Data.Helpers;

namespace SchoolMangment.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAllAsync();
        public IQueryable<Student> GetAllQueryable();
        public Task<Student> GetByIdWithIncludeAsync(int Id);
        public Task<Student> GetByIdAsync(int Id);
        public IQueryable<Student> GetStudentByDepartmentIdQueryable(int DepartmentId);
        public Task<string> CreateAsync(Student student);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> FiltterPaginatedQueryable(StudentOrderingEnum orderingEnum, string search);

        //public Task<bool> IsNameExist(string name);
        //public Task<bool> IsNameExistExcludeSelf(string name);
    }
}
