using CasaHub.Application.Interfaces.Services;
using CasaHub.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CasaHub.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<IUserService, UserService>();

        return services;
    }
    }
}