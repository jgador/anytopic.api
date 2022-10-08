//using AnyTopic.Api;
//using AnyTopic.Api.Hosting;

//namespace AnyTopic.Host.Web
//{
//    public class AspNetCoreApplicationHost : AnyTopicApiHost
//    {
//        protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
//        {
//            services.AddSignalR();

//            services.AddControllers();

//            services.AddCors(o => o.AddDefaultPolicy(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
//        }

//        protected override void Configure(WebHostBuilderContext context, IApplicationBuilder app)
//        {
//            app.UseRouting();

//            app.UseCors();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();

//                endpoints.MapHub<ChatHub>("/chatHub");
//            });
//        }
//    }
//}
