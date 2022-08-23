using SchoolApi.Application.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Application.DTOs.Teacher
{
    public class TeacherDto:TeacherForCreationDto
    {
        public int Id { get; set; }       
    }
}
