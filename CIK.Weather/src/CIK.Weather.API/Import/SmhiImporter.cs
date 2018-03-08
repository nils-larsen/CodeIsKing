using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CIK.Weather.API.Import
{
    public class SmhiImporter : IWeatherImporter
    {
        private readonly ExternalEndpoints _endpoints;

        public SmhiImporter(ExternalEndpoints endpoints)
        {
            _endpoints = endpoints;
        }

        public async Task<SmhiResponseObject> ImportStations()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(_endpoints.WeatherStations);
            var root = JsonConvert.DeserializeObject<SmhiResponseObject>(response);
            return root;
        }

        public async Task<string> ImportTemperatures(string stationId)
        {
            var url = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/{stationId}/period/corrected-archive/data.csv";

            //var url = string.Format(_endpoints.HistoricalTemperatures, stationId);

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            return response;
        }
    }
}