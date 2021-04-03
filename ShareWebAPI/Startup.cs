using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShareNCareEntity;
using ShareNCareEntity.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static void CustomMapper(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
            await context.Response.WriteAsync(
                @"PostUser{'Username':''example','Password':'example'}
                    PutMessage{'Msg':'example'}
                    PutFriend{'FriendId':'56'}
                    PutFile{'FileName':'example','FilePath':'example'}
                    PatchUsersPassword{'Old':'example','Neu':'example'}
                ");
        });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShareWebAPI", Version = "v1" });
            });

            services.AddScoped<TheContext>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShareWebAPI v1"));
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async e =>
                    {
                        e.Response.StatusCode = 404;
                        await e.Response.WriteAsync("Stop breaking the application, please.");
                    });
                });
            }

            app.UseHttpsRedirection();

            //app.UseWelcomePage("/welcome");

            app.UseRouting();

            app.UseAuthorization();

            app.Map("/mapper", CustomMapper);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default", pattern: "secretroute", defaults: new{controller = "ShareCareUsers", action = "Get"});
            });
        }
    }
}