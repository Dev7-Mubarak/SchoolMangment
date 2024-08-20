using Microsoft.EntityFrameworkCore;
using SchoolMangment.Data.Entities;
using SchoolMangment.Data.Helpers;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Services.Abstracts;

namespace SchoolMangment.Services.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constrctors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Funcations

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public IQueryable<Student> GetAllQueryable()
        {
            return _studentRepository
                    .GetTableAsTracked()
                    .Include(x => x.Department)
                    .AsQueryable();
        }
        public IQueryable<Student> FiltterPaginatedQueryable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepository
                    .GetTableAsTracked()
                    .Include(x => x.Department)
                    .AsQueryable();

            if (search != null)
            {
                querable = querable.Where(x => x.NameEn.Contains(search));
            }

            querable = orderingEnum switch
            {
                StudentOrderingEnum.Id => querable.OrderBy(x => x.Id),
                StudentOrderingEnum.NameEn => querable.OrderBy(x => x.NameEn),
                StudentOrderingEnum.Address => querable.OrderBy(x => x.Address),
                StudentOrderingEnum.DepartmentName => querable.OrderBy(x => x.Department.DepartmentNameEn),
                _ => querable.OrderBy(x => x.Id)
            };
            return querable;
        }
        public async Task<Student> GetByIdAsync(int Id)
        {
            var student = await _studentRepository.GetByIdAsync(Id);
            return student;
        }

        public IQueryable<Student> GetStudentByDepartmentIdQueryable(int DepartmentId)
        {
            return _studentRepository
                    .GetTableAsTracked()
                    .Where(x => x.DepartmentId == DepartmentId)
                    .AsQueryable();
        }

        public Task<Student> GetByIdWithIncludeAsync(int Id)
        {
            //var student = await _studentRepository.GetByIdAsync(Id);
            var student = _studentRepository.GetTableAsNotTracked()
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == Id);

            return student;
        }


        public async Task<string> CreateAsync(Student student)
        {
            //check if the name is Exist or not
            var studentResult = await _studentRepository
                .GetTableAsNotTracked()
                .FirstOrDefaultAsync(x => x.NameEn == student.NameEn);

            if (studentResult != null)
                return "Exist";

            //Added Student 
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Succees";
        }
        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();

            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Succees";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Falied";
            }

        }


        #endregion
    }
}
