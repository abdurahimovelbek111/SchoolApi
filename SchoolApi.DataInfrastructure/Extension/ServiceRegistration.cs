using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApi.DataInfrastructure.Context;
using SchoolApi.DataInfrastructure.Interfaces;
using SchoolApi.DataInfrastructure.Repositories;

namespace SchoolApi.DataInfrastructure.Extension
{
    public static class ServiceRegistration
    {
        public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(
                configuration.GetConnectionString("DefaultPostgreSqlConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    ));
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        }
    }
}
