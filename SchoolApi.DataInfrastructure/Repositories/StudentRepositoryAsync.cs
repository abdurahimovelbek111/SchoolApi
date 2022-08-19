using Microsoft.EntityFrameworkCore;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.Domain.Models;

namespace SchoolApi.DataInfrastructure.Repositories
{
    public class StudentRepositoryAsync:GenericRepositoryAsync<Student>
    {
        private readonly DbSet<Student> _students;
        public StudentRepositoryAsync(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }
    }
}
