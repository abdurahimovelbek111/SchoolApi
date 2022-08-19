using Microsoft.Extensions.DependencyInjection;
using SchoolApi.Application.Interfaces;
using SchoolApi.Application.Services;

namespace SchoolApi.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IStudentServie, StudentService>();
        }
    }
}
