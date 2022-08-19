using Microsoft.EntityFrameworkCore;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.Domain.Models;

namespace SchoolApi.DataInfrastructure.Repositories
{
    public class TeacherRepositoryAsync:GenericRepositoryAsync<Teacher>
    {
        private readonly DbSet<Teacher> _teachers;
        public TeacherRepositoryAsync(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _teachers = dbContext.Set<Teacher>();
        }
    }
}
