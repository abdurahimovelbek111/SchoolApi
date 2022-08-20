using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs.Teacher;
using SchoolApi.Application.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherServise _teacherServie;

        public TeacherController(ITeacherServise teacherServie)
        {
            _teacherServie = teacherServie;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            return Ok(await _teacherServie.GetAllTeacherAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherByIdAsyncss(int id)
        {
            return Ok(await _teacherServie.GetTeacherByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherForCreationDto teacherForCreationDto)
        {
            return Created("", await _teacherServie.AddTeacherAsync(teacherForCreationDto));
        }
        [HttpPatch]
        public async Task UpdateTeacherAsync([FromBody] TeacherForCreationDto teacherForCreationDto)
        {
            await _teacherServie.UpdateTeacherAsync(teacherForCreationDto);
        }
        [HttpDelete("{id}")]
        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await _teacherServie.GetTeacherByIdAsync(id);
            await _teacherServie.DeleteTeacherAsync(teacher);
        }
    }
}
