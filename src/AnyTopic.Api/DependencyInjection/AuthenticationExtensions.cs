using EnsureThat;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnyTopic.Api.DependencyInjection
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAzureB2CAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            EnsureArg.IsNotNull(services, nameof(services));

            const string JwtBearerOptionsSectionName = "AzureAdB2C";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => configuration.Bind(JwtBearerOptionsSectionName, options));

            return services;
        }
    }
}
