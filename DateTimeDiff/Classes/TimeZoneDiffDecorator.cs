using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeDiff.Classes
{
    public class TimeZoneDiffDecorator : DateDiffDecorator
    {
        public TimeZoneDiffDecorator(IDateDifferentiator differentiator) : base(differentiator) { }
        
        public override DateDiffStorage DateDiff(DateTime first, DateTime second)
        {
            return _differentiator.DateDiff(first.ToUniversalTime(), second.ToUniversalTime());            
        }
    }
}
