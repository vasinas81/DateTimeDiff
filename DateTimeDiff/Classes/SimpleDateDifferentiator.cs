using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeDiff.Classes
{
    public class SimpleDateDifferentiator : IDateDifferentiator
    {
        public SimpleDateDifferentiator()
        { }

        private DateDiffStorage InnerDiff(DateTime first, DateTime second)
        {
            var hoursDelta = second.Hour - first.Hour;

            var monthsDelta = 0;
            var yearsDelta = 0;

            var daysDelta = (hoursDelta < 0) ? 1 : 0;

            daysDelta = second.Day - first.Day - daysDelta;
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

        public DateDiffStorage DateDiff(DateTime first, DateTime second)
        {
            var (modFirst, modSecond) = (second - first).TotalMilliseconds < 0
                ? (second, first)
                : (first, second);
            return InnerDiff(modFirst, modSecond);
        }
    }
}
