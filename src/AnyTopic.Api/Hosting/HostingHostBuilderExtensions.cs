using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnyTopic.Api.Hosting
{
    public static class HostingHostBuilderExtensions
    {
        public static IHostBuilder UseAnyTopicServiceProvider(this IHostBuilder hostBuilder, Action<HostBuilderContext, ServiceProviderOptions> configure)
        {
            return hostBuilder.UseServiceProviderFactory(context =>
            {
                var options = new ServiceProviderOptions();

                configure(context, options);

                return new AnyTopicServiceProviderFactory(options);
            });
        }
    }
}
