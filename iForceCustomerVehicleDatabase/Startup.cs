using AutoMapper;
using iForceCustomerVehicleDatabase.Repository;
using iForceCustomerVehicleDatabase.Service;
using iForceCustomerVehicleDatabase.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using VueCliMiddleware;

namespace iForceCustomerVehicleDatabase
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

            services.AddDbContext<CustomerVehicleDatabaseDbContext>(options => options.UseSqlite("Data Source=iForceDemo.db"));

            services.AddTransient(typeof(ICustomerVehicleRepo), typeof(CustomerVehicleRepo));
            services.AddTransient(typeof(ICustomerVehicleService), typeof(CustomerVehicleService));

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });


            // Swagger for openapi generating
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "iForce Customer Vehicle Database API",
                    Version = "0.1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic" }
                        }, new List<string>()
                    }
                });
            });

            // Configure automapping for ease!
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Automapping());
            });
            services.AddSingleton<IMapper>(sp => config.CreateMapper());



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                });
            }

            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "ClientApp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });
        }
    }
}
