using System;
using System.Collections.Generic;
using System.Linq;
using Meterologerna.Logic;

namespace Meterologerna.Host.Presenters
{
    public class ShowHottestDay : IPresenter
    {
        public void Show(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            var hottestDay = FindHottestDay(datesAndDegrees);
            Console.WriteLine($"Hottest day: {hottestDay} degrees");
        }

        public DateAndDegree FindHottestDay(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            return datesAndDegrees.OrderByDescending(t => t.Temperature).FirstOrDefault();
        }
    }
}
