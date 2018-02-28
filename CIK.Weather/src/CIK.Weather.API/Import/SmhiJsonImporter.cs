using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using CIK.Weather.Models;
using CIK.Weather.API.Data;
using System.IO;


namespace CIK.Weather.API.Import
{
    //public class SmhiJsonImporter: IImporter
    //{
    //    private readonly WeatherContext _db;

    //    public SmhiJsonImporter(WeatherContext db)
    //    {
    //        _db = db;
    //    }

    //    public string GetResponse(string path)
    //    {
    //        var httpClient = new HttpClient();
    //        //var hej = httpClient.GetStreamAsync(path).Result;
    //        return httpClient.GetStringAsync(path).Result;
    //    }

    //    public void SaveResponse(string response)
    //    {
    //        var root = JsonConvert.DeserializeObject<SmhiResponseObject>(response);
    //        var weatherStations = new List<WeatherStation>();

    //        foreach (var station in root.station)
    //        {
    //            var weatherStation = new WeatherStation
    //            {
    //                Id = station.id.ToString(),
    //                Name = station.name,
    //                Altitude = station.height,
    //                Latitude = station.latitude,
    //                Longitude = station.longitude
    //            };

    //            weatherStations.Add(weatherStation);
    //        }
    //        //_db.RemoveRange(weatherStations);
    //        //_db.SaveChanges();
    //        _db.AddRange(weatherStations);
    //        _db.SaveChanges();
    //    }
    //}


    public class SmhiJsonImporter: IImporter
    {
        readonly WeatherContext _db;

        public SmhiJsonImporter(WeatherContext db)
        {
            _db = db;
        }

        public Stream GetStream(string path)
        {
            var httpClient = new HttpClient();
            return httpClient.GetStreamAsync(path).Result;
        }


        public SmhiResponseObject DeserializeStream(Stream response)
        {
            var serializer = new JsonSerializer();

            using (var streamReader = new StreamReader(response))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<SmhiResponseObject>(jsonTextReader);
            }
        }

        public void SaveObject(SmhiResponseObject root)
        {
            var weatherStations = new List<WeatherStation>();

            foreach (var station in root.station)
            {
                var weatherStation = new WeatherStation
                {
                    Id = station.id.ToString(),
                    Name = station.name,
                    Altitude = station.height,
                    Latitude = station.latitude,
                    Longitude = station.longitude
                };
                weatherStations.Add(weatherStation);
            }
            _db.RemoveRange(weatherStations);
            _db.SaveChanges();
            _db.AddRangeAsync(weatherStations);
            _db.SaveChangesAsync();
        }
    }
}
