using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace Azure_Demo_2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine();

            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<ITodoRepository, TodoRepository>();
            services.AddEntityFrameworkSqlite()
                    .AddDbContext<ToDoContext>();
        }

        public void ConfigureRoute(IRouteBuilder routeBuilder){
            routeBuilder.MapRoute("Default","{controller=Contact}/{action=Index}/{id?}");
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseFileServer();
            app.UseDeveloperExceptionPage();
            app.UseMvc(ConfigureRoute);
        }
    }
}
