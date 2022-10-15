using AnyTopic.Api.Logging;
using AnyTopic.Api.Security.Claims;
using EnsureThat;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AnyTopic.Api.Hosting
{
    internal class AnyTopicServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
    {
        private readonly ServiceProviderOptions _options;

        public AnyTopicServiceProviderFactory(ServiceProviderOptions options)
        {
            EnsureArg.IsNotNull(options, nameof(options));

            _options = options;
        }

        public IServiceCollection CreateBuilder(IServiceCollection services)
        {
            return services;
        }

        public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
        {
            EnsureArg.IsNotNull(containerBuilder, nameof(containerBuilder));

            var serviceProvider = containerBuilder.BuildServiceProvider(_options);

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var claimsProvider = serviceProvider.GetRequiredService<IClaimsPrincipalProvider>();

            AnyTopicLoggerFactory.Initialize(loggerFactory);

            ClaimsPrincipalProviderFactory.SetClaimsPrincipalProvider(claimsProvider);

            return serviceProvider;
        }
    }
}
