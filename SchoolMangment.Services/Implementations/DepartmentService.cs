using Microsoft.EntityFrameworkCore;
using SchoolMangment.Data.Entities;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Services.Abstracts;

namespace SchoolMangment.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        #region Fildes
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Funcations
        public async Task<Department> GetDepartmentById(int id)
        {
            var departments = await _departmentRepository
                .GetTableAsNotTracked()
                .Include(x => x.DepartmentSubjects)
                .ThenInclude(x => x.Subject)
                .Include(x => x.Instructor)
                .Include(x => x.Instructors)
                .FirstOrDefaultAsync(x => x.Id == id);

            return departments;
        }
        #endregion

    }
}
