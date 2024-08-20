using Microsoft.EntityFrameworkCore;
using SchoolMangment.Data.Entities;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.BaseRepositories;
using SchoolMangment.Infastructure.Data;

namespace SchoolMangment.Infastructure.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        #region Fields
        private DbSet<Instructor> instructors { get; set; }
        #endregion

        #region Constructors
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            instructors = context.Set<Instructor>();
        }
        #endregion

        #region Funcations
        #endregion
    }
}
