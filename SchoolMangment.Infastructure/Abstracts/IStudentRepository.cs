using SchoolMangment.Data.Entities;
namespace SchoolMangment.Infastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<IEnumerable<Student>> GetAllAsync();
    }
}
