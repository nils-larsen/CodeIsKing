using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIK.Weather.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIK.Weather.API.Controllers
{
    [Route("api/import/smhi/stations")]
    public class TemperatureController : Controller
    {
        private readonly ITemperatureRepository _repository;

        public TemperatureController(ITemperatureRepository repository)
        {
            _repository = repository;
        }
        

        [Route("{stationId}/temperature")]
        [HttpGet]
        public async Task<IActionResult> Get(string stationId)
        {
            var temperatures = await _repository.GetTemperaturesByStationId(stationId);

            return Ok(temperatures);
        }
    }

    
}