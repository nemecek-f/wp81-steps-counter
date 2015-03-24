using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class TimeSpanEx
    {
        public static string FormatToTime(this TimeSpan ts)
        {
            if (ts.Hours > 0)
                return ts.ToString("h'h 'm'm'");

            return ts.ToString("m'm'");
        }
    }
}
