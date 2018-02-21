using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CIK.Weather.Models;
using CIK.Weather.API.Data;
using CIK.Weather.API.Import;
using CIK.Weather.API.Settings;
using CIK.Weather.API.Repository;

namespace CIK.Weather.API
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
            //services.AddDbContext<WeatherContext>(options =>
            //options.UseSqlserver(Configuration.GetConnectionString("AzureConnection")));

            services.AddDbContext<WeatherContext>(options =>
                                                  options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddScoped<IImporter, SmhiJsonImporter>();
            services.Configure<UrlSettings>(Configuration.GetSection("UrlSettings"));

            services.AddScoped<IWeatherStationRepository, WeatherStationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
