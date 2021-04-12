using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeDiff.Classes
{

    abstract class DateDiffDecorator : IDateDifferentiator
    {
        protected IDateDifferentiator _differentiator;
        public DateDiffDecorator(IDateDifferentiator differentiator)
        {
            _differentiator = differentiator;
        }
        public abstract DateDiffStorage DateDiff(DateTime first, DateTime second);
    }
}
