using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TDADomain.Data;
using TDADomain.DataAccess.Repo;
using TDADomain.DataAccess.RepoPatterns;
using TDAWorkOrderAPI.Services;
using TDAWorkOrderAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace TDAWorkOrderAPI
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
            services.AddControllers();

            //register DBContext class
            services.AddDbContext<TDAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //resgister swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TDAWorkOrder", Version = "v1" });
            });

            //register custom services for API
            services.AddScoped<DbContext, TDAContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISetUpServices, SetUpServices>();
            services.AddScoped<IWorkOrderServices, WorkOrderServices>();

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //enable middleware to serve generated swagger as JSON endpoint
            app.UseSwagger();

            //enable middleware to serve swagger UI
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : ".."; 
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "TDAWorkOrder");

            });
        }
    }
}
