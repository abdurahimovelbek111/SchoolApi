﻿using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs.Student;
using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServie _studentServie;

        public StudentController(IStudentServie studentServie)
        {
            _studentServie = studentServie;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            return Ok(await _studentServie.GetAllStudentAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsyncss(int id)
        {
            return Ok(await _studentServie.GetStudentByIdAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudentAsync([FromBody] StudentForCreationDto studentForCreationDto)
        {
            return Created("", await _studentServie.AddStudentAsync(studentForCreationDto));
        }
        [HttpPatch]
        public async Task UpdateStudentAsync([FromBody] StudentUpdate studentUpdate)
        {
            await _studentServie.UpdateStudentAsync(studentUpdate);   
        }
        [HttpDelete("{id}")]
        public async Task DeleteStudentAsync(int id)
        {
           await _studentServie.DeleteStudentAsync(id);            
        }
    }
}
