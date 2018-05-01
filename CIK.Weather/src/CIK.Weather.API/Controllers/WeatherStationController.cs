using System.Threading.Tasks;
using CIK.Weather.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIK.Weather.API.Controllers
{
    [Route("api/[controller]")]
    public class WeatherStationController : Controller
    {
        private readonly IWeatherStationRepository _repository;

        public WeatherStationController(IWeatherStationRepository weatherStationRepository)
        {
            _repository = weatherStationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stations = await _repository.GetWeatherStations();

            if (stations == null)
                return NotFound();

            return Ok(stations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var station = await _repository.GetWeatherStationById(id);

            if (station == null)
                return NotFound();

            return Ok(station);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteWeatherStation(id);
            _repository.Save();
        }
    }
}