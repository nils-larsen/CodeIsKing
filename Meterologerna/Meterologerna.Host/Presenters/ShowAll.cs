using System.Collections.Generic;
using Meterologerna.Logic;

namespace Meterologerna.Host.Presenters
{
    public class ShowAll : IPresenter
    {
        private readonly IEnumerable<IPresenter> _showData;

        public ShowAll(IEnumerable<IPresenter> showData)
        {
            _showData = showData;
        }

        public void Show(IEnumerable<DateAndDegree> datesAndDegrees)
        {
            foreach (var data in _showData)
            {
                data.Show(datesAndDegrees);
            }
        }
    }
}
