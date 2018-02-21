using System;
using Xunit;
using Meterologerna.Host.Presenters;
using Meterologerna.Logic;

namespace Meterologerna.Tests
{
    public class TestColdestDay : TestPresenters
    {
        private readonly ShowColdestDay _showColdestDay = new ShowColdestDay();
        private DateAndDegree _coldestDay;

        public TestColdestDay()
        {
            _coldestDay = _showColdestDay.FindColdestDay(values);
        }

        [Fact]
        public void FindColdestDay_Temperature_should_return_minus_4()
        {
            Assert.Equal(-4.0, _coldestDay.Temperature);
        }

        [Fact]
        public void FindColdestDay_Date_should_return_date_2017_11_13()
        {
            Assert.Equal(new DateTime(2017, 11, 13), _coldestDay.Date);
        }
    }
}
