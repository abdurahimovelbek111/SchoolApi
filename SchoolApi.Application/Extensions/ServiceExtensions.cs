using Microsoft.Extensions.DependencyInjection;
using SchoolApi.Application.Profiles;
using SchoolApi.Application.ServiceGroup;
using SchoolApi.Application.ServiceStudent;
using SchoolApi.Application.ServiceTeacher;

namespace SchoolApi.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingInitializer));
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService,TeacherService>();
            services.AddTransient<IGroupService, GroupService>();
        }
    }
}
