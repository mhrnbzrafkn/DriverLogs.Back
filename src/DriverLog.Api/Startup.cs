using DriverLog.Persistence.EF;
using DriverLog.Persistence.EF.DriverLogs;
using DriverLog.Persistence.EF.Drivers;
using DriverLog.Services.DriverLogs;
using DriverLog.Services.DriverLogs.Contracts;
using DriverLog.Services.Drivers;
using DriverLog.Services.Drivers.Contracts;
using DriverLog.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DriverLog.Api
{
    public class Startup
    {
        private string _ConnectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _ConnectionString = configuration
                .GetConnectionString("dbconnectionString");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigBussinessServices(services);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "SampleProject.Api", 
                    Version = "v1" 
                });
            });
        }

        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json", 
                        "v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigBussinessServices(IServiceCollection services)
        {
            services.AddScoped<EFDataContext>(
                   _ => new EFDataContext(_ConnectionString));

            services.AddScoped<DriverService, DriverAppService>();
            services.AddScoped<DriverRepository, EFDriverRepository>();

            services.AddScoped<DriverLogService, DriverLogAppService>();
            services.AddScoped<DriverLogRepository, EFDriverLogRepository>();

            services.AddTransient<UnitOfWork, EFUnitOfWork>();
        }
    }
}
