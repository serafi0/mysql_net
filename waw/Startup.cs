using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using waw.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using Newtonsoft.Json.Serialization;

//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

namespace waw
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //[Obsolete]
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(MvcOptions => MvcOptions.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).
              AddNewtonsoftJson(s => { s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); } );
            //services.AddRazorPages(); z
            var connectionString = Configuration["mysqlconnection:connectionString"];
            //         //services.AddDbContext<CommandContext>(o => o.UseMySQL(connectionString));
            //         services.AddDbContextPool<CommandContext>(ser

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 


            services.AddDbContext<CommandContext>(option => option.UseMySql(connectionString));


            services.AddSwaggerGen();

            //options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")
            //));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            //});
            app.UseMvc();
        }
    }
}
