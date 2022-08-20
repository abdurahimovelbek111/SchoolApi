using SchoolApi.Application.DTOs.Group;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Interfaces
{
    public interface IGroupService
    {
        Task<IReadOnlyList<GroupDto>> GetAllGroupAsync();

        Task<GroupDto> GetGroupByIdAsync(int id);

        Task<GroupDto> AddGroupAsync(GroupForCreationDto groupForCreationDto);
        Task UpdateGroupAsync(GroupForCreationDto groupForCreationDto);
        Task DeleteGroupAsync(GroupForCreationDto groupForCreationDto);
    }
}
