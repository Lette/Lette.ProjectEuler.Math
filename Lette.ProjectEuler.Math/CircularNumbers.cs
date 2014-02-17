using System.Collections.Generic;

namespace Lette.ProjectEuler.Math
{
    public static class CircularNumbersExtensions
    {   
        public static IEnumerable<long> CircularNumbers(this long n)
        {
            yield return n;

            var magnitude = (long)System.Math.Floor(System.Math.Log10(n));
            var multiplier = (long)System.Math.Pow(10, magnitude);

            for (var i = 0; i < magnitude; i++)
            {
                n = (n % 10 * multiplier) + (n / 10);
                yield return n;
            }
        }

    }
}