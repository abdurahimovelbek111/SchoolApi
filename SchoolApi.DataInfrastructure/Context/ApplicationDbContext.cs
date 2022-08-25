using Microsoft.EntityFrameworkCore;
using SchoolApi.Domain.Entity;

namespace SchoolApi.DataInfrastructure.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupTeacher>().HasKey(sc => new { sc.GroupId, sc.TeacherId });
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }        
        public DbSet<GroupTeacher> GroupTeachers { get; set; }

    }
}
