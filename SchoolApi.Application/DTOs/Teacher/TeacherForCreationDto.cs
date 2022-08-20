﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Application.DTOs.Teacher
{
    public class TeacherForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddilName { get; set; }
        public DateTime Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Degree { get; set; }
    }
}