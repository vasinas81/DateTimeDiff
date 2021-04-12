using DateTimeDiff.Classes;
using System;

namespace DateTimeDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstTime = new DateTime(2010, 12, 31);
            DateTime secondTime = new DateTime(2015, 1, 1);

            var timeDiff = ((IDateDifferentiator)(new SimpleDateDifferentiator())).DateDiff(firstTime, secondTime);

            Console.WriteLine("Time diff is: {0} full years, {1} months, {2} days",
                              timeDiff.FullYears,
                              timeDiff.FullMonths,
                              timeDiff.FullDays
                              );
        }
    }
}
