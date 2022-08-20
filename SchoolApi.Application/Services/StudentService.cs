using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolApi.Application.DTOs.Student;
using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class StudentService:IStudentServie
    {
        private readonly ILogger _logger;   
        private readonly IGenericRepositoryAsync<Student> _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepositoryAsync<Student> studentRepository,
            IMapper mapper, ILogger<StudentService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _studentRepository = studentRepository;
        }
        /// <summary>
        /// Add or update DTO from DB
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns>Response: DTO model </returns>
        public async Task<StudentDto> AddStudentAsync(StudentForCreationDto studentForCreationDto)
        {
            #region DTO
            /* // this DTO model map entity
           var student = _mapper.Map<Student>(studentDto);
           // if Id==0 Add from DB else Update entity
           if (student.Id == 0)
           {
               await _studentRepository.AddAsync(student);
           }
           else
           {
               await _studentRepository.UpdateAsync(student);
           }
           return _mapper.Map<StudentDto>(student);*/
            #endregion

            var student = _mapper.Map<Student>(studentForCreationDto);

            return _mapper.Map<StudentDto>(await _studentRepository.AddAsync(student));

        }
        public async Task<IReadOnlyList<StudentDto>> GetAllStudentAsync()
        {
            return _mapper.Map<IReadOnlyList<StudentDto>>(await _studentRepository.GetAllAsync());
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            return _mapper.Map<StudentDto>(await _studentRepository.GetByIdAsync(id));
        }

        public async Task UpdateStudentAsync(StudentForCreationDto studentForCreationDto)
        {
            var student=_mapper.Map<Student>(studentForCreationDto);
            await _studentRepository.UpdateAsync(student);
        }
        public async Task DeleteStudentAsync(StudentForCreationDto studentForCreationDto)
        {
            var student = _mapper.Map<Student>(studentForCreationDto);
            await _studentRepository.DeleteAsync(student);
        }
    }
}
