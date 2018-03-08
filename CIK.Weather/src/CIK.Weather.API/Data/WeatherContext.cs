using CIK.Weather.Models;
using Microsoft.EntityFrameworkCore;

namespace CIK.Weather.API.Data
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherStation> WeatherStation { get; set; }
        public DbSet<TemperatureInfo> Temperature { get; set; }

        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TemperatureInfo>()
                .HasOne(x => x.WeatherStation);
        }
    }
}