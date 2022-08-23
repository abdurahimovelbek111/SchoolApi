using SchoolApi.Application.DTOs.Teacher;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Interfaces
{
    public interface ITeacherServise
    {
        Task<IReadOnlyList<TeacherDto>> GetAllTeacherAsync();

        Task<TeacherDto> GetTeacherByIdAsync(int id);

        Task<TeacherDto> AddTeacherAsync(TeacherForCreationDto teacherForCreationDto);
        Task UpdateTeacherAsync(TeacherUpdate teacherUpdate);
        Task DeleteTeacherAsync(int id);
    }
}
