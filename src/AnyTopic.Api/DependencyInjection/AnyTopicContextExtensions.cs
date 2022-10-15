using AnyTopic.Data.Configuration;
using AnyTopic.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnyTopic.Api.DependencyInjection
{
    public static class AnyTopicContextExtensions
    {
        public static IServiceCollection AddSqlServerStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AnyTopicContextOptions>(configuration.GetSection(AnyTopicContextOptions.SectionName));
            services.AddSingleton<IDbContextFactory<AnyTopicContext>, AnyTopicContextFactory>();

            return services;
        }
    }
}
