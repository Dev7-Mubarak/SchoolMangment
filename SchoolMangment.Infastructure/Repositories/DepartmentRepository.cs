using Microsoft.EntityFrameworkCore;
using SchoolMangment.Data.Entities;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.BaseRepositories;
using SchoolMangment.Infastructure.Data;

namespace SchoolMangment.Infastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments { get; set; }
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            departments = context.Set<Department>();
        }
        #endregion

        #region Funcations
        #endregion
    }
}
