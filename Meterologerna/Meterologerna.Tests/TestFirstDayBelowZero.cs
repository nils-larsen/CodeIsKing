using System;
using Xunit;
using Meterologerna.Host.Presenters;
using Meterologerna.Logic;

namespace Meterologerna.Tests
{
    public class TestFirstDayBelowZero : TestPresenters
    {
        private readonly ShowFirstDayBelowZero _showBelowZero = new ShowFirstDayBelowZero();
        private DateAndDegree _firstDayBelowZero;

        public TestFirstDayBelowZero()
        {
            _firstDayBelowZero = _showBelowZero.FindFirstDayBelowZero(values);
        }

        [Fact]
        public void FindFirstDayBelowZero_Temperature_should_return_minus_1()
        {
            Assert.Equal(-1.0, _firstDayBelowZero.Temperature);
        }
        
        [Fact]
        public void FindDirstDayBelowZero_Date_should_return_date_2017_11_12()
        {
            Assert.Equal(new DateTime(2017, 11, 12), _firstDayBelowZero.Date);
        }
    }
}
