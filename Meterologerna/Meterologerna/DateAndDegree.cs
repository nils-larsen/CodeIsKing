using System;

namespace Meterologerna.Logic
{
    public class DateAndDegree
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}, {Date.ToShortTimeString()}, {Temperature}";
        }
    }
}
