using DateTimeDiff.Classes;
using System;

namespace DateTimeDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstTime = new DateTime(2010, 12, 31, 10, 0, 0);
            DateTime secondTime = new DateTime(2015, 1, 1, 10, 0, 0);

            var differentiator = new SimpleDateDifferentiator();
            var timeDiff = differentiator.DateDiff(firstTime, secondTime);

            Console.WriteLine("Time diff is: {0} full years, {1} months, {2} days",
                              timeDiff.FullYears,
                              timeDiff.FullMonths,
                              timeDiff.FullDays
                              );

            TimeZoneInfo firstZone = TimeZoneInfo.Utc;
            TimeZoneInfo secondZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

            firstTime = TimeZoneInfo.ConvertTime(firstTime, firstZone);
            secondTime = TimeZoneInfo.ConvertTime(secondTime, secondZone);

            var timeDiffZone = ((IDateDifferentiator)(new TimeZoneDiffDecorator(differentiator))).DateDiff(firstTime, secondTime);
            Console.WriteLine("Time diff with timezone is: {0} full years, {1} months, {2} days",
                  timeDiffZone.FullYears,
                  timeDiffZone.FullMonths,
                  timeDiffZone.FullDays
                  );
        }
    }
}
