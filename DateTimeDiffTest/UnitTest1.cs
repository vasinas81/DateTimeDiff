using DateTimeDiff.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateTimeDiffTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime firstTime = new DateTime(2010, 12, 31, 10, 0, 0);
            DateTime secondTime = new DateTime(2015, 1, 1, 10, 0, 0);

            var differentiator = new SimpleDateDifferentiator();
            var timeDiff = differentiator.DateDiff(firstTime, secondTime);
            var expectedTimeDiff = new DateDiffStorage(4, 0, 1);
            Assert.AreEqual(timeDiff.FullYears, expectedTimeDiff.FullYears);
            Assert.AreEqual(timeDiff.FullMonths, expectedTimeDiff.FullMonths);
            Assert.AreEqual(timeDiff.FullDays, expectedTimeDiff.FullDays);
        }

        [TestMethod]
        public void TestMethod2()
        {
            DateTime firstTime = new DateTime(2010, 12, 31, 10, 0, 0);
            DateTime secondTime = new DateTime(2015, 1, 1, 10, 0, 0);

            TimeZoneInfo firstZone = TimeZoneInfo.Utc;
            TimeZoneInfo secondZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

            firstTime = TimeZoneInfo.ConvertTime(firstTime, firstZone);
            secondTime = TimeZoneInfo.ConvertTime(secondTime, secondZone);

            var differentiator = new SimpleDateDifferentiator();
            var timeDiffZone = ((IDateDifferentiator)(new TimeZoneDiffDecorator(differentiator))).DateDiff(firstTime, secondTime);

            var expectedTimeDiff = new DateDiffStorage(4, 0, 0);
            Assert.AreEqual(timeDiffZone.FullYears, expectedTimeDiff.FullYears);
            Assert.AreEqual(timeDiffZone.FullMonths, expectedTimeDiff.FullMonths);
            Assert.AreEqual(timeDiffZone.FullDays, expectedTimeDiff.FullDays);
        }

        [TestMethod]
        public void TestMethod3()
        {
            DateTime secondTime = new DateTime(2010, 12, 31, 10, 0, 0);
            DateTime firstTime = new DateTime(2015, 1, 1, 10, 0, 0);

            var differentiator = new SimpleDateDifferentiator();
            var timeDiff = differentiator.DateDiff(firstTime, secondTime);
            var expectedTimeDiff = new DateDiffStorage(4, 0, 1);
            Assert.AreEqual(timeDiff.FullYears, expectedTimeDiff.FullYears);
            Assert.AreEqual(timeDiff.FullMonths, expectedTimeDiff.FullMonths);
            Assert.AreEqual(timeDiff.FullDays, expectedTimeDiff.FullDays);
        }


        [TestMethod]
        public void TestMethod4()
        {
            DateTime secondTime = new DateTime(2010, 12, 31, 10, 0, 0);
            DateTime firstTime = new DateTime(2015, 1, 1, 10, 0, 0);

            var differentiator = new SimpleDateDifferentiator();
            var timeDiff = differentiator.DateDiff(firstTime, secondTime);

            firstTime = new DateTime(2010, 12, 31, 10, 0, 0);
            secondTime = new DateTime(2015, 1, 1, 10, 0, 0);

            var expectedTimeDiff = differentiator.DateDiff(firstTime, secondTime); 

            Assert.AreEqual(timeDiff.FullYears, expectedTimeDiff.FullYears);
            Assert.AreEqual(timeDiff.FullMonths, expectedTimeDiff.FullMonths);
            Assert.AreEqual(timeDiff.FullDays, expectedTimeDiff.FullDays);
        }

        [TestMethod]
        public void TestMethod5()
        {
            DateTime firstTime = new DateTime(2010, 12, 31, 10, 0, 0);
            DateTime secondTime = new DateTime(2015, 1, 1, 10, 0, 0);

            TimeZoneInfo firstZone = TimeZoneInfo.Utc;
            TimeZoneInfo secondZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

            firstTime = TimeZoneInfo.ConvertTime(firstTime, firstZone);
            secondTime = TimeZoneInfo.ConvertTime(secondTime, secondZone);

            var differentiator = new SimpleDateDifferentiator();
            var timeDiffZone = ((IDateDifferentiator)(new TimeZoneDiffDecorator(differentiator))).DateDiff(firstTime, secondTime);

            secondTime = new DateTime(2010, 12, 31, 10, 0, 0);
            firstTime = new DateTime(2015, 1, 1, 10, 0, 0);

            firstTime = TimeZoneInfo.ConvertTime(firstTime, secondZone);
            secondTime = TimeZoneInfo.ConvertTime(secondTime, firstZone);

            var expectedTimeDiff = ((IDateDifferentiator)(new TimeZoneDiffDecorator(differentiator))).DateDiff(firstTime, secondTime);
            Assert.AreEqual(timeDiffZone.FullYears, expectedTimeDiff.FullYears);
            Assert.AreEqual(timeDiffZone.FullMonths, expectedTimeDiff.FullMonths);
            Assert.AreEqual(timeDiffZone.FullDays, expectedTimeDiff.FullDays);
        }
    }
}
