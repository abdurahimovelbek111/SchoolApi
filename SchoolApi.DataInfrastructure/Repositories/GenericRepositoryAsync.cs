using Microsoft.EntityFrameworkCore;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Entity;

namespace SchoolApi.DataInfrastructure.Repositories
{
    public class GenericRepositoryAsync<T>: IGenericRepositoryAsync<T>
        where T: BaseEntity
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

        public Task<int> AddRangeAsync(IEnumerable<T> entitys)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            entity.Active = false;
            entity.ModifDate = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;
            return (await _dbContext.SaveChangesAsync())>0?true:false;
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

        public virtual async Task<bool> UpdateAsync(T entity)
        {           
           _dbContext.Entry(entity).State = EntityState.Modified;
           return  await _dbContext.SaveChangesAsync()>0?true:false;
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<T> entitys)
        {
            throw new NotImplementedException();
        }
    }
}
