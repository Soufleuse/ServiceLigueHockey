using IBM.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLigueHockey.Data;

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
                        builder.WithHeaders("Content-Type");
                        builder.WithMethods("POST","GET","PUT","OPTIONS");
                    });
            });
            /*services.AddCors(options => {
                options.AddPolicy(name: monAllowSpecificOrigine,
                    builder => {
                        builder
                        .WithOrigins("http://localhost:4900", "https://localhost:4900")
                        .WithHeaders("Content-Type")
                        .WithMethods("POST","GET","PUT","OPTIONS");
                    });
            });*/

            services.AddControllers();

            var connection = Configuration.GetConnectionString("ServiceLigueHockeyContext2");
            services.AddDbContext<ServiceLigueHockeyContext>(options =>
                    options.UseSqlServer(connection));
            /*var connection = Configuration.GetConnectionString("ServiceLigueHockeyContextDb2");
            services.AddDbContext<ServiceLigueHockeyContext>(options =>
                    options.UseDb2(connection, p => p.SetServerInfo(IBMDBServerType.LUW, IBMDBServerVersion.LUW_11_01_2020)));*/
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
            app.UseCors(monAllowSpecificOrigine);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
