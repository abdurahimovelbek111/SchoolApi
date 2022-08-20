using AutoMapper;
using SchoolApi.Application.DTOs.Group;
using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class GruopService:IGroupService
    {
        private readonly IGenericRepositoryAsync<Group> _gruopRepository;
        private readonly IMapper _mapper;

        public GruopService(IGenericRepositoryAsync<Group> gruopRepository , IMapper mapper)
        {
            _gruopRepository = gruopRepository;
            _mapper = mapper;
        }
        public async Task<GroupDto> AddGroupAsync(GroupForCreationDto groupForCreationDto)
        {
            var group=_mapper.Map<Group>(groupForCreationDto);
            return _mapper.Map<GroupDto>(await _gruopRepository.AddAsync(group));
        }

        public async Task<IReadOnlyList<GroupDto>> GetAllGroupAsync()
        {
            return _mapper.Map<IReadOnlyList<GroupDto>>(await _gruopRepository.GetAllAsync());
        }

        public async Task<GroupDto> GetGroupByIdAsync(int id)
        {
            return _mapper.Map<GroupDto>(await _gruopRepository.GetByIdAsync(id));
        }

        public async Task UpdateGroupAsync(GroupForCreationDto groupForCreationDto)
        {
            var group = _mapper.Map<Group>(groupForCreationDto);
            await _gruopRepository.UpdateAsync(group);
        }
        public async Task DeleteGroupAsync(GroupForCreationDto groupForCreationDto)
        {
            var group = _mapper.Map<Group>(groupForCreationDto);
            await _gruopRepository.DeleteAsync(group);
        }
    }
}
