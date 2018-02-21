using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace Meterologerna.Logic
{
    public class DateAndDegreeParser
    {
        public IEnumerable<DateAndDegree> Parse(string pathToFile)
        {
            var datesAndDegrees = new List<DateAndDegree>();
            using (StreamReader file = new StreamReader(pathToFile))
            {
                var line = file.ReadLine(); // Header - Do nothing
                while ((line = file.ReadLine()) != null)
                {
                    var splittedLine = line.Split(';');

                    var date = UnixSecondsToDateTime(splittedLine[0].Trim('"'));
                    var temp = double.Parse(splittedLine[1].Trim('"'), CultureInfo.InvariantCulture);

                    var dateAndDegree = new DateAndDegree
                    {
                        Date = date,
                        Temperature = temp
                    };
                    datesAndDegrees.Add(dateAndDegree);
                }
            }
            return datesAndDegrees;
        }

        private DateTime UnixSecondsToDateTime(string unixString)
        {
            var unixTimeStamp = int.Parse(unixString);
            return DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
        }
    }
}
