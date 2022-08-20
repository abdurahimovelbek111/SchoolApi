using SchoolApi.Application.DTOs.Student;

namespace SchoolApi.Application.Interfaces
{
    public interface IStudentServie
    {
        Task<IReadOnlyList<StudentDto>> GetAllStudentAsync();

        Task<StudentDto> GetStudentByIdAsync(int id);

        Task<StudentDto> AddStudentAsync(StudentForCreationDto studentFotCreatioDto);
        Task UpdateStudentAsync(StudentForCreationDto studentForCreationDto);
        Task DeleteStudentAsync(StudentForCreationDto studentForCreationDto);
    }
}
