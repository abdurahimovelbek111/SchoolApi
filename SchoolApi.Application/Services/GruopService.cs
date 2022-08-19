using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class GruopService:IGroupService
    {
        private readonly IGenericRepositoryAsync<Group> _gruopRepository;

        public GruopService(IGenericRepositoryAsync<Group> gruopRepository)
        {
            _gruopRepository = gruopRepository;
        }
        public async Task<Group> AddGroupAsync(Group group)
        {
            return await _gruopRepository.AddAsync(group);
        }

        public async Task<IReadOnlyList<Group>> GetAllGroupAsync()
        {
            return await _gruopRepository.GetAllAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _gruopRepository.GetByIdAsync(id);
        }

        public async Task UpdateGroupAsync(Group group)
        {
            await _gruopRepository.UpdateAsync(group);
        }
        public async Task DeleteGroupAsync(Group group)
        {
            await _gruopRepository.DeleteAsync(group);
        }
    }
}
