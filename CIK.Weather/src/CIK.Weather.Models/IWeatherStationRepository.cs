using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIK.Weather.Models
{
    public interface IWeatherStationRepository
    {
        Task<IEnumerable<WeatherStation>> GetWeatherStations();

        Task<WeatherStation> GetWeatherStationById(string id);

        void InsertWeatherStation(WeatherStation weatherStation);

        void DeleteWeatherStation(string id);

        void UpdateWeatherStation(WeatherStation weatherStation);

        void Save();
    }
}