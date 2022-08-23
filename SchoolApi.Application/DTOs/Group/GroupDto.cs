using SchoolApi.Application.DTOs.Student;
using SchoolApi.Application.DTOs.Teacher;

namespace SchoolApi.Application.DTOs.Group
{
    public class GroupDto:GroupForCreationDto
    {
        public int Id { get; set; }
        public List<TeacherDto> TeacherDtos { get; set; }       
    }
}
