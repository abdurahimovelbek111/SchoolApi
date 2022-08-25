using AutoMapper;
using SchoolApi.Application.DTOs;
using SchoolApi.Domain.Entity;

namespace SchoolApi.Application.Profiles
{
    public class MappingInitializer:Profile
    {        
        public MappingInitializer()
        {
            CreateMap<GroupDto, Group>().ReverseMap();
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<TeacherDto, Teacher>().ReverseMap();
            CreateMap<GroupTeacher, GroupTeacherDto>().ReverseMap();
        }
    }
}
