using SchoolApi.Domain.Entity;

namespace SchoolApi.DataInfrastructure.Interfaces
{
    public interface IGenericRepositoryAsync<T> 
        where T : BaseEntity
    {        
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPageListAsync(int pageNumbers, int pageSize);
        Task<T> AddAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entitys);
        Task<bool> UpdateAsync(T entity);
        Task<int> UpdateRangeAsync(IEnumerable<T> entitys);
        Task<bool> DeleteAsync(T entity);
    }
}
