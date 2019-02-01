using Microsoft.Extensions.DependencyInjection;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Repository.Repositories;
using Utn.PWA.Services.Interfaces;
using Utn.PWA.Services.Services;

namespace Utn.PWA.Api.Middlewares
{
    public static class DependencyInyectionMiddleware
    {
        public static IServiceCollection AddDependencyInyection(this IServiceCollection services)
        {

            // Dependency Injection
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();

            services.AddTransient<IInternshipService, InternshipService>();
            services.AddTransient<IInternshipRepository, InternshipRepository>();

            services.AddTransient<ICareerService, CareerService>();
            services.AddTransient<ICareerRepository, CareerRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
