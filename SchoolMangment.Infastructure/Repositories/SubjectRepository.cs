using Microsoft.EntityFrameworkCore;
using SchoolMangment.Data.Entities;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.BaseRepositories;
using SchoolMangment.Infastructure.Data;

namespace SchoolMangment.Infastructure.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subject> subjects { get; set; }
        #endregion

        #region Constructors
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            subjects = context.Set<Subject>();
        }
        #endregion

        #region Funcations
        #endregion
    }
}
