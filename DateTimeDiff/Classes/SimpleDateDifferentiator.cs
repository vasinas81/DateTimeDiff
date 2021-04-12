using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeDiff.Classes
{
    public class SimpleDateDifferentiator : IDateDifferentiator
    {
        public SimpleDateDifferentiator()
        { }

        public DateDiffStorage DateDiff(DateTime first, DateTime second)
        {
            var daysDelta = second.Day - first.Day;
            var monthsDelta = 0;
            var yearsDelta = 0;
            if (daysDelta < 0)
            {
                daysDelta += DateTime.DaysInMonth(first.Year, first.Month);
                monthsDelta = 1;
            }

            monthsDelta = second.Month - first.Month - monthsDelta;
            if (monthsDelta < 0)
            {
                monthsDelta += 12;
                yearsDelta = 1;
            }

            yearsDelta = second.Year - first.Year - yearsDelta;

            return new DateDiffStorage(yearsDelta, monthsDelta, daysDelta); 
        }
    }
}
