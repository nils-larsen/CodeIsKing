using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CIK.Weather.API.Settings;

namespace CIK.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportWeatherStationController : ControllerBase
    {
        private readonly IImporter _importer;
        private readonly IOptions<UrlSettings> _apiUrl;

        public ImportWeatherStationController(IImporter importer, IOptions<UrlSettings> apiUrl)
        {
            _importer = importer;
            _apiUrl = apiUrl;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var path = _apiUrl.Value.WeatherStationsUrl;

            var response = _importer.GetStream(path);
            var root = _importer.DeserializeStream(response);
            _importer.SaveObject(root);

            return Created("Import completed!", "tjenaaaa");
        }
    }
}
