using System.Collections.Generic;

namespace Meterologerna.Logic
{
    public interface IPresenter
    {
        void Show(IEnumerable<DateAndDegree> datesAndTemps);
    }
}
