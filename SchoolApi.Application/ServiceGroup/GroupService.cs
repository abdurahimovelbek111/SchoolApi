using AutoMapper;
using SchoolApi.Application.DTOs;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Enum;
using SchoolApi.Domain.Entity;
using SchoolApi.Domain.ModelView;


namespace SchoolApi.Application.ServiceGroup
{
    public class GroupService : IGroupService
    {
        private readonly IGenericRepositoryAsync<Group> _repositoryAsync;
        private readonly IMapper _mapper;
        public GroupService(IGenericRepositoryAsync<Group> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync=repositoryAsync;
            _mapper=mapper;
        }
        /// <summary>
        /// GroupDto  add
        /// </summary>
        /// <param name="groupDto"></param>
        /// <returns></returns>
        public async Task<GroupDto> AddGroupAsync(GroupDto groupDto)
        {
           var group=_mapper.Map<Group>(groupDto);
            return _mapper.Map<GroupDto>(await  _repositoryAsync.AddAsync(group));
        }

        /// <summary>
        /// Delete enetity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            // find entity form DB
            var findDeleteEntity = await _repositoryAsync.GetByIdAsync(id);
            // cheched
            if (findDeleteEntity == null) return new Response()
            {
                Message = "No found entity by id",
                Status = Status.NotAllowed,
                Label = ""
            };
            else
            {
                // Is Update Db
                bool isUpdate = await _repositoryAsync.DeleteAsync(findDeleteEntity);
                if (isUpdate) return new Response()
                {
                    Message = "Success",
                    Status = Status.Gone,
                    Label = ""
                };
                else return new Response()
                {
                    Message = "not Delete ",
                    Status = Status.InternalServerError,
                    Label = ""
                };
            }
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GroupDto> Get(int id)
        {
            var find = await _repositoryAsync.GetByIdAsync(id);
            if (find == null) return null;
            else
                return _mapper.Map<GroupDto>(find);
        }
        /// <summary>
        /// GetAll entity 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _repositoryAsync.GetAllAsync());
        }
        /// <summary>
        /// GroupDto on Save Update 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response> onSaveOrUpdate(GroupDto entity)
        {
            var group = _mapper.Map<Group>(entity);
            if (group == null) return new Response()
            {
                Message = "",
                Status = Status.NotAllowed,
                Label = ""
            };
            else
                _mapper.Map<Group>(await _repositoryAsync.UpdateAsync(group));
            return new Response()
            {
                Message = "Update database",
                Status = Status.Created,
                Label = ""
            };
        }
    }
}
