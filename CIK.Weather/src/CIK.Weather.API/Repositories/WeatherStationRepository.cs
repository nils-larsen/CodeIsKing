using System.Collections.Generic;
using System.Linq;
using CIK.Weather.API.Data;
using CIK.Weather.Models;
using Microsoft.EntityFrameworkCore;

namespace CIK.Weather.API.Repositories
{
    public class WeatherStationRepository : IWeatherStationRepository
    {
        private readonly WeatherContext _context;

        public WeatherStationRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<WeatherStation> GetWeatherStations()
        {
            return _context.WeatherStation.ToList();
        }

        public WeatherStation GetWeatherStationById(string id)
        {
            return _context.WeatherStation.Find(id);
        }

        public void InsertWeatherStation(WeatherStation weatherStation)
        {
            _context.WeatherStation.Add(weatherStation);
        }

        public void UpdateWeatherStation(WeatherStation weatherStation)
        {
            _context.Entry(weatherStation).State = EntityState.Modified;
        }

        public void DeleteWeatherStation(string id)
        {
            var weatherStation = _context.WeatherStation.Find(id);
            _context.WeatherStation.Remove(weatherStation);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}