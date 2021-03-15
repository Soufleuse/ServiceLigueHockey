using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLigueHockey.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ServiceLigueHockey
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string monAllowSpecificOrigine = "monAllowSpecificOrigine";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(name: monAllowSpecificOrigine,
                    builder => {
                        builder.WithOrigins("http://localhost:4900", "https://localhost:4900");
                    });
            });

            services.AddControllers();
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceLigueHockey", Version = "v1" });
            });*/

            var connection = Configuration.GetConnectionString("ServiceLigueHockeyContext");
            services.AddDbContext<ServiceLigueHockeyContext>(options =>
                    options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                /*app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceLigueHockey v1"));*/
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(monAllowSpecificOrigine);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
