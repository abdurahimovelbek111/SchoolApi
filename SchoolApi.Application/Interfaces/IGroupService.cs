using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Interfaces
{
    public interface IGroupService
    {
        Task<IReadOnlyList<Group>> GetAllGroupAsync();

        Task<Group> GetGroupByIdAsync(int id);

        Task<Group> AddGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Group group);
    }
}
