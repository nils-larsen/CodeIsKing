using System;
using System.Collections.Generic;
using System.Linq;
using Meterologerna.Logic;

namespace Meterologerna.Host.Presenters
{
    public class ShowColdestDay : IPresenter
    {
        public void Show(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            var coldestDay = FindColdestDay(datesAndDegrees);
            Console.WriteLine($"Coldest day: {coldestDay} degrees");
        }

        public DateAndDegree FindColdestDay(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            return datesAndDegrees.OrderBy(t => t.Temperature).FirstOrDefault();
        }
    }
}