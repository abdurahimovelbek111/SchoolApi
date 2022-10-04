using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Application.DTOs;
using SchoolApi.Application.ServiceGroup;
using SchoolApi.Domain.ModelView;

namespace SchoolApi.Controllers
{
    /// <summary>
    /// This controller sad
    /// </summary>
    public class GroupController : BaseController
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
            => Ok(await _groupService.Get(id));

        [HttpPost()]
        public async Task<IActionResult> AddGroupAsync([FromBody] GroupDto groupDto)
        {
            return Created("", await _groupService.onSaveOrUpdate(groupDto, CurrentUser));
        }
        [HttpPatch]
        public async Task UpdateGroupAsync([FromBody] GroupDto groupDto)
        {
            await _groupService.onSaveOrUpdate(groupDto, CurrentUser);
        }
        [HttpDelete("{id}")]
        public async Task DeleteGroupAsync(int id)
        {           
            await _groupService.Delete(id, CurrentUser);
        }
    }
}
