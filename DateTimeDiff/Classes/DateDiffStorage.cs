using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeDiff.Classes
{
    public class DateDiffStorage
    {
        public int FullDays { get; set; }
        public int FullMonths { get; set; }
        public int FullYears { get; set; }

        public DateDiffStorage(int yearsDiff, int monthsDiff, int daysDiff)
        {
            FullDays = daysDiff;
            FullMonths = monthsDiff;
            FullYears = yearsDiff;
        }
    }
}
