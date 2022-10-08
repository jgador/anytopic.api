//namespace AnyTopic.Api
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddSignalR();

//            services.AddControllers();

//            services.AddCors(o => o.AddDefaultPolicy(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (!env.IsDevelopment())
//            {
//                app.UseHttpsRedirection();
//            }

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
