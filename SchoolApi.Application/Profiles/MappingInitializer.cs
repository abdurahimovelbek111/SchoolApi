using AutoMapper;
using SchoolApi.Application.DTOs.Student;
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
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
        }
    }
}
