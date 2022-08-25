using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs;
using SchoolApi.Application.ServiceStudent;

namespace SchoolApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            return Ok(await _studentService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsyncss(int id)
        {
            return Ok(await _studentService.Get(id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudentAsync([FromBody] StudentDto studentDto)
        {
            return Created("", await _studentService.AddStudentAsync(studentDto));
        }
        [HttpPatch]
        public async Task UpdateStudentAsync([FromBody] StudentDto studentDto)
        {
            await _studentService.onSaveOrUpdate(studentDto);   
        }
        [HttpDelete("{id}")]
        public async Task DeleteStudentAsync(int id)
        {
           await _studentService.Delete(id);            
        }
    }
}
