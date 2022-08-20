using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs.Group;
using SchoolApi.Application.Interfaces;

namespace SchoolApi.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGroupsAsync()
        {
            return Ok(await _groupService.GetAllGroupAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupByIdAsyncss(int id)
        {
            return Ok(await _groupService.GetGroupByIdAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudentAsync([FromBody] GroupForCreationDto groupForCreationDto)
        {
            return Created("", await _groupService.AddGroupAsync(groupForCreationDto));
        }
        [HttpPatch]
        public async Task UpdateStudentAsync([FromBody] GroupForCreationDto groupForCreationDto)
        {
            await _groupService.UpdateGroupAsync(groupForCreationDto);
        }
        [HttpDelete("{id}")]
        public async Task DeleteStudentAsync(int id)
        {
            var student = await _groupService.GetGroupByIdAsync(id);
            await _groupService.DeleteGroupAsync(student);
        }
    }
}
