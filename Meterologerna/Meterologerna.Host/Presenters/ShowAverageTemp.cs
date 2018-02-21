using System;
using System.Collections.Generic;
using System.Linq;
using Meterologerna.Logic;

namespace Meterologerna.Host.Presenters
{
    public class ShowAverageTemp : IPresenter
    {
        public void Show(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            var averageTemperature = AverageTempPerDay(datesAndDegrees);
            averageTemperature.ForEach(day => Console.WriteLine($"{day.Date.ToShortDateString()} - " +
                                                                $"Avg temperature: {day.Temperature.ToString("F2")} degrees"));
        }

        public List<DateAndDegree> AverageTempPerDay(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            var result = datesAndDegrees
                .GroupBy(day => day.Date.ToShortDateString(),
                         day => day.Temperature,
                        (key, g) => new DateAndDegree { Date = Convert.ToDateTime(key), Temperature = g.Average() })
                .ToList();

            return result;
        }
    }
}
