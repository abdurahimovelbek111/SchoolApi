
using SchoolApi.Application.DTOs;
using SchoolApi.Application.Interfaces;


namespace SchoolApi.Application.ServiceStudent
{
    public interface IStudentService:ICRUDService<StudentDto>
    {
        Task<StudentDto> AddStudentAsync(StudentDto studentDto);
    }
}
