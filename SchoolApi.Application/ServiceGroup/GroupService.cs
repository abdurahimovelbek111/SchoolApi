using AutoMapper;
using SchoolApi.Application.DTOs;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Enum;
using SchoolApi.Domain.Entity;
using SchoolApi.Domain.ModelView;
using SchoolApi.DataInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
        /// Delete enetity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id, UserProfile user)
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
                findDeleteEntity.ModifDate = DateTime.Now;
                findDeleteEntity.ModifBy = user.Id;
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
        /// GroupDto on Save Update and Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response> onSaveOrUpdate(GroupDto entity, UserProfile user)
        {
            var group = _mapper.Map<Group>(entity);
            if (group.Id == 0)
            {
                // Add
                return (await _repositoryAsync.AddAsync(group)).Id > 0
                    ? new Response() { Message = "Add", Status = Status.Ok }
                    : new Response() { Message = "Error", Status = Status.BadRequest };
            }
            else
            {
                var findDb = await _repositoryAsync.GetByIdAsync(group.Id);
                if (findDb == null) return new Response() { Message = "Id bo'yicha DB ma'lumot yo'q", Status = Status.NotAllowed };
                else
                {
                    group.UpdateEntity(user, findDb.CreateBy, findDb.CreateDate);

                    return (await _repositoryAsync.UpdateAsync(group))
                        ? new Response()
                        {
                            Message = "Update bo'ldi",
                            Status = Status.Accepted
                        }
                        : new Response() { };
                }
            }
        }
    }
}
