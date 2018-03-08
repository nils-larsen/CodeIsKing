using System;

namespace CIK.Weather.Models
{
    public class TemperatureInfo
    {
        public int Id { get; set; }
        public WeatherStation WeatherStation { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
    }
}