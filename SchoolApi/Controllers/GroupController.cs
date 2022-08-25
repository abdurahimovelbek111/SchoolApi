using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs;
using SchoolApi.Application.ServiceGroup;

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
            return Ok(await _groupService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupByIdAsyncss(int id)
        {
            return Ok(await _groupService.Get(id));
        }

        [HttpPost()]
        public async Task<IActionResult> AddStudentAsync([FromBody] GroupDto groupDto)
        {
            return Created("", await _groupService.AddGroupAsync(groupDto));
        }
        [HttpPatch]
        public async Task UpdateStudentAsync([FromBody] GroupDto groupDto)
        {
            await _groupService.onSaveOrUpdate(groupDto);
        }
        [HttpDelete("{id}")]
        public async Task DeleteStudentAsync(int id)
        {           
            await _groupService.Delete(id);
        }
    }
}
