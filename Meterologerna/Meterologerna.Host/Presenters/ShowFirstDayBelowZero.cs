using System;
using System.Collections.Generic;
using System.Linq;
using Meterologerna.Logic;

namespace Meterologerna.Host.Presenters
{
    public class ShowFirstDayBelowZero : IPresenter
    {
        public void Show(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            var firstDayBelowZero = FindFirstDayBelowZero(datesAndDegrees);
            Console.WriteLine($"First day below zero: {firstDayBelowZero} degrees");
        }

        public DateAndDegree FindFirstDayBelowZero(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            return datesAndDegrees.FirstOrDefault(t => t.Temperature < 0);
        }
    }
}
