using AutoMapper;
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
        private readonly ApplicationDbContext db;

        public TeacherServise(IGenericRepositoryAsync<Teacher> teacherRepository,
            IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;        
        }

        public async Task<TeacherDto> AddTeacherAsync(TeacherForCreationDto teacherForCreationDto)
        {
            #region DTO
           /* // this DTO model map entity
            var teacher = _mapper.Map<Teacher>(teacherForCreationDto);
            // if Id==0 Add from DB else Update entity
            if (teacher.Id == 3)
            {
                await _teacherRepository.AddAsync(teacher);
            }
            else
            {
                await _teacherRepository.UpdateAsync(teacher);
            }
            return _mapper.Map<TeacherDto>(teacher);*/
            #endregion
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
            var teacher=_mapper.Map<Teacher>(teacherForCreationDto);
               await _teacherRepository.UpdateAsync(teacher);                    
        }
        public async Task DeleteTeacherAsync(TeacherForCreationDto teacherForCreationDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherForCreationDto);
            await _teacherRepository.DeleteAsync(teacher);
        }
    }
}
