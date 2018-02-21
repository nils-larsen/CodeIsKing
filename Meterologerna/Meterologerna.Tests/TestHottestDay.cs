using System;
using Xunit;
using Meterologerna.Host.Presenters;
using Meterologerna.Logic;

namespace Meterologerna.Tests
{
    public class TestHottestDay : TestPresenters
    {
        private readonly ShowHottestDay _showHottestDay = new ShowHottestDay();
        private DateAndDegree _hottestDay;

        public TestHottestDay()
        {
            _hottestDay = _showHottestDay.FindHottestDay(values);
        }

        [Fact]
        public void FindHottestDay_Temperature_should_return_10()
        {
            Assert.Equal(10.0, _hottestDay.Temperature);
        }

        [Fact]
        public void FindHottestDay_Date_should_return_date_2017_11_11()
        {
            Assert.Equal(new DateTime(2017, 11, 11), _hottestDay.Date);
        }
    }
}
