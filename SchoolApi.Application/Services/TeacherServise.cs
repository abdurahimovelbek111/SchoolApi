using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class TeacherServise:ITeacherServise
    {
        private readonly IGenericRepositoryAsync<Teacher> _teacherRepository;

        public TeacherServise(IGenericRepositoryAsync<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            return await _teacherRepository.AddAsync(teacher);
        }
        public async Task<IReadOnlyList<Teacher>> GetAllTeacherAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            await _teacherRepository.UpdateAsync(teacher);
        }
        public async Task DeleteTeacherAsync(Teacher teacher)
        {
            await _teacherRepository.DeleteAsync(teacher);
        }
    }
}
