using Microsoft.Extensions.DependencyInjection;
using SchoolMangment.Services.Abstracts;
using SchoolMangment.Services.Implementations;

namespace SchoolMangment.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
