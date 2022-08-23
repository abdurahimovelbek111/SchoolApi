using AutoMapper;
using SchoolApi.Application.DTOs.Group;
using SchoolApi.Application.DTOs.Teacher;
using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class TeacherServise : ITeacherServise
    {
        private readonly IGenericRepositoryAsync<Teacher> _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public TeacherServise(IGenericRepositoryAsync<Teacher> teacherRepository,
            IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
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

        public async Task UpdateTeacherAsync(TeacherUpdate teacherUpdate)
        {
            var teacher = _mapper.Map<Teacher>(teacherUpdate);
            await _teacherRepository.UpdateAsync(teacher);
        }
        public async Task DeleteTeacherAsync(int id)
        {           
            await _teacherRepository.DeleteAsync(await _teacherRepository.GetByIdAsync(id));
        }
    }
}
