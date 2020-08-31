using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLLCore.Repository;
using DALContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PieShopWeb
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var test = configuration.GetSection("MyConfig:ApplicationName");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IPieRepository, MockPieRepository>();
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var connectionString = 
            services.AddDbContext <PieShopContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")), ServiceLifetime.Singleton);

            //this create an instance per each request
            //services.AddScoped

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //this is called the middleware component and basically it handdle the http requests
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseAuthentication();
                app.UseMvcWithDefaultRoute();
                //app.UseMvc(routes =>
                //{
                //    routes.MapRoute(
                //         name: "default",
                //         template: "{controller=Home}/{action =Index}/{id}"

                //        );
                //}
                //);   
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
