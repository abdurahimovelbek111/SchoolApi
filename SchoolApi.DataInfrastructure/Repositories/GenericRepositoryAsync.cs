using Microsoft.EntityFrameworkCore;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.DataInfrastructure.Interfaces;

namespace SchoolApi.DataInfrastructure.Repositories
{
    public class GenericRepositoryAsync<T>: IGenericRepositoryAsync<T>
        where T:class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetPageListAsync(int pageNumbers, int pageSize)
        {
            return await _dbContext.Set<T>()
                 .Skip((pageNumbers - 1) * pageSize)
                 .Take(pageSize)
                 .AsNoTracking()
                 .ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
