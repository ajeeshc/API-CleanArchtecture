using Microsoft.Extensions.DependencyInjection;
using SampleAPI.Application.Services.Authentication.Commands;
using SampleAPI.Application.Services.Authentication.Queries;

namespace SampleAPI.Application
{
    public static class StartUp
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationQueryServices, AuthenticationQueryServices>();
            services.AddScoped<IAuthenticationCommandServices, AuthenticationCommandServices>();
            return services;
        }
    }
}
