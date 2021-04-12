using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeDiff.Classes
{
    public interface IDateDifferentiator
    {
        public DateDiffStorage DateDiff(DateTime first, DateTime second);
    }
}
