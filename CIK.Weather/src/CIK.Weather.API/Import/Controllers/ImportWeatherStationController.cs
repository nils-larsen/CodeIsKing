using CIK.Weather.API.Data;
using CIK.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CIK.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportWeatherStationController : ControllerBase
    {
        private readonly WeatherContext _db;
        private readonly IWeatherImporter _stationImporter;

        public ImportWeatherStationController(WeatherContext db, IWeatherImporter weatherImporter)
        {
            _db = db;
            _stationImporter = weatherImporter;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var root = await _stationImporter.ImportStations();

            var weatherStations = root.station.Select(station => new WeatherStation
                {
                    Id = station.id.ToString(),
                    Name = station.name,
                    Altitude = station.height,
                    Latitude = station.latitude,
                    Longitude = station.longitude
                })
                .ToList();

            //_db.RemoveRange(weatherStations);
            //_db.SaveChanges();
            _db.AddRange(weatherStations);
            _db.SaveChanges();

            return Created("Import completed!", "tjenaaaa");
        }
    }
}