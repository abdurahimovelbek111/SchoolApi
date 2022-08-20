using AutoMapper;
using SchoolApi.Application.DTOs.Group;
using SchoolApi.Application.DTOs.Student;
using SchoolApi.Application.DTOs.Teacher;
using SchoolApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Application.Profiles
{
    public class MappingInitializer:Profile
    {
        public MappingInitializer()
        {
          /* StudentDto->Student ga
             Student->StudentDto ga  */
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<StudentForCreationDto, Student>().ReverseMap();

            /* TeacherDto->Teacher ga
            Teacher->TeacherDto ga */
            CreateMap<TeacherDto, Teacher>().ReverseMap();
            CreateMap<TeacherForCreationDto, Teacher>().ReverseMap();
            /* GroupDto->Group ga
            Group->GroupDto ga */
            CreateMap<GroupDto, Group>().ReverseMap();
            CreateMap<GroupForCreationDto, Group>().ReverseMap();
        }
    }
}
