using System.Collections.Generic;
using Meterologerna.Logic;
using Meterologerna.Host.Presenters;

namespace Meterologerna.Host
{
    class Program
    {
        static void Main()
        {
            var path = @"..\Data\DatesAndTemps.txt";

            var parser = new DateAndDegreeParser();
            var presenter = new DataPresenter();

            var showBelowZero = new ShowFirstDayBelowZero();
            var showColdest = new ShowColdestDay();
            var showWarmest = new ShowHottestDay();
            var showAverage = new ShowAverageTemp();
            var showAll = new ShowAll(new List<IPresenter> { showBelowZero, showColdest, showWarmest, showAverage });

            var datesAndTemperatures = parser.Parse(path);
            
            presenter.PresentData(showAll, datesAndTemperatures);
        }
    }
}
