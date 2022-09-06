using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleAPI.Application.Common.Interfaces;
using SampleAPI.Application.Common.Interfaces.Services;
using SampleAPI.Infrastructure.Authentication;
using SampleAPI.Infrastructure.Persistance.User;
using SampleAPI.Infrastructure.Services;

namespace SampleAPI.Infrastructure
{
    public static class StartUp
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.AddSingleton<IJWTTokenGenerator, JWTTockenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            // registring the configuration 
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));

            return services;
        }
    }
}
