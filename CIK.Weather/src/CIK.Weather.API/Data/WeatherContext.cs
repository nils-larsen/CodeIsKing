using Microsoft.EntityFrameworkCore;
using CIK.Weather.Models;

namespace CIK.Weather.API.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherStation> WeatherStation { get; set; }
    }
}
