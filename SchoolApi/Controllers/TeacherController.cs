using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs;
using SchoolApi.Application.ServiceTeacher;

namespace SchoolApi.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            return Ok(await _teacherService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherByIdAsyncss(int id)
        {
            return Ok(await _teacherService.Get(id));
        } 
        

        [HttpPost]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherDto teacherDto)
        {
            return Created("", await _teacherService.onSaveOrUpdate(teacherDto, CurrentUser));
        }
        [HttpPatch]        
        public async Task UpdateTeacherAsync([FromBody] TeacherDto teacherDto)
        {
            await _teacherService.onSaveOrUpdate(teacherDto, CurrentUser);
        }
        [HttpDelete("{id}")]
        public async Task DeleteTeacherAsync(int id)
        {         
            await _teacherService.Delete(id, CurrentUser);
        }
    }
}
