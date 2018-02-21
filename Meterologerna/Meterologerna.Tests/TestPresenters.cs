using System;
using Xunit;
using System.Collections.Generic;
using Meterologerna.Logic;

namespace Meterologerna.Tests
{
    public class TestPresenters
    {
        protected List<DateAndDegree> values;
        
        public TestPresenters()
        {
            values = new List<DateAndDegree>
            {
                new DateAndDegree {Date = new DateTime(2017, 11, 11), Temperature = 6},
                new DateAndDegree {Date = new DateTime(2017, 11, 11), Temperature = 10},
                new DateAndDegree {Date = new DateTime(2017, 11, 12), Temperature = 10},
                new DateAndDegree {Date = new DateTime(2017, 11, 12), Temperature = -1.0},
                new DateAndDegree {Date = new DateTime(2017, 11, 13), Temperature = -4.0},
                new DateAndDegree {Date = new DateTime(2017, 11, 14), Temperature = -1.0},
                new DateAndDegree {Date = new DateTime(2017, 11, 14), Temperature = -4.0}
            };
        }
    }
}
