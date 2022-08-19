using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Interfaces
{
    public interface ITeacherServise
    {
        Task<IReadOnlyList<Teacher>> GetAllTeacherAsync();

        Task<Teacher> GetTeacherByIdAsync(int id);

        Task<Teacher> AddTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Teacher teacher);
    }
}
