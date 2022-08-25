using SchoolApi.Domain.ModelView;

namespace SchoolApi.Application.Interfaces
{
    public interface ICRUDService<T>
    {        
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<Response> Delete(int id);
        Task<Response> onSaveOrUpdate(T entity);
    }
}
