using SchoolApi.Application.DTOs.Student;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Interfaces
{
    public interface IStudentServie
    {
        Task<IReadOnlyList<StudentDto>> GetAllStudentAsync();

        Task<StudentDto> GetStudentByIdAsync(int id);

        Task<StudentDto> AddStudentAsync(StudentForCreationDto studentFotCreatioDto);
        Task UpdateStudentAsync(StudentUpdate studentUpdate);
        Task DeleteStudentAsync(int id);
    }
}
