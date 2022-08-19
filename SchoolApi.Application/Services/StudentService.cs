using SchoolApi.Application.Interfaces;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.Domain.Models;

namespace SchoolApi.Application.Services
{
    public class StudentService:IStudentServie
    {
        private readonly IGenericRepositoryAsync<Student> _studentRepository;

        public StudentService(IGenericRepositoryAsync<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddAsync(student);
        }
        public async Task<IReadOnlyList<Student>> GetAllStudentAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }
        public async Task DeleteStudentAsync(Student student)
        {
            await _studentRepository.DeleteAsync(student);
        }
    }
}
