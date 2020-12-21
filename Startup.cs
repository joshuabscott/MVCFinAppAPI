using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCFinAppAPI.Data;
using MVCFinAppAPI.Utilities;

namespace MVCFinAppAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: register db context
            services.AddDbContext<ApiDbContext>(options =>
                options.UseNpgsql(DataHelper.GetConnectionString(Configuration)));
            services.AddControllers();

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo
               {
                   Version = "v1",
                   Title = "Smart Money API",
                   Description = "This service is open and available for general use. There is no authentication.",
                   Contact = new OpenApiContact
                   {
                       Name = "Josh Scott",
                       Email = "joshuabscott@gmail.com",
                       Url = new Uri("https://thejoshscott.com/")
                   }
               });
               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles(); //This should come before app.UseSwagger();
            //Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.) specifying the Swagger JSON endpoint
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Money");
               c.RoutePrefix = string.Empty;
               c.InjectStylesheet("/swagger-ui/custom.css");
               c.InjectJavascript("/swagger-ui/custom.js");
               c.DocumentTitle = "Smart Money";
           });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}