using System;
using Xunit;
using System.Collections.Generic;
using Meterologerna.Host.Presenters;
using Meterologerna.Logic;

namespace Meterologerna.Tests
{
    public class TestAverageTemp : TestPresenters
    {
        private readonly ShowAverageTemp _showAverage = new ShowAverageTemp();
        private List<DateAndDegree> _average;

        public TestAverageTemp()
        {
            _average = _showAverage.AverageTempPerDay(values);
        }

        [Fact]
        public void AverageTempPerDay_Temperature_should_return_8_degrees_in_the_first_index()
        {
            Assert.Equal(8.0, _average[0].Temperature);
            Assert.Equal(4.5, _average[1].Temperature);
        }

        [Fact]
        public void AverageTempPerDay_Date_should_return_date_2017_11_14_if_last_index()
        {
            var lastDate = _average.Count;
            Assert.Equal(new DateTime(2017, 11, 14), _average[lastDate-1].Date);
        }

        [Fact]
        public void AverageTempPerDay_should_count_to_4()
        {
            Assert.Equal(4, _average.Count);
        }
    }
}
