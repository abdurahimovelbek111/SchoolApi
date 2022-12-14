using AutoMapper;
using SchoolApi.Application.DTOs;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Enum;
using SchoolApi.Domain.Entity;
using SchoolApi.Domain.ModelView;

namespace SchoolApi.Application.ServiceTeacher
{
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepositoryAsync<Teacher> _repositoryAsync;
        private readonly IMapper _mapper;

        public TeacherService(IGenericRepositoryAsync<Teacher> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
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
        public async Task<TeacherDto> Get(int id)
        {
            var find = await _repositoryAsync.GetByIdAsync(id);
            if (find == null) return null;
            else
                return _mapper.Map<TeacherDto>(find);
        }
        /// <summary>
        /// GetAll entity 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<TeacherDto>>(await _repositoryAsync.GetAllAsync());
        }
        /// <summary>
        /// TeacherDto on Save Update  and Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response> onSaveOrUpdate(TeacherDto entity, UserProfile user)
        {
            var teacher = _mapper.Map<Teacher>(entity);
            if (teacher.Id == 0)
            {
                // Add
                return (await _repositoryAsync.AddAsync(teacher)).Id > 0
                    ? new Response() { Message = "Add", Status = Status.Ok  }
                    : new Response() { Message = "Error", Status = Status.BadRequest };
            }
            else
            {
                var findDb = await _repositoryAsync.GetByIdAsync(teacher.Id);
                if (findDb == null) return new Response() { Message = "Id bo'yicha DB ma'lumot yo'q", Status = Status.NotAllowed };
                else
                {
                    teacher.UpdateEntity(user, findDb.CreateBy, findDb.CreateDate);

                    return (await _repositoryAsync.UpdateAsync(teacher))
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
