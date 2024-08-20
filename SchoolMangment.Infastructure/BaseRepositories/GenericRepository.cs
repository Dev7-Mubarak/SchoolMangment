using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.Data;

namespace SchoolMangment.Infastructure.BaseRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        #region Fileds
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        public IQueryable<T> GetTableAsTracked() => _context.Set<T>().AsQueryable();

        public IQueryable<T> GetTableAsNotTracked() => _context.Set<T>().AsNoTracking();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {

            //foreach (var entity in entities)
            //{
            //    _context.Entry(entity).State = EntityState.Deleted;
            //}
            //await SaveChangesAsync();

            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

        public void Commit() => _context.Database.CommitTransaction();

        public void RollBack() => _context.Database.RollbackTransaction();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        //public async Task<T> GetByIdWithSpecification(ISpecification<T> specs)
        //    => await ApplySpecs(specs)?.FirstOrDefaultAsync();


        //private IQueryable<T> ApplySpecs(ISpecification<T> specs)
        //  => SpecificationEvaluater<T>.GetQuery(_context.Set<T>(), specs);

        //public async Task<List<T>> GetAllWithSpecification(ISpecification<T> specs)
        //    => await ApplySpecs(specs).ToListAsync();

        #endregion
    }
}
