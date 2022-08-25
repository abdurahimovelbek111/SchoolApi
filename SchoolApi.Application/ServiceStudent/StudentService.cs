using AutoMapper;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Enum;
using SchoolApi.Domain.Entity;
using SchoolApi.Domain.ModelView;
using SchoolApi.Application.DTOs;

namespace SchoolApi.Application.ServiceStudent
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepositoryAsync<Student> _repositoryAsync;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepositoryAsync<Student> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        /// <summary>
        ///StudentDto  add
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            return _mapper.Map<StudentDto>(await _repositoryAsync.AddAsync(student));
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
        public async Task<StudentDto> Get(int id)
        {
            var find = await _repositoryAsync.GetByIdAsync(id);
            if (find == null) return null;
            else
                return _mapper.Map<StudentDto>(find);
        }
        /// <summary>
        /// GetAll entity 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _repositoryAsync.GetAllAsync());
        }

        /// <summary>
        /// StudentDto on Save Update 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response> onSaveOrUpdate(StudentDto entity)
        {
            var student = _mapper.Map<Student>(entity);
            if (student == null) return new Response()
            {
                Message = "",
                Status = Status.NotAllowed,
                Label = ""
            };
            else
                _mapper.Map<Student>(await _repositoryAsync.UpdateAsync(student));
            return new Response()
            {
                Message = "Update database",
                Status = Status.Created,
                Label = ""
            };
        }
    }
}
