using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CIK.Weather.Models;
using CIK.Weather.API.Data;

namespace CIK.Weather.API.Repository
{
    public class WeatherStationRepository : IWeatherStationRepository
    {
        private WeatherContext _context;

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
            WeatherStation weatherStation = _context.WeatherStation.Find(id);
            _context.WeatherStation.Remove(weatherStation);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
