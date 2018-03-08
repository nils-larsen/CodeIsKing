using CIK.Weather.API.Data;
using CIK.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CIK.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportTemperatureController : ControllerBase
    {
        private readonly WeatherContext _db;
        private readonly IWeatherImporter _importer;

        public ImportTemperatureController(WeatherContext db, IWeatherImporter importer)
        {
            _db = db;
            _importer = importer;
        }

        [Route("{stationId}/temperature")]
        [HttpPost]
        public async Task<IActionResult> Post(string stationId)
        {
            var station = await _db.WeatherStation.FindAsync(stationId);

            if (station == null)
                return BadRequest($"No station found with id: {stationId}");

            var response = await _importer.ImportTemperatures(stationId);

            var readings = response.Split('\n')
                                   .Skip(10)
                                   .Where(line => line.Length > 0)
                                   .Select(line =>
                                   {
                                       var row = line.Split(';');

                                       var date = row[0];
                                       var time = row[1];
                                       var temperature = row[2];

                                       var couldParse = DateTime.TryParse(date + " " + time, out var dateTime);
                                       var temperatureValue = double.Parse(temperature.Replace('.', ','));

                                       return new TemperatureInfo
                                       {
                                           WeatherStation = station,
                                           Date = dateTime,
                                           Temperature = temperatureValue
                                       };
                                   }).ToList();

            await _db.Temperature.AddRangeAsync(readings.Where(x => x != null));
            await _db.SaveChangesAsync();

            return Created("Temperature import completed!", "tjena tjena");
        }
    }
}