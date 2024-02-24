using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Assignment.Infrastructure;
using Assignment.Core;
using Microsoft.AspNetCore.Mvc;
using Assignment.Core.Security;
using Swashbuckle.AspNetCore.Filters;

namespace Assignment
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
            services.AddPersistence(Configuration);
            services.AddCore();
            services.AddMarketplaceAuthentication(Configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();
    //         services.AddCors(options =>
    //         {
    //             options.AddPolicy("AllowAngularDev",
    //               builder =>
    //         {
    //             builder.WithOrigins("http://localhost:4200")
    //                    .AllowAnyHeader()
    //                    .AllowAnyMethod();
    //         });
    // });

            // Register the Swagger generator, defining 1 or more Swagger documents
             services.AddSwaggerGen(options => {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the bearer scheme (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
 
            //Install the Swashbuckle.AspNetCore.Filters for Security requirements operation filters.
            options.OperationFilter<SecurityRequirementsOperationFilter>();
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
          
         
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aspire Assignment App API v1");
            });
       //  app.UseCors("AllowAngularDev");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(options=>{
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            }
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
    }
