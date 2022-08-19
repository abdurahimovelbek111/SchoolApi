using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Interfaces
{
    public interface IStudentServie
    {
        Task<IReadOnlyList<Student>> GetAllStudentAsync();

        Task<Student> GetStudentByIdAsync(int id);

        Task<Student> AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
