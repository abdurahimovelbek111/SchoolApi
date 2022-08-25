using SchoolApi.Application.DTOs;
using SchoolApi.Application.Interfaces;


namespace SchoolApi.Application.ServiceGroup
{
    public interface IGroupService:ICRUDService<GroupDto>
    {
        Task<GroupDto> AddGroupAsync(GroupDto groupDto);
    }
}
