using System.Collections.Generic;
using System.Linq;
using CIK.Weather.Models;

namespace CIK.Weather.Tests
{
    public class MockRepository : IWeatherStationRepository
    {
        List<WeatherStation> _data;

        public MockRepository()
        {
            _data = new List<WeatherStation>
            {
                new WeatherStation
                {
                    Id = "2",
                    Name = "Stockholm",
                    Altitude = 10,
                    Longitude = 100,
                    Latitude = 30
                },
                new WeatherStation
                {
                    Id = "3",
                    Name = "gbg",
                    Altitude = 0,
                    Longitude = 23,
                    Latitude = 50
                }
            };
        }

        public void DeleteWeatherStation(string id)
        {
            var weatherStation = _data.Find(x => x.Id == id);
            _data.Remove(weatherStation);
        }

        public void InsertWeatherStation(WeatherStation weatherStation)
        {
            _data.Add(weatherStation);
        }

        public WeatherStation GetWeatherStationById(string id)
        {
            return _data.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<WeatherStation> GetWeatherStations()
        {
            return _data;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateWeatherStation(WeatherStation weatherStation)
        {
            throw new System.NotImplementedException();
        }
    }
}
