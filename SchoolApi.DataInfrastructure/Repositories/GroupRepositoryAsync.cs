using Microsoft.EntityFrameworkCore;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.Domain.Models;

namespace SchoolApi.DataInfrastructure.Repositories
{
    public class GroupRepositoryAsync:GenericRepositoryAsync<Group>
    {
        private readonly DbSet<Group> _groups;
        public GroupRepositoryAsync(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _groups = dbContext.Set<Group>();
        }
    }
}
