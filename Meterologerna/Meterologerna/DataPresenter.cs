using System.Collections.Generic;

namespace Meterologerna.Logic
{
    public class DataPresenter
    {
        public void PresentData(IPresenter showData, IEnumerable<DateAndDegree> datesAndDegrees)
        {
            showData.Show(datesAndDegrees);
        }
    }
}
