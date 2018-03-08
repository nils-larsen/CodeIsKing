using CIK.Weather.API.Data;
using CIK.Weather.API.Import;
using CIK.Weather.API.Repository;
using CIK.Weather.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDbContext<WeatherContext>(options =>
                                                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            var settings = new ExternalEndpoints();
            Configuration.Bind("ExternalEndpoints", settings);
            services.AddSingleton(settings);

            services.AddScoped<IWeatherImporter, SmhiImporter>();
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