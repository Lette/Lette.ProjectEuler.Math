using System;
using System.Collections.Generic;

namespace Lette.ProjectEuler.Math.Extensions
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> Until(this DateTime from, DateTime to)
        {
            while (from <= to)
            {
                yield return from = from.AddDays(1);
            }
        }
    }
}