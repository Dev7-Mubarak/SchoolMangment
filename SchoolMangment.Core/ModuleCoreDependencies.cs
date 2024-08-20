using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolMangment.Core.Behaviors;
using SchoolMangment.Infastructure.Abstracts;
using SchoolMangment.Infastructure.Repositories;
using System.Reflection;

namespace SchoolMangment.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Mediatr Congigration 
            services.AddMediatR(options => options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // AutoMapper Congigration
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //validators 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
