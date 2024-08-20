using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolMangment.Infastructure.Abstracts
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetTableAsNotTracked();
        IQueryable<T> GetTableAsTracked();
        //Task<List<T>> GetAllWithSpecification();
        Task<T> GetByIdAsync(int id);
        //Task<T> GetByIdWithSpecification();
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        Task SaveChangesAsync();
    }
}
