using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolApi.Application.DTOs.Teacher;
using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class TeacherServise : ITeacherServise
    {
        private readonly IGenericRepositoryAsync<Teacher> _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeacherServise> _logger;

        public TeacherServise(IGenericRepositoryAsync<Teacher> teacherRepository,
            IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
          //  _logger = logger;
        }

        public async Task<TeacherDto> AddTeacherAsync(TeacherForCreationDto teacherForCreationDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherForCreationDto);
            return _mapper.Map<TeacherDto>(await _teacherRepository.AddAsync(teacher));
        }
        public async Task<IReadOnlyList<TeacherDto>> GetAllTeacherAsync()
        {
            return _mapper.Map<IReadOnlyList<TeacherDto>>(await _teacherRepository.GetAllAsync());
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {

            return _mapper.Map<TeacherDto>(await _teacherRepository.GetByIdAsync(id));
        }

        public async Task UpdateTeacherAsync(TeacherForCreationDto teacherForCreationDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherForCreationDto);
            await _teacherRepository.UpdateAsync(teacher);
        }
        public async Task DeleteTeacherAsync(TeacherForCreationDto teacherForCreationDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherForCreationDto);
            await _teacherRepository.DeleteAsync(teacher);
        }
    }
}
