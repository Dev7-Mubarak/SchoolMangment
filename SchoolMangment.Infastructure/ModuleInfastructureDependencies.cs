using Microsoft.Extensions.DependencyInjection;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.BaseRepositories;
using SchoolMangment.Infastructure.Repositories;

namespace SchoolMangment.Infastructure
{
    public static class ModuleInfastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
