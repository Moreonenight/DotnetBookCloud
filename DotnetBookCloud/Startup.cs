using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetBookCloud", Version = "v1" });
            });
            string connectionString = Configuration.GetConnectionString("MySql");
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 34));
            services.AddDbContext<BookCloudDBContext>(
                dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
            var section = Configuration.GetSection("Redis:Default");
            string _connectionString = section.GetSection("Connection").Value;
            string _instanceName = section.GetSection("InstanceName").Value;
            int _defaultDB = int.Parse(section.GetSection("DefaultDB").Value ?? "0"); 
            services.AddSingleton(new Services.RedisService(_connectionString, _instanceName, _defaultDB));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetBookCloud v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
