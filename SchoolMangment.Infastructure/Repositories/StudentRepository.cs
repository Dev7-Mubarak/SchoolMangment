using Microsoft.EntityFrameworkCore;
using SchoolMangment.Data.Entities;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.BaseRepositories;
using SchoolMangment.Infastructure.Data;

namespace SchoolMangment.Infastructure.Repositories
{
    // pin
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _studentRepository;
        #endregion

        #region Constrctors
        public StudentRepository(ApplicationDbContext context)
            : base(context)
        {
            _studentRepository = context.Set<Student>();
        }
        #endregion

        #region Handel Funcations
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository
                .Include(x => x.Department)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion
    }
}