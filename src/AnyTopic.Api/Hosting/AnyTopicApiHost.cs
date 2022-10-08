using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace AnyTopic.Api.Hosting
{
    public abstract class AnyTopicApiHost
    {
        public static Task RunAsync<THost>(params string[] args)
            where THost : AnyTopicApiHost, new()
        {
            var host = new THost();

            var hostBuilder = Host.CreateDefaultBuilder(args);

            var appHost = host.Build(hostBuilder);

            return appHost.RunAsync();
        }

        protected virtual IHost Build([NotNull] IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(Configure);
            });

            hostBuilder.ConfigureServices(ConfigureServices);

            return hostBuilder.Build();
        }

        protected abstract void ConfigureServices(HostBuilderContext context, IServiceCollection services);

        protected abstract void Configure(WebHostBuilderContext context, IApplicationBuilder app);
    }
}