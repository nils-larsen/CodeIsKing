using System.Threading.Tasks;

namespace CIK.Weather.API.Import
{
    public interface IWeatherImporter
    {
        Task<SmhiResponseObject> ImportStations();

        Task<string> ImportTemperatures(string stationId);
    }
}