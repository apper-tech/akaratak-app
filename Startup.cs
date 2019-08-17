using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using akaratak_app.Data;
using akaratak_app.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace akaratak_app
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
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "App/dist";
            });
            /* Coneection To DbContext */
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ListingContext")));
            /*Interface Injection */
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            /*Auto Mapper Connection */
            services.AddAutoMapper(typeof(Startup));
            /*Cloudinary */
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            /*Cors */
            services.AddCors();
            /*MVC */
            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCors(
             options => options
             .WithOrigins("http://localhost:4200")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowAnyOrigin()
            );


            /*   app.UseSpa(spa =>
              {
                  spa.Options.SourcePath = "App";

                  if (env.IsDevelopment())
                  {
                      spa.UseAngularCliServer(npmScript: "start");
                  }
              }); */
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
