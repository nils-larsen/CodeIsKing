using System;
using System.Collections.Generic;

namespace CIK.Weather.Models
{
    public interface IWeatherStationRepository
    {
        IEnumerable<WeatherStation> GetWeatherStations();
        WeatherStation GetWeatherStationById(string id);
        void InsertWeatherStation(WeatherStation weatherStation);
        void DeleteWeatherStation(string id);
        void UpdateWeatherStation(WeatherStation weatherStation);
        void Save();
    }
}
