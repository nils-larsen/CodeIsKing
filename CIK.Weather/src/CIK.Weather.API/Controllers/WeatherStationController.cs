using Microsoft.AspNetCore.Mvc;
using CIK.Weather.Models;
using System;

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
        public IActionResult Get()
        {
            var stations = _repository.GetWeatherStations();

            if (stations == null)
                return NotFound();

            return Ok(stations);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var station = _repository.GetWeatherStationById(id);

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
