using AnyTopic.Api.Hosting;
using AnyTopic.Api.Hubs;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AnyTopic.Host.Web
{
    public class AspNetCoreApplicationHost : AnyTopicApiHost
    {
        protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSignalR();

            services.AddControllers();

            services.AddCors(o => o.AddDefaultPolicy(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }

        protected override void Configure(WebHostBuilderContext context, IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
