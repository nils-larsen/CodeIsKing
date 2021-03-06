﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIK.Weather.API.Data;
using CIK.Weather.Models;
using Microsoft.EntityFrameworkCore;

namespace CIK.Weather.API.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly WeatherContext _context;

        public TemperatureRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TemperatureInfo>> GetTemperaturesByStationId(string id)
        {
            return await _context.Temperature.Where(x => x.WeatherStation.Id == id).ToListAsync();
        }

        public async Task DeleteTemperatureInfoByStationId(string id)
        {
            var temperaturesOnStation = await _context.Temperature.Where(x => x.WeatherStation.Id == id).ToListAsync();
            _context.Temperature.RemoveRange(temperaturesOnStation);
        }
    }
}